@echo off
REM Generar paquete jar desde una interfaz IDL
REM Clase Tópicos Selectos de Computación I 
REM Luis G. Montané Jiménez 
echo ******************************************************
echo Limpiando archivos compilados anteriormente
set ARCHIVO_JAR=Casa.jar

echo Compilando interfaz IDL
idlj -fall Casa.idl

echo Compilando código java generado por el compilador idl
javac CasaApp/*.java

echo Generar paquete jar......
echo %ARCHIVO_JAR%
IF NOT EXIST %ARCHIVO_JAR% GOTO terminar
del %ARCHIVO_JAR%
:terminar
jar -cf  %ARCHIVO_JAR% CasaApp\*.class

echo Compilación finalizada!!!
echo ******************************************************
pause > nul