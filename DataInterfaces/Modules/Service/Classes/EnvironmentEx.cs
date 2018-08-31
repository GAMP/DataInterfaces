using System;

namespace ServerService
{
    public static class EnvironmentEx
    {
        #region STATIC FIELDS
        private static readonly string PROCESS_ENVIRONEMENT = Environment.GetEnvironmentVariable("PROCESS_ENVIRONMENT");
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Checks if process environement is docker.
        /// </summary>
        public static bool IsDocker
        {
            get
            {
                return PROCESS_ENVIRONEMENT == "DOCKER";
            }
        }

        /// <summary>
        /// Get if environemnt is user interactive or docker.
        /// </summary>
        public static bool IsUserInteractiveOrDocker
        {
            get { return Environment.UserInteractive || IsDocker; }
        }

        #endregion
    }
}
