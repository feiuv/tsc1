@echo off
REM Iniciar el servidor
REM Clase T�picos Selectos de Computaci�n I 
REM Luis G. Montan� Jim�nez 

SET CLASSPATH=%CLASSPATH%;../idl/Hola.jar;../../Recursos/ConexionMiniFramework/frameworkmini.jar;
echo ********************************************************
echo Ejecutando servidor!!!!!
java HolaServer -ORBInitialPort 2000 -ORBInitialHost localhost