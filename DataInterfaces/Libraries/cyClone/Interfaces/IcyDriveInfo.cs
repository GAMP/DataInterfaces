using System;
using SharedLib.Dispatcher;
using System.IO;

namespace CyClone.Core
{
    public interface IcyDriveInfo
    {
        /// <summary>
        /// Gets the root directory info representing this drive mount point.
        /// </summary>
        IcyDirectoryInfo RootDirectory
        {
            get;
        }
        string Name
        {
            get;
        }
        ulong AvailableFreeSpace
        {
            get;
        }
        ulong TotalSize
        {
            get;
        }
        string VolumeLabel
        {
            get;
        }
        DriveType DriveType { get; }
        string DriveFormat {get;}
    }
    public interface IcyRemoteDriveInfo : IcyDriveInfo
    {
        IMessageDispatcher Dispatcher
        {
            get;
        }
    }
}
