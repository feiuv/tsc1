@echo off
REM Generar paquete jar desde una interfaz IDL
REM Clase Tópicos Selectos de Computación I 
REM Luis G. Montané Jiménez 
echo ******************************************************
echo Limpiando archivos compilados anteriormente
set ARCHIVO_JAR=PCControl.jar

echo Compilando interfaz IDL
idlj -fall PCControl.idl

echo Compilando código java generado por el compilador idl
javac PCControlApp/*.java
javac PCControlApp/PCControlPackage/*.java

echo Generar paquete jar......
echo %ARCHIVO_JAR%
IF NOT EXIST %ARCHIVO_JAR% GOTO terminar
del %ARCHIVO_JAR%
:terminar
jar -cf  %ARCHIVO_JAR% PCControlApp\*.class PCControlApp\PCControlPackage\*.class

echo Compilación finalizada!!!
echo ******************************************************
pause > nul