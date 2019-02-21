#include "pch.h"

namespace transport {

HANDLE hPipe = INVALID_HANDLE_VALUE;
LPCWSTR PIPE_NAME = L"\\\\.\\pipe\\RedDragon";

void Init() {
    hPipe =
        CreateFileW(PIPE_NAME, GENERIC_WRITE, FILE_SHARE_WRITE, nullptr, OPEN_EXISTING, 0, nullptr);

    assert(INVALID_HANDLE_VALUE != hPipe);
}

template <typename Pointer> void Send(const Pointer data, size_t len) {
    static_assert(std::is_pointer<Pointer>::value);

    if (INVALID_HANDLE_VALUE == hPipe) {
        Init();

        if (INVALID_HANDLE_VALUE == hPipe) {
            return;
        }
    }

    DWORD bytes_written;
    auto ret = WriteFile(hPipe, data, static_cast<DWORD>(len), &bytes_written, nullptr);

    assert(ret && bytes_written == len);
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
