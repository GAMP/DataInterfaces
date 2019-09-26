using System.IO;

namespace CyClone.Core
{
    public interface IcyDriveInfo
    {
        #region PROPERTIES

        /// <summary>
        /// Gets drive name.
        /// </summary>
        string Name
        {
            get;
        }

        /// <summary>
        /// Gets total avaliable free space.
        /// </summary>
        ulong AvailableFreeSpace
        {
            get;
        }

        /// <summary>
        /// Gets total size.
        /// </summary>
        ulong TotalSize
        {
            get;
        }

        /// <summary>
        /// Gets volume label.
        /// </summary>
        string VolumeLabel
        {
            get;
        }

        /// <summary>
        /// Gets drive type.
        /// </summary>
        DriveType DriveType { get; }

        /// <summary>
        /// Gets drive format.
        /// </summary>
        string DriveFormat { get; }

        /// <summary>
        /// Gets if drive is ready.
        /// </summary>
        bool IsReady { get; }

        /// <summary>
        /// Gets sector size.
        /// </summary>
        uint ClusterSize { get; }

        /// <summary>
        /// Gets the root directory info representing this drive mount point.
        /// </summary>
        IcyDirectoryInfo RootDirectory
        {
            get;
        } 

        #endregion
    } 
}
