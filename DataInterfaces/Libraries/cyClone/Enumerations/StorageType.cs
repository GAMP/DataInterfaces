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
}
