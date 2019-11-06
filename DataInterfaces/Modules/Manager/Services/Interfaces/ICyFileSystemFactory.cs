using CyClone.Core;
using SharedLib.Dispatcher;
using System.Threading.Tasks;

namespace Manager.Services
{
    /// <summary>
    /// File system factory.
    /// </summary>
    public interface ICyFileSystemFactory
    {
        #region FUNCTIONS

        /// <summary>
        /// Gets file.
        /// </summary>
        /// <param name="path">File path.</param>
        /// <param name="dispatcher">Disptcher.</param>
        /// <returns>File info.</returns>
        IcyFileInfo GetFile(string path, IMessageDispatcher dispatcher);

        /// <summary>
        /// Gets file.
        /// </summary>
        /// <param name="path">File path.</param>
        /// <param name="dispatcher">Disptcher.</param>
        /// <returns>File info.</returns>
        Task<IcyFileInfo> GetFileAsync(string path, IMessageDispatcher dispatcher);

        /// <summary>
        /// Checks if file exists.
        /// </summary>
        /// <param name="path">File path.</param>
        /// <param name="dispatcher">Disptcher.</param>
        /// <returns>True if exists, otherwise false.</returns>
        bool FileExists(string path, IMessageDispatcher dispatcher);

        /// <summary>
        /// Checks if file exists.
        /// </summary>
        /// <param name="path">File path.</param>
        /// <param name="dispatcher">Disptcher.</param>
        /// <returns>True if exists, otherwise false.</returns>
        Task<bool> FileExistsAsync(string path, IMessageDispatcher dispatcher);

        /// <summary>
        /// Gets directory.
        /// </summary>
        /// <param name="path">Directory path.</param>
        /// <param name="dispatcher">Disptcher.</param>
        /// <returns>Directory info.</returns>
        IcyDirectoryInfo GetDirectory(string path, IMessageDispatcher dispatcher);

        /// <summary>
        /// Gets directory.
        /// </summary>
        /// <param name="path">Directory path.</param>
        /// <param name="dispatcher">Disptcher.</param>
        /// <returns>Directory info.</returns>
        Task<IcyDirectoryInfo> GetDirectoryAsync(string path, IMessageDispatcher dispatcher);

        /// <summary>
        /// Checks if directory exists.
        /// </summary>
        /// <param name="path">Directory path.</param>
        /// <param name="dispatcher">Disptcher.</param>
        /// <returns>True if exists, otherwise false.</returns>
        bool DirectoryExists(string path, IMessageDispatcher dispatcher);

        /// <summary>
        /// Checks if directory exists.
        /// </summary>
        /// <param name="path">Directory path.</param>
        /// <param name="dispatcher">Disptcher.</param>
        /// <returns>True if exists, otherwise false.</returns>
        Task<bool> DirectoryExistsAsync(string path, IMessageDispatcher dispatcher); 

        #endregion
    }
}
