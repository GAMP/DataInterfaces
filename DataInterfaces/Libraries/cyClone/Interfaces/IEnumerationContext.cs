using System;
using System.Threading.Tasks;

namespace CyClone.Core
{
    /// <summary>
    /// File system enumeration context.
    /// </summary>
    public interface IEnumerationContext : IDisposable
    {
        #region PROPERTIES
        
        /// <summary>
        /// Gets if context is currently open.
        /// </summary>
        bool IsOpen { get; }

        /// <summary>
        /// Gets directory name.
        /// </summary>
        string DirectoryName { get; }

        /// <summary>
        /// Gets file name.
        /// </summary>
        string FileName { get; }

        #endregion

        #region FUNCTIONS

        /// <summary>
        /// Closes enumeration context.
        /// </summary>
        void Close();

        /// <summary>
        /// Asynchronously closes enumeration context.
        /// </summary>
        /// <returns>Associated task.</returns>
        Task CloseAsync();

        /// <summary>
        /// Finds next entry.
        /// </summary>
        /// <returns>Next entry, null in case no more files to enumerate.</returns>
        IcyFileSystemInfo FindNextEntry();

        /// <summary>
        /// Asynchronously finds next entry.
        /// </summary>
        /// <returns>Next entry, null in case no more files to enumerate.</returns>
        Task<IcyFileSystemInfo> FindNextEntryAsync();

        /// <summary>
        /// Finds next info entry.
        /// </summary>
        /// <returns>Next entry, null in case no more files to enumerate.</returns>
        IcyFileSystemInfo FindNextInfo();

        /// <summary>
        /// Asynchronously finds next info entry.
        /// </summary>
        /// <returns>Next entry, null in case no more files to enumerate.</returns>
        Task<IcyFileSystemInfo> FindNextInfoAsync();

        /// <summary>
        /// Finds first info entry.
        /// </summary>
        /// <returns>Next entry, null in case no more files to enumerate.</returns>
        IcyFileSystemInfo FindFirstInfo();

        /// <summary>
        /// Asynchronously finds first info entry.
        /// </summary>
        /// <returns>Next entry, null in case no more files to enumerate.</returns>
        Task<IcyFileSystemInfo> FindFirstInfoAsync(); 

        #endregion
    }
}
