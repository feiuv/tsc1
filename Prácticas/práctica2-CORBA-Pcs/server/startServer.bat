@echo off
REM Iniciar el servidor
REM Clase Tópicos Selectos de Computación I 
REM Luis G. Montané Jiménez 

SET CLASSPATH=%CLASSPATH%;../idl/PCControl.jar;../../Recursos/ConexionMiniFramework/frameworkmini.jar;
echo ********************************************************
echo Ejecutando servidor!!!!!
java PCControlServer -ORBInitialPort 2000 -ORBInitialHost localhost