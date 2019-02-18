LOCAL_PATH := $(call my-dir)

include $(CLEAR_VARS)

LOCAL_MODULE    		:= injector
LOCAL_SRC_FILES 		:= main.cpp
LOCAL_C_INCLUDES 		:= $(NDK_APP_PROJECT_PATH)/jni/libinject
LOCAL_STATIC_LIBRARIES 	:= libinject
LOCAL_LDLIBS    		:= -llog

include $(BUILD_EXECUTABLE)
