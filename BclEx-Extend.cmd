@echo off
echo Refreshing packages:
::BclEx-Abstract.cmd
pushd ..\BclEx-Extend
PowerShell -Command ".\psake.ps1"
popd

::
echo BclEx-Extend
mkdir packages\BclEx-Extend.1.0.0
pushd packages\BclEx-Extend.1.0.0
set SRC=..\..\..\BclEx-Extend\Release
xcopy %SRC%\BclEx-Extend.1.0.0.nupkg . /Y/Q
..\..\tools\7za.exe x -y BclEx-Extend.1.0.0.nupkg -ir!lib
popd
::pause