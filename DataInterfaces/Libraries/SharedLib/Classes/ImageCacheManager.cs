using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharedLib
{
    /// <summary>
    /// Image data cache manager.
    /// </summary>
    public static class ImageCacheManager
    {
        #region Fields
        private static Dictionary<int, byte[]> appImageCache;
        private static Dictionary<int, byte[]> exeImageCache;
        private static int maxCachedCount=20;
        private static object opLock = new object();
        #endregion

        #region Private Properties

        private static Dictionary<int, byte[]> AppImageCache
        {
            get 
            {
                if (ImageCacheManager.appImageCache == null)
                {
                    lock (ImageCacheManager.opLock)
                    {
                        if (ImageCacheManager.appImageCache == null)
                        {
                            ImageCacheManager.appImageCache = new Dictionary<int, byte[]>();
                        }
                    }
                }
                return ImageCacheManager.appImageCache;
            }
        }
        
        private static Dictionary<int, byte[]> ExeImageCache
        {
            get
            {
                if (ImageCacheManager.exeImageCache == null)
                {
                    lock (ImageCacheManager.opLock)
                    {
                        if (ImageCacheManager.exeImageCache == null)
                        {
                            ImageCacheManager.exeImageCache = new Dictionary<int, byte[]>();
                        }
                    }
                }
                return ImageCacheManager.exeImageCache;
            }
        }

        
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets or sets maximum cached images count per dictionary.
        /// <remarks>Value applied independently between cache dictionaries.</remarks>
        /// </summary>
        public static int MaxCachedCount
        {
            get 
            {
                return ImageCacheManager.maxCachedCount; 
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Count may not be less or equal zero", "MaxCachedCount");
                }
                ImageCacheManager.maxCachedCount = value;
            }
        } 
        #endregion

        #region Public Static Functions

        public static byte[] GetImageData(int sourceId, ImageType sourceType)
        {
            return null;
        }

        /// <summary>
        /// Tries to get image data.
        /// </summary>
        /// <param name="sourceId">Source Id.</param>
        /// <param name="sourceType">Source Type.</param>
        /// <param name="imageData">Found image data array.</param>
        /// <returns>True if image data was obtained otherwise false.</returns>
        public static bool TryGetImageData(int sourceId, ImageType sourceType, out byte[] imageData)
        {
            imageData = null;
            return false;
        } 

        #endregion
    } 
}
