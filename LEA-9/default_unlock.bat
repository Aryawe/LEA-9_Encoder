@ECHO OFF

echo First pass...

for %%f in (locked/*.*) do (
  FileEncoder3.exe 130 97 91 1 157 228 5 41 245 "locked/%%f" "%temp%\%%f.tmp"
)

echo Second pass...

for %%f in (locked/*.*) do (
  FileEncoder3.exe 130 97 91 1 157 228 5 41 245 "%temp%\%%f.tmp" "unlocked/%%f"
  del /Q /F "%temp%\%%f.tmp"
)

set key1=0
set key2=0
set key3=0

set key4=0
set key5=0
set key6=0

set key7=0
set key8=0
set key9=0

pause