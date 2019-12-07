namespace ServerService
{
    /// <summary>
    /// Backup result codes.
    /// </summary>
    public enum BackupResultCode
    {
        /// <summary>
        /// Backup succeeded.
        /// </summary>
        Sucess = 0,
        /// <summary>
        /// Database not initialized.
        /// </summary>
        NoInit = 1,
        /// <summary>
        /// Backup is already executing.
        /// </summary>
        AlreadyExecuting = 2,
        /// <summary>
        /// Backup failed.
        /// </summary>
        Failed = 3
    }
}
