using System;

namespace ServerService
{
    /// <summary>
    /// Extended Environment class.
    /// </summary>
    /// <remarks>
    /// Provides extended environment functionality.
    /// </remarks>
    public static class EnvironmentEx
    {
        #region STATIC FIELDS
        private static readonly string PROCESS_ENVIRONMENT = Environment.GetEnvironmentVariable("PROCESS_ENVIRONMENT");
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Checks if process environement is docker.
        /// </summary>
        public static bool IsDocker
        {
            get
            {
                return PROCESS_ENVIRONMENT == "DOCKER";
            }
        }

        /// <summary>
        /// Get if environemnt is user interactive or docker.
        /// </summary>
        public static bool IsUserInteractiveOrDocker
        {
            get { return Environment.UserInteractive || IsDocker; }
        }

        /// <summary>
        /// Gets a value indicating whether the current process is running in user interactive mode.
        /// </summary>
        public static bool IsUserInteractive
        {
            get { return Environment.UserInteractive; }
        }

        #endregion
    }
}
