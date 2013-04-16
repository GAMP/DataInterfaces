using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CyClone
{
    #region StorageType
    /// <summary>
    /// Specifies the type of the storage being mounted. 
    /// </summary>
    public enum StorageType
    {
        /// <summary>
        /// The mounted media is a regular disk.
        /// </summary>
        Disk = 0,
        /// <summary>
        /// The mounted media is a CD-ROM or DVD.
        /// </summary>
        CDROM = 1,
        /// <summary>
        /// The mounted media is an in-memory storage.
        /// </summary>
        VirtualDisk = 2,
        /// <summary>
        /// The mounted media is a plug-n-play device.
        /// </summary>
        DiskPnP = 3
    }
    #endregion

    #region MediaType
    /// <summary>
    /// Specifies the characteristics of the storage being mounted. 
    /// </summary>
    [Flags()]
    public enum DiskMediaType : int
    {
        /// <summary>
        /// The mounted media is a floppy disk.
        /// </summary>
        FloppyDiskette = 1,
        /// <summary>
        /// The mounted media is read-only.
        /// </summary>
        ReadOnlyDevice = 2,
        /// <summary>
        /// The mounted media can be removed by the user at any time.
        /// </summary>
        RemovableMedia = 0x10,
        /// <summary>
        /// The mounted media can be written to only once.
        /// </summary>
        WriteOnceMedia = 8,
        /// <summary>
        /// The media can be ejected by the user by using Disconnect Device icon in system notification area (tray) of Explorer. Works only for PnP storages.
        /// </summary>
        ShowInEjectionTray = 0x00004000,
        /// <summary>
        /// If the flag is set, ejection commands are handled and the storage is destroyed. Works only for PnP storages.
        /// </summary>
        AllowEjection = 0x00008000
    }
    #endregion

    #region NotifyFileAction
    public enum NotifyFileAction
    {
        Added = 1,
        Removed = 2,
        Modified = 3,
    }
    #endregion

    #region NetworkSymLinkFlags
    public enum NetworkSymLinkFlags
    {
        AllowMapAsDrive = 1,
        HiddenShare = 2,
        ReadNetworkAccess = 4,
        WriteNetworkAccess = 8,
    }
    #endregion

    #region DriverState
    public enum DriverState
    {
        CBFS_SERVICE_STOPPED = 1,
        CBFS_SERVICE_START_PENDING = 2,
        CBFS_SERVICE_STOP_PENDING = 3,
        CBFS_SERVICE_RUNNING = 4,
        CBFS_SERVICE_CONTINUE_PENDING = 5,
        CBFS_SERVICE_PAUSE_PENDING = 6,
        CBFS_SERVICE_PAUSED = 7,
    }
    #endregion

    #region MountPointType
    public enum MountPointType : uint
    {
        /// <summary>
        ///This is a supplementary flag, which specifies that the mounting point is local, visible in current or different user's session. For current session set AuthenticationID to nil / NULL / null / nothing. For other session set Authentication ID to the identifier of that session. 
        //This flag can be combined with CBFS_SYMLINK_SIMPLE and CBFS_SYMLINK_NETWORK. 
        /// </summary>
        SYMLINK_LOCAL = 0x10000000,
        /// <summary>
        ///Creates a mounting point visible in the mount manager and in Disk Manager applet of Microsoft Manager Console. Mounting point of this kind requires StorageType to bet set to stDiskPnP.
        ///Such mounting points can be mounted as folders on existing NTFS drive. 
        ///This flag can not be combined with CBFS_SYMLINK_SIMPLE, CBFS_SYMLINK_LOCAL or CBFS_SYMLINK_NETWORK. 
        /// </summary>
        SYMLINK_MOUNT_MANAGER = 0x20000,
        /// <summary>
        ///Creates a "network" mounting point. This flag can not be combined with CBFS_SYMLINK_SIMPLE or CBFS_SYMLINK_MOUNT_MANAGER. 
        /// </summary>
        SYMLINK_NETWORK = 0x40000,
        /// <summary>
        ///When the flag is set, a user can assign a drive letter to the "share" for example using "Map share as a drive" menu command in Explorer.
        /// </summary>
        SYMLINK_NETWORK_ALLOW_MAP_AS_DRIVE = 1,
        /// <summary>
        ///Specifies that during the enumeration the share should be skipped. The share is still accessible for use if the user knows its name.
        /// </summary>
        SYMLINK_NETWORK_HIDDEN_SHARE = 2,
        /// <summary>
        ///Tells the API to make a share, available for reading, from the added mounting point.
        /// </summary>
        SYMLINK_NETWORK_READ_NETWORK_ACCESS = 4,
        /// <summary>
        ///Tells the API to make a share, available for reading and writing, from the added mounting point.
        /// </summary>
        SYMLINK_NETWORK_WRITE_NETWORK_ACCESS = 8,
        /// <summary>
        ///Creates a "simple" mounting point. Simple mounting point can be global (accessilbe from all user sessions) or local, visible in current or some other user session (see CBFS_SYMLINK_LOCAL flag).
        /// </summary>
        SYMLINK_SIMPLE = 0x10000,
    }
    #endregion

    #region FileInfoLevel
    /// <summary>
    /// Generic file operations option enumeration.
    /// </summary>
    /// <remarks></remarks>
    [Flags()]
    public enum FileInfoLevel : int
    {
        /// <summary>
        /// None Flag
        /// </summary>
        None = 0,
        /// <summary>
        /// Attributes Flag
        /// </summary>
        Attributes = 1,
        /// <summary>
        /// Security descriptors flags
        /// </summary>
        SecurityDescriptors = 2,
        /// <summary>
        ///Creation time flag
        /// </summary>
        /// <remarks></remarks>
        CreationTime = 4,
        /// <summary>
        /// Last write time flag
        /// </summary>
        LastWriteTime = 8,
        /// <summary>
        /// Last access flag
        /// </summary>
        LastAccessTime = 16,
        /// <summary>
        ///Directories Will Be Collected
        /// </summary>
        Directory = 32,
        /// <summary>
        ///Files Will Be Collected
        /// </summary>
        File = 64,
        /// <summary>
        /// MD5 Hash Flag
        /// </summary>
        Hash = 128,
        /// <summary>
        /// Length Will Be Collected
        /// </summary>
        Length = 256,
        /// <summary>
        /// Data Block Hashing Flag
        /// </summary>
        BlockHash = 512,
        /// <summary>
        /// Excluded Files Flag
        /// </summary>
        ExcludedFiles = 1024,
        /// <summary>
        /// Excluded Directories Flag
        /// </summary>
        /// <remarks></remarks>
        ExcludedDirectories = 2048,
        /// <summary>
        ///Flags Missing Entry.
        /// </summary>
        Missing = 4096,
        /// <summary>
        /// Flags an empty file.
        /// </summary>
        ZeroLength = 8192,
        /// <summary>
        /// Mirror flag.
        /// </summary>
        Mirror = 16384,
        /// <summary>
        /// Flags cleanup operations ignore.
        /// </summary>
        CleanIgnore = 32768,
        /// <summary>
        /// Flags a missing block.
        /// </summary> 
        BlockMissing = 65536,
        /// <summary>
        /// Flags a block difference.
        /// </summary>
        BlockDifference = 131072,
        /// <summary>
        /// Enables dynamic block comparison.
        /// </summary>
        DynamicBlockComparison = 262144,
        /// <summary>
        /// Enables recursive collection of extra files in extra subdirectories.
        /// </summary>
        RecurseExtraDirectories = 524288,
        /// <summary>
        /// Gnereic comparison flag.
        /// </summary>
        ComparisonBasic = FileInfoLevel.LastWriteTime | FileInfoLevel.Length | ComparisonSimple,
        /// <summary>
        /// Generic date time stamping flag.
        /// </summary>
        DateTimeStamps = FileInfoLevel.LastWriteTime | FileInfoLevel.LastAccessTime | FileInfoLevel.CreationTime,
        /// <summary>
        /// Simple comparison mode.
        /// </summary>
        ComparisonSimple = FileInfoLevel.Length | FileInfoLevel.Attributes | FileInfoLevel.File | FileInfoLevel.Directory,
        /// <summary>
        /// Advanced comparison mode.
        /// </summary>
        ComparisonAdvanced = ComparisonBasic | FileInfoLevel.Hash,
        /// <summary>
        /// Basic length collection flag.
        /// </summary>
        LengthBasic = FileInfoLevel.Length | FileInfoLevel.File | FileInfoLevel.Directory,
        /// <summary>
        /// Basic comparison without attributes.
        /// </summary>
        ComparisonBasicNoAttributes = LengthBasic | FileInfoLevel.LastWriteTime,
    }
    #endregion

    #region HashType
    /// <summary>
    /// Hash type enumeration.
    /// </summary>
    public enum HashType : byte
    {
        MD5 = 0,
        Adler32 = 1,
        CRC32 = 2,
        SHA1 = 4,
        Fletcher = 8
    }
    #endregion

    #region TransportMode
    /// <summary>
    /// Transport mode enumeration.
    /// </summary>
    public enum TransportMode : sbyte
    {
        Unicast,
        Multicast,
    }
    #endregion

    #region FileSyncError
    [Flags()]
    public enum FileSyncOperation : int
    {
        /// <summary>
        /// No error occurred.
        /// </summary>
        None = 0,
        /// <summary>
        /// Could not set file attributes.
        /// </summary>
        Attributes = 1,
        /// <summary>
        /// Could not set length.
        /// </summary>
        Length = 2,
        /// <summary>
        /// Could not sync streams content.
        /// </summary>
        ContentSynchronization = 4,
        /// <summary>
        /// Could not open source stream.
        /// </summary>
        SourceOpen = 8,
        /// <summary>
        /// Could not open destination stream.
        /// </summary>
        DestinationOpen = 16,
        /// <summary>
        /// Could not delete incomplete file.
        /// </summary>
        IncompleteFileDelete=32,
        /// <summary>
        /// Source stream could not be closed.
        /// </summary>
        SourceStreamClose=64,
        /// <summary>
        /// Destination stream could not be closed.
        /// </summary>
        DestinationStreamClose=128,
    } 
    #endregion
}
