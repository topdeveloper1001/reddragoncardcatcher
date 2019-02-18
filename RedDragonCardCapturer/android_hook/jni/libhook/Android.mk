LOCAL_PATH := $(call my-dir)

include $(CLEAR_VARS)
LOCAL_MODULE     := libhook
LOCAL_SRC_FILES  := subhook.c subhook_unix.c subhook_x86.c
LOCAL_C_INCLUDES := $(LOCAL_PATH)
LOCAL_CFLAGS     := -fvisibility=hidden
include $(BUILD_STATIC_LIBRARY)
