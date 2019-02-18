LOCAL_PATH := $(call my-dir)

include $(CLEAR_VARS)

LOCAL_MODULE    		:= libhookimpl
LOCAL_SRC_FILES 		:= main.c
LOCAL_C_INCLUDES 		:= $(NDK_APP_PROJECT_PATH)/jni/libhook
LOCAL_STATIC_LIBRARIES 	:= libhook
LOCAL_LDLIBS    		:= -llog

include $(BUILD_SHARED_LIBRARY)
