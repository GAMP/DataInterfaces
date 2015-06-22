using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CyClone.Core
{
    public interface IcyStructure
    {
        /// <summary>
        /// Gets directories count.
        /// </summary>
        int DirectoriesCount { get; }

        /// <summary>
        /// Gets contained entries.
        /// </summary>
        ReadOnlyCollection<CyClone.Core.IcyFileSystemInfo> Entries { get; }

        /// <summary>
        /// Gets file count.
        /// </summary>
        int FilesCount { get; }

        /// <summary>
        /// Gets directory entries.
        /// </summary>
        List<IcyFileSystemInfo> GetDirectories();

        /// <summary>
        /// Gets file entries.
        /// </summary>
        List<IcyFileSystemInfo> GetFiles();

        /// <summary>
        /// Gets extra entries.
        /// </summary>
        List<IcyFileSystemInfo> GetExtras();

        /// <summary>
        /// Gets or sets root entry.
        /// </summary>
        CyClone.Core.IcyFileSystemInfo Root { get; set; }

        /// <summary>
        /// Gets or sets source path.
        /// </summary>
        string Source { get; set; }

        /// <summary>
        /// Converts to byte array.
        /// </summary>
        /// <returns></returns>
        byte[] ToByteArray();

        /// <summary>
        /// Gets total size.
        /// </summary>
        long TotalSize { get; }
    }
}
