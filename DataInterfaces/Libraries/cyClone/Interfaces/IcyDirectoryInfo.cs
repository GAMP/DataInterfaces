using System.Collections.Generic;
using System.IO;

namespace CyClone.Core
{
    /// <summary>
    /// Directory implementation interface.
    /// </summary>
    public interface IcyDirectoryInfo :IcyFileSystemInfo
    {
        #region PROPERTIES
        
        /// <summary>
        /// Gets the total size of the directory including subdirectories.
        /// <remarks>This propery is called in synchronous manner and can take large amount of time to return.</remarks>
        /// </summary>
        ulong TotalSize
        {
            get;
        }

        /// <summary>
        /// Gets if the directory is empty.
        /// </summary>
        bool IsEmpty { get; }

        /// <summary>
        /// Gets if the directory info represents the root folder.
        /// </summary>
        bool IsRoot { get; }

        /// <summary>
        /// Gets if the directory represents a parent or current directory.
        /// </summary>
        bool IsCurrentOrParent { get; }

        #endregion

        #region FUNCTIONS

        /// <summary>
        /// Creates the directory.
        /// </summary>
        void Create();

        /// <summary>
        /// Deletes directory.
        /// </summary>
        /// <param name="recursive">Specifies if deletion should be recursive.</param>
        void Delete(bool recursive);

        /// <summary>
        /// Gets a list of subdirectories.
        /// </summary>
        /// <param name="searchPattern">Search pattern.</param>
        /// <param name="searchOption">Search option.</param>
        /// <returns>string[] of subdirectories names.</returns>
        string[] GetDirectories(string searchPattern, System.IO.SearchOption searchOption);

        string[] GetDirectories();

        string[] GetDirectories(string searchPattern);

        IcyDirectoryInfo[] GetDirectoryInfos();

        IcyDirectoryInfo[] GetDirectoryInfos(string searchPattern);

        IcyDirectoryInfo[] GetDirectoryInfos(string searchPattern, System.IO.SearchOption searchOption);

        IcyFileInfo[] GetFileInfos(string searchPattern);

        IcyFileInfo[] GetFileInfos();

        IcyFileInfo[] GetFileInfos(string searchPattern, System.IO.SearchOption searchOption);

        string[] GetFiles();

        string[] GetFiles(string searchPattern);

        string[] GetFiles(string searchPattern, SearchOption searchOption);

        IcyDirectoryInfo GetChildDirectoryInfo(string relativePath);

        IcyDirectoryInfo GetChildDirectoryInfo(string relativePath, bool getIfno);

        /// <summary>
        /// Gets the child file info.
        /// </summary>
        /// <param name="relativePath">Child relative path.</param>
        /// <returns>IcyFileInfo file info.</returns>
        IcyFileInfo GetChildFileInfo(string relativePath);

        /// <summary>
        /// Gets the child file info.
        /// </summary>
        /// <param name="relativePath">Child relative path.</param>
        /// <param name="getIfno">Enables or disables obtaining of child info data.</param>
        /// <returns>IcyFileInfo file info.</returns>

        IcyFileInfo GetChildFileInfo(string relativePath, bool getIfno);

        /// <summary>
        /// Gets list of string of each file entry present in directory.
        /// </summary>
        /// <param name="searchPattern"></param>
        /// <returns></returns>

        string[] GteFileSystemEntries(string searchPattern);

        /// <summary>
        /// Gets list of FileSystemInfos.
        /// </summary>
        List<IcyFileSystemInfo> GetFileSystemInfos(string searchPattern, SearchOption searchOption);

        /// <summary>
        /// Gets the enumeration context for this directory info.
        /// </summary>
        /// <returns>IEnumerationContext object.</returns>
        IEnumerationContext GetEnumerationContext();

        /// <summary>
        /// Gets the enumeration context for this directory info.
        /// </summary>
        /// <param name="pattern">Search pattern.</param>
        /// <returns>IEnumerationContext object.</returns>
        IEnumerationContext GetEnumerationContext(string pattern);

        /// <summary>
        /// Checks if specified child directory exists.
        /// </summary>
        /// <param name="relativePath">Directory relative path.</param>
        /// <returns>True or false.</returns>
        bool ChildDirectoryExists(string relativePath);

        /// <summary>
        /// Checks if specified child directory exists.
        /// </summary>
        /// <param name="relativePath">File relative path.</param>
        /// <returns>True or false.</returns>
        bool ChildFileExists(string relativePath);

        /// <summary>
        /// Gets the root drive info.
        /// </summary>
        /// <returns></returns>
        IcyDriveInfo GetRootInfo();    

        #endregion
    }

    /// <summary>
    /// Remote directory implementation interface.
    /// </summary>
    public interface IcyRemoteDirectoryInfo : IcyRemoteFileSystemInfo
    {
    
    }
}
