#include <alloca.h>
#include <dlfcn.h>
#include <errno.h>
#include <fcntl.h>
#include <string.h>
#include <unistd.h>

#include <android/log.h>

#include <subhook.h>

static const char *signature = "read_dragon_js";
static const size_t SignatureLen = 14;
static const char *file_path = "/sdcard/Applications/.hipoker.dat";
static const char *format = ">>>>>>>>Java_layaair_game_browser_ConchJNI_callConchJSFunction "
                            "functionName=%s, jsonParam=%s, callbackFuncton=%s";

static subhook_t hook_handle;
static int ipc_file;

static int my_android_log_print(int prio, const char *tag, const char *fmt, ...) {
    subhook_remove(hook_handle);

    va_list args_orig;
    va_start(args_orig, fmt);

    if (0 == strcmp(fmt, format)) {
        va_list args_view;
        va_copy(args_view, args_orig);

        const char *functionName = va_arg(args_view, const char *);

        if (0 == strcmp(functionName, "hi.HoldemPoker.NativeModule.onMessageReceived")) {
            // jsonParam is a base64 WebSocket packet
            const char *jsonParam = va_arg(args_view, const char *);
            // const char *callbackFuncton = va_arg(args_view, const char *);

            // ipc msg format
            const uint32_t payload_len = strlen(jsonParam);
            const size_t header_size = SignatureLen + sizeof(payload_len);
            const size_t full_len = header_size + payload_len;

            char *buf = alloca(full_len);
            memcpy(buf, signature, SignatureLen);
            memcpy(buf + SignatureLen, &payload_len, sizeof(payload_len));
            memcpy(buf + header_size, jsonParam, payload_len);

            /*ssize_t written = */ write(ipc_file, buf, full_len);

            //__android_log_print(ANDROID_LOG_VERBOSE, "FINALLY_GOT_IT",
            //                    "full_len %d, written %d, pBuf %p, buf %s", full_len, written,
            //                    buf, buf + header_size);
        }

        va_end(args_view);
    }

    int ret = __android_log_vprint(prio, tag, fmt, args_orig);
    va_end(args_orig);

    subhook_install(hook_handle);

    return ret;
}

void __attribute__((constructor)) hook() {
    ipc_file = open(file_path, O_WRONLY | O_CREAT | O_TRUNC, S_IRUSR | S_IWUSR | S_IRGRP | S_IROTH);
    if (ipc_file < 0) {
        // const char *e = strerror(errno);
        //__android_log_print(ANDROID_LOG_VERBOSE, "CRAAAASH", "fopen(): %s", e);
        return;
    }

    hook_handle = subhook_new((void *)__android_log_print, (void *)my_android_log_print, 0);

    subhook_install(hook_handle);
}

void __attribute__((destructor)) unhook() {
    close(ipc_file);

    subhook_remove(hook_handle);
    subhook_free(hook_handle);
}