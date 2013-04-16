using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CyClone.Core
{
    public interface IcyStructure
    {
        int DirectoriesCount { get; }
        ReadOnlyCollection<CyClone.Core.IcyFileSystemInfo> Entries { get; }
        int FilesCount { get; }
        System.Collections.Generic.List<CyClone.Core.IcyFileSystemInfo> GetDirectories();
        System.Collections.Generic.List<CyClone.Core.IcyFileSystemInfo> GetFiles();
        CyClone.Core.IcyFileSystemInfo Root { get; set; }
        string Source { get; set; }
        byte[] ToByteArray();
        long TotalSize { get; }
    }
}
