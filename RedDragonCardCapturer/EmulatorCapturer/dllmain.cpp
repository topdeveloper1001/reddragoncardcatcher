#include "pch.h"

namespace transport {

HANDLE hPipe = INVALID_HANDLE_VALUE;
LPCWSTR PIPE_NAME = L"\\\\.\\pipe\\RedDragon";

void Init() {
    hPipe =
        CreateFileW(PIPE_NAME, GENERIC_WRITE, FILE_SHARE_WRITE, nullptr, OPEN_EXISTING, 0, nullptr);

    assert(INVALID_HANDLE_VALUE != hPipe);
}

void Send(const char *buf, std::size_t size) {

    if (INVALID_HANDLE_VALUE == hPipe) {
        Init();

        if (INVALID_HANDLE_VALUE == hPipe) {
            return;
        }
    }

    auto encoded = Encode(buf, size);

    buf = encoded.c_str();
    size = encoded.size();

    DWORD bytes_written;
    auto ret = WriteFile(hPipe, buf, size, &bytes_written, nullptr);

    assert(ret && bytes_written == len);
}

std::string Encode(const char *buf, std::size_t size) {

    std::string key = "82yz1tqyodnl7wlk";
    std::string iv = "8gw9gz6cknqgvqsw";

    CryptoPP::AES::Encryption aesEncryption((CryptoPP::byte *)key.c_str(),
                                            CryptoPP::AES::DEFAULT_KEYLENGTH);

    CryptoPP::CBC_Mode_ExternalCipher::Encryption cbcEncryption(aesEncryption,
                                                                (CryptoPP::byte *)iv.c_str());

    std::string ciphertext, encoded;

    CryptoPP::StreamTransformationFilter stfEncryptor(cbcEncryption,
                                                      new CryptoPP::StringSink(ciphertext));

    stfEncryptor.Put(reinterpret_cast<const unsigned char *>(buf), size + 1);
    stfEncryptor.MessageEnd();

    CryptoPP::StringSource(ciphertext, true,
                           new CryptoPP::Base64Encoder(new CryptoPP::StringSink(encoded)));

    return encoded;
}

void Cleanup() {
    if (INVALID_HANDLE_VALUE != hPipe) {
        CloseHandle(hPipe);
    }
}

} // namespace transport

namespace hook {

static const std::string Signature = "read_dragon_js";

static int (*true_RTFileWrite)(HANDLE hFile, const char *buf, size_t cbToWrite, size_t *pcbWritten);

void Init() {
    true_RTFileWrite = reinterpret_cast<decltype(true_RTFileWrite)>(
        GetProcAddress(GetModuleHandleW(L"VBoxRT"), "RTFileWrite"));
    assert(true_RTFileWrite != nullptr);
}

static int RTFileWrite_hook(HANDLE hFile, const char *buf, size_t cbToWrite, size_t *pcbWritten) {
    using str = std::string::traits_type;

    if (0 == str::compare(Signature.c_str(), buf, Signature.length())) {
        uint32_t pid = 0;
        memcpy(&pid, buf + Signature.length(), sizeof pid);

        if (pid != 0) {
            transport::Send(buf + Signature.length(), cbToWrite - Signature.length());
        }
        *pcbWritten = cbToWrite;
        return 0;
    }

    return true_RTFileWrite(hFile, buf, cbToWrite, pcbWritten);
}

} // namespace hook

BOOL APIENTRY DllMain(HMODULE hModule, DWORD ul_reason_for_call, LPVOID lpReserved) {
    if (DetourIsHelperProcess()) {
        return TRUE;
    }

    switch (ul_reason_for_call) {
    case DLL_PROCESS_ATTACH:
#if defined(_DLL)
        DisableThreadLibraryCalls(hModule);
#endif

#if defined(_DEBUG)
        if (AllocConsole()) {
            freopen("CONIN$", "r", stdin);
            freopen("CONOUT$", "w", stdout);
            freopen("CONOUT$", "w", stderr);
        }

        MessageBoxW(nullptr, L"", L"DEBUG ME", MB_OK);
#endif
        transport::Init();

        hook::Init();

        DetourRestoreAfterWith();

        DetourTransactionBegin();
        DetourUpdateThread(GetCurrentThread());

        DetourAttach(&(PVOID &)hook::true_RTFileWrite, hook::RTFileWrite_hook);

        DetourTransactionCommit();
        break;
    case DLL_THREAD_ATTACH:
    case DLL_THREAD_DETACH:
        break;
    case DLL_PROCESS_DETACH:
        DetourTransactionBegin();
        DetourUpdateThread(GetCurrentThread());

        DetourDetach(&(PVOID &)hook::true_RTFileWrite, hook::RTFileWrite_hook);

        DetourTransactionCommit();

        transport::Cleanup();

        break;
    }
    return TRUE;
}
