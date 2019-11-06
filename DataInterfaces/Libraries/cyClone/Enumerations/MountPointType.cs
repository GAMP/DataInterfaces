namespace CyClone
{
    /// <summary>
    /// Mount point types.
    /// </summary>
    public enum MountPointType : uint
    {
        /// <summary>
        ///This is a supplementary flag, which specifies that the mounting point is local, visible in current or different user's session. For current session set AuthenticationID to nil / NULL / null / nothing. For other session set Authentication ID to the identifier of that session. 
        ///This flag can be combined with CBFS_SYMLINK_SIMPLE and CBFS_SYMLINK_NETWORK. 
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
}
