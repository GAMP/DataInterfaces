namespace CoreLib
{
    /// <summary>
    /// Process exit codes.
    /// </summary>
    public enum ProcessExitCode
    {
        /// <summary>
        /// Application was shutdown.
        /// </summary>
        ShutDown = -512,
        /// <summary>
        /// Application was restarted.
        /// </summary>
        Restart = -513,
        /// <summary>
        /// Application error occurred.
        /// </summary>
        Error = -514,
        /// <summary>
        /// Update exit code.
        /// </summary>
        Update = -515,
        /// <summary>
        /// Another instance is running.
        /// </summary>
        AnotherInstanceRunning = -516,
        /// <summary>
        /// Terminated on session end.
        /// </summary>
        SessionEnded = -517,
        /// <summary>
        /// System power event such as shutdown or restart.
        /// </summary>
        SystemPowerEvent = -518,
    }
}
