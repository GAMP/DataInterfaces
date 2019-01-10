using System.Threading.Tasks;

namespace Client
{
    public interface IAppImageHandler
    {
        #region FUNCTIONS
        
        /// <summary>
        /// Tries to obtain image data.
        /// </summary>
        /// <param name="entityId">Entity id.</param>
        /// <param name="type">Entity type.</param>
        /// <returns>Image data, null if no image data is set or invalid entity id.</returns>
        Task<byte[]> TryGetImageFromCacheAsync(int entityId, ImageType type);

        /// <summary>
        /// Tries to obtain image data.
        /// </summary>
        /// <param name="entityId">Entity id.</param>
        /// <param name="type">Entity type.</param>
        /// <returns>Image data, null if no image data is set or invalid entity id.</returns>
        Task<byte[]> TryGetImageDataAsync(int entityId, ImageType type); 

        #endregion
    }

    public enum ImageType
    {
        Application,
        Executable,
    }
}
