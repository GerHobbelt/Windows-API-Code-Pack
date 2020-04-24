﻿//Copyright (c) Pierre Sprimont.  All rights reserved.

using Microsoft.WindowsAPICodePack.COMNative;
using Microsoft.WindowsAPICodePack.COMNative.MediaDevices;
using Microsoft.WindowsAPICodePack.Win32Native;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Microsoft.WindowsAPICodePack.COMNative.MediaDevices
{
    [ComImport,
        Guid(Win32Native.Guids.MediaDevices.IWMDMDeviceControl),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMDMDeviceControl
    {
        [PreserveSig]
        HResult GetStatus(
            [Out] out uint pdwStatus);

        [PreserveSig]
        HResult GetCapabilities(
            [Out] out uint pdwCapabilitiesMask);

        [PreserveSig]
        HResult Play();

        [PreserveSig]
        HResult Record(
            [In] ref WaveFormatEx pFormat);

        [PreserveSig]
        HResult Pause();

        [PreserveSig]
        HResult Resume();

        [PreserveSig]
        HResult Stop();

        [PreserveSig]
        HResult Seek(
            [In] ushort fuMode,
            [In] short nOffset);
    }
}