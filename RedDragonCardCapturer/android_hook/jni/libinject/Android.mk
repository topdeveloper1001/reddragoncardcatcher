LOCAL_PATH := $(call my-dir)

include $(CLEAR_VARS)
LOCAL_MODULE     := libinject
LOCAL_SRC_FILES  := inject.cpp
include $(BUILD_STATIC_LIBRARY)
