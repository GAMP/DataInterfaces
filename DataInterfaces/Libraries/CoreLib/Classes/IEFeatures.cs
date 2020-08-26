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
        private static readonly string FEATURE_NINPUT_LEGACYMODE = @"SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_NINPUT_LEGACYMODE";
        private static readonly string FEATURE_LOCALMACHINE_LOCKDOWN = @"SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_LOCALMACHINE_LOCKDOWN";
        private static readonly string FEATURE_BLOCK_LMZ_SCRIPT = @"SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BLOCK_LMZ_SCRIPT";
        private static readonly string FEATURE_BLOCK_LMZ_OBJECT = @"SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BLOCK_LMZ_OBJECT";

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

        /// <summary>
        /// Enables GPU Rendering.
        /// </summary>
        /// <param name="value">Indicates if GPU rendering should be enabled.</param>
        public static void SetGPURendering(int value)
        {
            SetFeatureValue(FEATURE_GPU_RENDERING, value);
        }

        public static void SetLocalMachineLockdown(bool enable)
        {
            SetFeatureValue(FEATURE_LOCALMACHINE_LOCKDOWN, enable ? 1 :0);
        }

        public static void SetBlockLMZScript(bool enable)
        {
            SetFeatureValue(FEATURE_BLOCK_LMZ_SCRIPT, enable ? 1 : 0);
        }

        public static void SetNinputLegacyMode(bool enable)
        {
            SetFeatureValue(FEATURE_NINPUT_LEGACYMODE, enable ? 1 : 0);
        }

        public static void SetBlockLMZObject(bool enable)
        {
            SetFeatureValue(FEATURE_BLOCK_LMZ_OBJECT, enable ? 1 : 0);
        }

        /// <summary>
        /// Sets feature value.
        /// </summary>
        /// <param name="featureKey">Feature key.</param>
        /// <param name="value">Feature value.</param>
        private static void SetFeatureValue(string featureKey, int value)
        {
            SetFeatureValue(AppDomain.CurrentDomain.FriendlyName, featureKey, value);
        }

        /// <summary>
        /// Sets feature value for given process name.
        /// </summary>
        /// <param name="processName">Process name.</param>
        /// <param name="featureKey">Feature key.</param>
        /// <param name="value">Feature value.</param>
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

        /// <summary>
        /// Gets GPU rendering value.
        /// </summary>
        /// <returns></returns>
        public static int? GetGPURenderingFeature()
        {
            return GetFeatureValue(FEATURE_GPU_RENDERING);
        }

        /// <summary>
        /// Gets feature value.
        /// </summary>
        /// <param name="feature"></param>
        /// <returns></returns>
        public static int? GetFeatureValue(string feature)
        {
            return GetFeatureValue(AppDomain.CurrentDomain.FriendlyName, feature);
        }

        /// <summary>
        /// Gets feature value for given process name.
        /// </summary>
        /// <param name="processName">Process name.</param>
        /// <param name="feature">Feature.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Internet explorer versions.
        /// </summary>
        public enum IEVersion : int
        {

            /// <summary>
            /// IE11001.
            /// </summary>
            IE11001 = 11001,
            /// <summary>
            /// IE11000.
            /// </summary>
            IE11000 = 11000,
            /// <summary>
            /// IE10001.
            /// </summary>
            IE10001 = 10001,
            /// <summary>
            /// IE10000
            /// </summary>
            IE10000 = 10000,
            /// <summary>
            /// IE9999.
            /// </summary>
            IE9999 = 9999,
            /// <summary>
            /// IE9000.
            /// </summary>
            IE9000 = 9000,
            /// <summary>
            /// IE8888.
            /// </summary>
            IE8888 = 8888,
            /// <summary>
            /// IE8000.
            /// </summary>
            IE8000 = 8000,
            /// <summary>
            /// IE7000.
            /// </summary>
            IE7000 = 7000,
        }

        #endregion
    }
}
