namespace CoreLib
{
    /// <summary>
    /// Power states.
    /// </summary>
    public enum PowerStates : byte
    {
        /// <summary>
        /// None.
        /// </summary>
        None = 0,
        /// <summary>
        /// Reboot.
        /// </summary>
        Reboot = 1,
        /// <summary>
        /// Shut down.
        /// </summary>
        Shutdown = 2,
        /// <summary>
        /// Suspend.
        /// </summary>
        Suspend = 4,
        /// <summary>
        /// Hibernate.
        /// </summary>
        Hibernate = 8,
        /// <summary>
        /// Log-off.
        /// </summary>
        Logoff = 16,
    }
}
