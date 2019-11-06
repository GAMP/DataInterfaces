using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CyClone.Core
{
    /// <summary>
    /// File structure interface.
    /// </summary>
    public interface IcyStructure
    {
        #region PROPERTIES
        
        /// <summary>
        /// Gets or sets root entry.
        /// </summary>
        IcyFileSystemInfo Root { get; set; }

        /// <summary>
        /// Gets or sets source path.
        /// </summary>
        string Source { get; set; }

        /// <summary>
        /// Gets total size.
        /// </summary>
        long TotalSize { get; }

        /// <summary>
        /// Gets directories count.
        /// </summary>
        int DirectoriesCount { get; }

        /// <summary>
        /// Gets file count.
        /// </summary>
        int FilesCount { get; }

        /// <summary>
        /// Gets contained entries.
        /// </summary>
        ReadOnlyCollection<IcyFileSystemInfo> Entries { get; }

        #endregion

        #region FUNCTIONS

        /// <summary>
        /// Gets directory entries.
        /// </summary>
        List<IcyFileSystemInfo> GetDirectories();

        /// <summary>
        /// Gets file entries.
        /// </summary>
        List<IcyFileSystemInfo> GetFiles();

        /// <summary>
        /// Converts to byte array.
        /// </summary>
        /// <returns></returns>
        byte[] ToByteArray();

        #endregion
    }
}
