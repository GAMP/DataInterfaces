using System.IO;

namespace CyClone.Core
{
    #region IcyFileInfo
    public interface IcyFileInfo : IcyFileSystemInfo
    {
        #region PROPERTIES

        string Hash { get; set; }

        #endregion

        #region FUNCTIONS

        Stream Open(FileMode Mode, FileAccess Access, FileShare Share, int BufferSize, FileOptions Options);
        Stream Open(FileMode Mode, FileAccess Access);
        Stream Open(FileMode Mode);
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
