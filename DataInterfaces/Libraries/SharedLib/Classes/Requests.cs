using System;
using System.Net;
using SharedLib.Applications;

namespace SharedLib
{
    #region DELEGATES
    public delegate string GetMacAddressDelegate();
    public delegate IPAddress GetIPAddressDelegate(IPVersion version);
    public delegate byte[] CaptureWindowImageDelegate(IntPtr windowHandle, bool includeCursor);
    #endregion

    #region SHAREDFUNCTIONS
    /// <summary>
    /// Shared functions class.
    /// </summary>
    public static class SharedFunctions
    {
        #region Fileds
        /// <summary>
        /// Used for locking shared environment variabales expanding procedures.
        /// </summary>
        public static object ENVIRONMENT_LOCK = new object();
        #endregion

        #region Events
        public static event GetMacAddressDelegate MacRequest;
        public static event GetIPAddressDelegate IPAddressRequest;
        public static event CaptureWindowImageDelegate CaptureRequest;
        #endregion

        #region Networking

        public static string GetLocalMacAddress()
        {
            if (SharedFunctions.MacRequest != null)
            {
                return SharedFunctions.MacRequest();
            }
            else
            {
                return String.Empty;
            }
        }

        public static IPAddress GetLocalIPAddress(IPVersion version)
        {
            if (SharedFunctions.IPAddressRequest != null)
            {
                return SharedFunctions.IPAddressRequest(version);
            }
            else
            {
                return IPAddress.None;
            }
        }

        #endregion

        #region Environment

        /// <summary>
        /// Sets dynamic variables for specifed application profile.
        /// </summary>
        /// <param name="application"></param>
        private static void SetDynamicVarriables(IApplicationProfile application)
        {
            if (application != null)
            {
                Environment.SetEnvironmentVariable("ENTRYPUBLISHER", application.PublisherName);
                Environment.SetEnvironmentVariable("ENTRYDEVELOPER", application.DeveloperName);
                Environment.SetEnvironmentVariable("ENTRYTITLE", application.Title);
            }
            else
            {
                throw new NullReferenceException("Application cannot be null.");
            }
        }

        /// <summary>
        /// Sets dynamic variables for specified executable.
        /// </summary>
        /// <param name="executable"></param>
        private static void SetDynamicVarriables(IExecutable executable)
        {
            if (executable != null)
            {
                if (executable.DefaultDeploymentProfile != null)
                {
                    Environment.SetEnvironmentVariable("ENTRYSOURCE", executable.DefaultDeploymentProfile.Source);
                    Environment.SetEnvironmentVariable("ENTRYDESTINATION", executable.DefaultDeploymentProfile.Destination);
                }
            }
            else
            {
                throw new NullReferenceException("Executable cannot be null.");
            }
        }

        /// <summary>
        /// Clears all dynamic varaibles from system.
        /// </summary>
        private static void UnsetDynamicVariables()
        {
            Environment.SetEnvironmentVariable("ENTRYPUBLISHER", string.Empty);
            Environment.SetEnvironmentVariable("ENTRYDEVELOPER", string.Empty);
            Environment.SetEnvironmentVariable("ENTRYTITLE", string.Empty);
            Environment.SetEnvironmentVariable("ENTRYSOURCE", string.Empty);
            Environment.SetEnvironmentVariable("ENTRYDESTINATION", string.Empty);
        }

        #endregion

        #region Extensions

        /// <summary>
        /// Sets the dynamic environment variables to match this executable profile.
        /// </summary>
        /// <param name="self">Executable profile.</param>
        public static void SetVariables(this IExecutable self)
        {
            SharedFunctions.SetDynamicVarriables(self);
        }

        /// <summary>
        /// Unsets the dynmaic environment variables.
        /// </summary>
        /// <param name="self">Executable profile.</param>
        public static void UnsetVariables(this IExecutable self)
        {
            SharedFunctions.UnsetDynamicVariables();
        }

        /// <summary>
        /// Sets the dynamic environment variables to match this application profile.
        /// </summary>
        /// <param name="self">Application profile.</param>
        public static void SetVariables(this IApplicationProfile self)
        {
            SharedFunctions.SetDynamicVarriables(self);
        }

        /// <summary>
        /// Unsets the dynmaic environment variables.
        /// </summary>
        /// <param name="self">Application profile.</param>
        public static void UnsetVariables(this IApplicationProfile self)
        {
            SharedFunctions.UnsetDynamicVariables();
        }

        #endregion

        #region Imaging

        public static byte[] CaptureWindowImage(IntPtr windowHandle, bool includeCursor)
        {
            try
            {
                if (SharedFunctions.CaptureRequest != null)
                {
                    return SharedFunctions.CaptureRequest(windowHandle, includeCursor);
                }
            }
            catch
            {
                return null;
            }
            return null;
        }

        #endregion
    } 
    #endregion
}
