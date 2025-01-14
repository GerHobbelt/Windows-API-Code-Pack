﻿//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using Microsoft.WindowsAPICodePack.COMNative.Shell;
using Microsoft.WindowsAPICodePack.Win32Native.Shell;
using System;
using System.Runtime.InteropServices.ComTypes;

namespace Microsoft.WindowsAPICodePack.Shell
{
    /// <summary>
    /// Represents a link to existing FileSystem or Virtual item.
    /// </summary>
    public class ShellLink : ShellObject
    {
        /// <summary>
        /// Path for this file e.g. c:\Windows\file.txt,
        /// </summary>
        private string _internalPath;

        #region Internal Constructors

        internal ShellLink(IShellItem2 shellItem) => nativeShellItem = shellItem;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ShellLink"/> class and directly saves the link on disk.
        /// </summary>
        /// <param name="sourcePath">The full source path.</param>
        /// <param name="destPath">The destination directory.</param>
        public ShellLink(string sourcePath, string destPath)

        {

            var lnk = Activator.CreateInstance(Type.GetTypeFromCLSID(new Guid(NativeAPI.Guids.Shell.CShellLink), true)) as IShellLinkW;
            lnk.SetPath(sourcePath);
            string linkPath = destPath + "\\\\" + System.IO.Path.GetFileNameWithoutExtension(sourcePath) + ".lnk";
            ((IPersistFile)lnk).Save(linkPath, true);
            Path = linkPath;
            TargetLocation = sourcePath;

        }

        #region Public Properties

        /// <summary>
        /// The path for this link
        /// </summary>
        public virtual string Path
        {
            get
            {
                if (_internalPath == null && NativeShellItem != null)

                    _internalPath = base.ParsingName;

                return _internalPath;
            }
            protected set => _internalPath = value;
        }

        private string internalTargetLocation;

        /// <summary>
        /// Gets the location to which this link points to.
        /// </summary>
        public string TargetLocation
        {
            get
            {
                if (string.IsNullOrEmpty(internalTargetLocation) && NativeShellItem2 != null)

                    internalTargetLocation = Properties.System.Link.TargetParsingPath.Value;

                return internalTargetLocation;
            }
            set
            {
                if (value == null) return;

                internalTargetLocation = value;

                if (NativeShellItem2 != null)

                    Properties.System.Link.TargetParsingPath.Value = internalTargetLocation;

            }
        }

        /// <summary>
        /// Gets the ShellObject to which this link points to.
        /// </summary>
        public ShellObject TargetShellObject => ShellObjectFactory.Create(TargetLocation);

        /// <summary>
        /// Gets or sets the link's title
        /// </summary>
        public string Title
        {
            get => NativeShellItem2 != null ? Properties.System.Title.Value : null;

            set
            {
                if (value == null)

                    throw new ArgumentNullException(nameof(value));

                if (NativeShellItem2 != null)

                    Properties.System.Title.Value = value;
            }
        }

        private string internalArguments;

        /// <summary>
        /// Gets the arguments associated with this link.
        /// </summary>
        public string Arguments
        {
            get
            {
                if (string.IsNullOrEmpty(internalArguments) && NativeShellItem2 != null)

                    internalArguments = Properties.System.Link.Arguments.Value;

                return internalArguments;
            }
        }

        private string internalComments;

        /// <summary>
        /// Gets the comments associated with this link.
        /// </summary>
        public string Comments
        {
            get
            {
                if (string.IsNullOrEmpty(internalComments) && NativeShellItem2 != null)

                    internalComments = Properties.System.Comment.Value;

                return internalComments;
            }
        }


        #endregion
    }
}
