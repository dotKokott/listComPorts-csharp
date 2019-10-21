# listComPorts-csharp
C# version of Todbot's listComPorts tool https://github.com/todbot/usbSearch/


## Info
Instead of this executable one could also go for a pure call to the wmci.exe & filter the content afterwards:

´wmic path Win32_PnPEntity where "Name like '%(COM%'" get Name,DeviceID´
Outputs:
´´´
DeviceID                                       Name
USB\VID_239A&PID_800B&MI_00\6&283305BE&0&0000  USB Serial Device (COM16)
´´´