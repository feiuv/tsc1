@echo off
REM Compilar servidor CORBA
REM Clase T�picos Selectos de Computaci�n I 
REM Luis G. Montan� Jim�nez 
echo ******************************************************
echo Limpiando archivos compilados anteriormente
SET CLASSPATH=%CLASSPATH%;../idl/PCControl.jar;../../Recursos/ConexionMiniFramework/frameworkmini.jar;

SET ARCHIVO_JAR=PCControl.jar
IF NOT EXIST *.class GOTO terminar
del *.class

:terminar
echo Compilando clases del servidor!!!
javac *.java
echo Finalizando compilaci�n del servidor!!!

pause > nul