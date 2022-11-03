@echo off

set CORECLR_ENABLE_PROFILING=1
set CORECLR_PROFILER={B3A10128-F10D-4044-AB27-A799DB8B7E4F}
set CORECLR_PROFILER_PATH=..\Profiler\bin\Release\net7.0\win-x64\publish\Profiler.dll

.\bin\Debug\net6.0\ConsoleApp1.exe