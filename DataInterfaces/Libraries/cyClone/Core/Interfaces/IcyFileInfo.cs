using System.IO;

namespace CyClone.Core
{
    #region IcyFileInfo
    /// <summary>
    /// File info implementation interface.
    /// </summary>
    public interface IcyFileInfo : IcyFileSystemInfo
    {
        #region PROPERTIES

        /// <summary>
        /// Gets or sets hash.
        /// </summary>
        string Hash { get; set; }

        #endregion

        #region FUNCTIONS

        Stream Open(FileMode mode, FileAccess acess, FileShare share, int bufferSize, FileOptions options);
        Stream Open(FileMode mode, FileAccess acess);
        Stream Open(FileMode mode);
        Stream OpenRead(); 

        #endregion
    } 
    #endregion

    #region IcyRemoteFileInfo
    public interface IcyRemoteFileInfo : IcyRemoteFileSystemInfo
    {
    } 
    #endregion
}
