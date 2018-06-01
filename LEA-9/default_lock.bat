@ECHO OFF

echo First pass...
	
for %%f in (unlocked/*.*) do (
  FileEncoder3.exe 157 254 117 31 195 179 24 51 185 "unlocked/%%f" "%temp%/%%f.tmp"
)

echo Second pass...

for %%f in (unlocked/*.*) do (
  FileEncoder3.exe 157 254 117 31 195 179 24 51 185 "%temp%/%%f.tmp" "locked/%%f"
  del /Q /F "%temp%\%%f.tmp"
  del /Q /F "unlocked\%%f"
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