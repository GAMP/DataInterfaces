using System;
using CyClone.Core;
using SharedLib.Dispatcher;

namespace CyClone.Core
{
    public interface IcyFileInfo : IcyFileSystemInfo
    {
        string Hash { get; set; }
        System.IO.Stream Open(System.IO.FileMode Mode, System.IO.FileAccess Access, System.IO.FileShare Share, int BufferSize, System.IO.FileOptions Options);
        System.IO.Stream Open(System.IO.FileMode Mode, System.IO.FileAccess Access);
        System.IO.Stream Open(System.IO.FileMode Mode);
        System.IO.Stream OpenRead();      
    }

    public interface IcyRemoteFileInfo : IcyRemoteFileSystemInfo
    {
 
    }
}
