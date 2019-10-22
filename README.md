# listComPorts-csharp
C# version of Todbot's listComPorts tool https://github.com/todbot/usbSearch/

Roughly replicates behavior of https://github.com/todbot/usbSearch/blob/master/listComPorts.c


## Usage
```
cmd> .\listComPorts.exe
COM16 USB\VID_239A&PID_800B&MI_00\6&283305BE&0&0000
```

## Info
Instead of this executable one could also go for a simple call to the wmic.exe & filter the content afterwards.

This call:
``` wmic path Win32_PnPEntity where "Name like '%(COM%'" get Name,DeviceID ```

outputs:

```

DeviceID                                       Name
USB\VID_239A&PID_800B&MI_00\6&283305BE&0&0000  USB Serial Device (COM16)

```
