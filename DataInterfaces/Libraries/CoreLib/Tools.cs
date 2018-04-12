using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using Microsoft.Win32;

namespace CoreLib
{
    #region ObjectCopier
    /// <summary>
    /// Reference Article http://www.codeproject.com/KB/tips/SerializedObjectCloner.aspx
    /// Provides a method for performing a deep copy of an object.
    /// Binary Serialization is used to perform the copy.
    /// </summary>
    public static class ObjectCopier
    {
        /// <summary>
        /// Perform a deep Copy of the object.
        /// </summary>
        /// <typeparam name="T">The type of object being copied.</typeparam>
        /// <param name="source">The object instance to copy.</param>
        /// <returns>The copied object.</returns>
        public static T Clone<T>(T source)
        {
            // Don't serialize a null object, simply return the default for that object
            if (object.ReferenceEquals(source, null))           
                return default(T);
            
            IFormatter formatter = new BinaryFormatter();
            using (Stream stream = new MemoryStream())
            {
                using (stream)
                {
                    formatter.Serialize(stream, source);
                    stream.Seek(0, SeekOrigin.Begin);
                    return (T)formatter.Deserialize(stream);
                }
            }
        }
    } 
    #endregion    

    #region Wildcard
    /// <summary>
    /// Represents a wildcard running on the
    /// <see cref="System.Text.RegularExpressions"/> engine.
    /// </summary>
    public class Wildcard : Regex
    {
        #region CONSTRUCTOR
        
        /// <summary>
        /// Initializes a wildcard with the given search pattern.
        /// </summary>
        /// <param name="pattern">The wildcard pattern to match.</param>
        public Wildcard(string pattern)
            : base(WildcardToRegex(pattern))
        {
        }

        /// <summary>
        /// Initializes a wildcard with the given search pattern and options.
        /// </summary>
        /// <param name="pattern">The wildcard pattern to match.</param>
        /// <param name="options">A combination of one or more
        /// <see cref="System.Text.RegexOptions"/>.</param>
        public Wildcard(string pattern, RegexOptions options)
            : base(WildcardToRegex(pattern), options)
        {
        }

        /// <summary>
        /// Converts a wildcard to a regex.
        /// </summary>
        /// <param name="pattern">The wildcard pattern to convert.</param>
        /// <returns>A regex equivalent of the given wildcard.</returns>
        public static string WildcardToRegex(string pattern)
        {
            return "^" + Regex.Escape(pattern).
             Replace("\\*", ".*").
             Replace("\\?", ".") + "$";
        } 

        #endregion
    }
    #endregion

    #region IEFeatures
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
                key.SetValue(processName, value, RegistryValueKind.DWord);
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


    #endregion
}
