@echo off
PATH=C:\Users\Bers\Desktop\android\platform-tools;%PATH%
rem cd /data/local/tmp/
rem ./injector $(pidof com.hipoker.psPoker) $(realpath libhookimpl.so)
@echo on

cls
adb push ..\libs\x86\injector /data/local/tmp
adb push ..\libs\x86\libhookimpl.so /data/local/tmp
adb shell "chmod 755 /data/local/tmp/injector"