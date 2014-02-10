dim serviceSample
set service = CreateObject("ServiceInfo.InfoCOM")
msgbox "Serial: " + service.serialBaseBoard()