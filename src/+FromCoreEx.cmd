@echo off
echo Refreshing source files:

::
echo FromCoreEx
pushd +FromCoreEx
set SRC=..\..\..\BclEx-Extend\src\System.CoreEx
xcopy %SRC%\Threading\Async\* Threading\Async\ /Y/Q
xcopy %SRC%\Threading\SingleEntryGate.cs Threading\ /Y/Q
popd
pause