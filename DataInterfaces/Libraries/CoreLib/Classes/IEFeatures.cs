using Microsoft.Win32;
using System;

namespace CoreLib
{
    /// <summary>
    /// Helper class for IE settings manipulation.
    /// </summary>
    public static class IEFeatures
    {
        #region FEATURES
        private static readonly string FEATURE_BROWSER_EMULATION = @"SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION";
        private static readonly string FEATURE_GPU_RENDERING = @"SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_GPU_RENDERING";
        #endregion

        #region FUNCTIONS

        /// <summary>
        /// Set FEATURE_BROWSER_EMULATION for current process.
        /// </summary>
        /// <param name="version">
        /// Required emulation version.
        /// </param>
        public static void SetEmulationVersion(IEVersion version)
        {
            SetEmulationVersion((int)version);
        }

        /// <summary>
        /// Set FEATURE_BROWSER_EMULATION for current process.
        /// </summary>
        /// <param name="version">
        /// Required emulation version.
        /// </param>
        public static void SetEmulationVersion(int version)
        {
            SetFeatureValue(FEATURE_BROWSER_EMULATION, version);
        }

        public static void SetGPURendering(int value)
        {
            SetFeatureValue(FEATURE_GPU_RENDERING, value);
        }

        private static void SetFeatureValue(string featureKey, int value)
        {
            SetFeatureValue(AppDomain.CurrentDomain.FriendlyName, featureKey, value);
        }

        private static void SetFeatureValue(string processName, string featureKey, int value)
        {
            if (string.IsNullOrWhiteSpace(processName))
                throw new ArgumentNullException(processName);

            using (var key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(featureKey, true))
            {
                if (key == null)
                {
                    using (var newKey = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(featureKey))
                        newKey.SetValue(processName, value, RegistryValueKind.DWord);
                }
                else
                {

                    key.SetValue(processName, value, RegistryValueKind.DWord);
                }
            }
        }

        /// <summary>
        /// Gets FEATURE_BROWSER_EMULATION for specified process.
        /// </summary>
        /// <param name="processName">Process name.</param>
        /// <returns>
        /// Emulation version value, null if no version set.
        /// </returns>
        public static int? GetEmulationVersion(string processName)
        {
            return GetFeatureValue(processName, FEATURE_BROWSER_EMULATION);
        }

        /// <summary>
        /// Gets FEATURE_BROWSER_EMULATION for current process.
        /// </summary>
        /// <returns>
        /// Emulation version value, null if no version set.
        /// </returns>
        public static int? GetEmulationVersion()
        {
            return GetEmulationVersion(AppDomain.CurrentDomain.FriendlyName);
        }

        public static int? GetGPURenderingFeature()
        {
            return GetFeatureValue(FEATURE_GPU_RENDERING);
        }

        public static int? GetFeatureValue(string feature)
        {
            return GetFeatureValue(AppDomain.CurrentDomain.FriendlyName, feature);
        }

        public static int? GetFeatureValue(string processName, string feature)
        {
            if (string.IsNullOrWhiteSpace(processName))
                throw new ArgumentNullException(processName);

            if (string.IsNullOrWhiteSpace(feature))
                throw new ArgumentNullException(feature);

            using (var key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(feature, true))
            {
                return (int?)key.GetValue(processName);
            }
        }

        #endregion

        #region ENUMS

        public enum IEVersion : int
        {
            IE11001 = 11001,
            IE11000 = 11000,
            IE10001 = 10001,
            IE10000 = 10000,
            IE9999 = 9999,
            IE9000 = 9000,
            IE8888 = 8888,
            IE8000 = 8000,
            IE7000 = 7000,
        }

        #endregion
    }
}
