using System;

namespace CyClone.Core
{
    /// <summary>
    /// Directory implementation interface.
    /// </summary>
    public interface IcyDirectoryInfo : IcyFileSystemInfo
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
        /// Creates directory.
        /// </summary>
        void Create();

        /// <summary>
        /// Deletes directory.
        /// </summary>
        /// <param name="recursive">Specifies if deletion should be recursive.</param>
        void Delete(bool recursive);

        /// <summary>
        /// Gets child path relative to directory.
        /// </summary>
        /// <param name="relativePath">Child relative path.</param>
        /// <returns>Full child path.</returns>
        /// <exception cref="ArgumentNullException">Thrown in case <paramref name="relativePath"/>equals null or empty string.</exception>
        string GetChildPath(string relativePath);

        /// <summary>
        /// Gets child directory info.
        /// </summary>
        /// <param name="relativePath">Child relative path.</param>
        /// <returns>Child directory info.</returns>
        IcyDirectoryInfo GetChildDirectoryInfo(string relativePath);

        /// <summary>
        /// Gets child directory info.
        /// </summary>
        /// <param name="relativePath">Child relative path.</param>
        /// <param name="getIfno">Indicates if the file info should be obtained.</param>
        /// <returns>Child directory info.</returns>
        IcyDirectoryInfo GetChildDirectoryInfo(string relativePath, bool getIfno);

        /// <summary>
        /// Gets the child file info.
        /// </summary>
        /// <param name="relativePath">Child relative path.</param>
        /// <returns>Child file info.</returns>
        IcyFileInfo GetChildFileInfo(string relativePath);

        /// <summary>
        /// Gets the child file info.
        /// </summary>
        /// <param name="relativePath">Child relative path.</param>
        /// <param name="getIfno">Indicates if the file info should be obtained.</param>
        /// <returns>Child file info.</returns>
        IcyFileInfo GetChildFileInfo(string relativePath, bool getIfno);

        /// <summary>
        /// Gets the enumeration context for this directory info.
        /// </summary>
        /// <returns>IEnumerationContext instance.</returns>
        IEnumerationContext GetEnumerationContext();

        /// <summary>
        /// Gets the enumeration context for this directory info.
        /// </summary>
        /// <param name="pattern">Search pattern.</param>
        /// <returns>IEnumerationContext instance.</returns>
        /// <exception cref="ArgumentNullException">Thrown in case <paramref name="pattern"/>equals null or empty string.</exception>
        IEnumerationContext GetEnumerationContext(string pattern);

        /// <summary>
        /// Checks if specified child directory exists.
        /// </summary>
        /// <param name="relativePath">Directory relative path.</param>
        /// <returns>True or false.</returns>
        /// <exception cref="ArgumentNullException">Thrown in case <paramref name="relativePath"/>equals null or empty string.</exception>
        bool ChildDirectoryExists(string relativePath);

        /// <summary>
        /// Checks if specified child directory exists.
        /// </summary>
        /// <param name="relativePath">File relative path.</param>
        /// <returns>True or false.</returns>
        /// <exception cref="ArgumentNullException">Thrown in case <paramref name="relativePath"/>equals null or empty string.</exception>
        bool ChildFileExists(string relativePath);

        /// <summary>
        /// Gets the root drive info.
        /// </summary>
        /// <returns></returns>
        IcyDriveInfo GetRootInfo();


        #endregion
    }
}
