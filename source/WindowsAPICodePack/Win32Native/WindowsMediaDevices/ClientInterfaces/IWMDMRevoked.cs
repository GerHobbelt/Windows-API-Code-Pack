﻿using Microsoft.WindowsAPICodePack.Win32Native.Core;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Microsoft.WindowsAPICodePack. Win32Native.MediaDevices.ClientInterfaces
{
    [ComImport,
        Guid(Guids.MediaDevices.IWMDMRevoked),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMDMRevoked
    {
        HResult GetRevocationURL(
            [In,Out,MarshalAs(UnmanagedType.LPWStr)] ref string ppwszRevocationURL,
            [In,Out] ref uint pdwBufferLen,
            [Out] out uint pdwRevokedBitFlag);
    }
}
