﻿//Copyright (c) Pierre Sprimont.  All rights reserved.

using Microsoft.WindowsAPICodePack.COMNative;
using Microsoft.WindowsAPICodePack.Win32Native;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Microsoft.WindowsAPICodePack.COMNative.MediaDevices
{
    [ComImport,
        Guid(NativeAPI.Guids.MediaDevices.IWMDMObjectInfo),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMDMObjectInfo
    {
        [PreserveSig]
        HResult GetPlayLength(
            [Out] out uint pdwLength);

        [PreserveSig]
        HResult SetPlayLength(
            [In] uint dwLength);

        [PreserveSig]
        HResult GetPlayOffset(
            [Out] out uint pdwOffset);

        [PreserveSig]
        HResult SetPlayOffset(
            [In] uint dwOffset);

        [PreserveSig]
        HResult GetTotalLength(
            [Out] out uint pdwLength);

        [PreserveSig]
        HResult GetLastPlayPosition(
            [Out] out uint pdwLastPos);

        [PreserveSig]
        HResult GetLongestPlayPosition(
            [Out] out uint pdwLongestPos);
    }
}
