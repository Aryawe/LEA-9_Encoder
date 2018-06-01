@ECHO OFF

set /P key1="Entrez la clef d'encodage 1: "
set /P key2="Entrez la clef d'encodage 2: "
set /P key3="Entrez la clef d'encodage 3: "

set /P key4="Entrez la clef d'encodage 4: "
set /P key5="Entrez la clef d'encodage 5: "
set /P key6="Entrez la clef d'encodage 6: "

set /P key7="Entrez la clef d'encodage 7: "
set /P key8="Entrez la clef d'encodage 8: "
set /P key7="Entrez la clef d'encodage 9: "

echo First pass...

for %%f in (locked/*.*) do (
  FileEncoder3.exe %key1% %key2% %key3% %key4% %key5% %key6% %key7% %key8% %key9% "locked/%%f" "%temp%\%%f.tmp"
)

echo Second pass...

for %%f in (locked/*.*) do (
  FileEncoder3.exe %key1% %key2% %key3% %key4% %key5% %key6% %key7% %key8% %key9% "%temp%\%%f.tmp" "unlocked/%%f"
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