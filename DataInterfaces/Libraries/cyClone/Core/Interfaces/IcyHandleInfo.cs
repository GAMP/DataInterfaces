using System.IO;

namespace CyClone.Core
{
    /// <summary>
    /// Handle info interface.
    /// </summary>
    public interface IcyHandleInfo
    {
        #region PROPERTIES

        /// <summary>
        /// Gets remote dispatcher.
        /// </summary>
        SharedLib.Dispatcher.IMessageDispatcher Dispatcher { get; }

        /// <summary>
        /// Gets full file name.
        /// </summary>
        string FullName { get; }

        /// <summary>
        /// Gets safe file handle.
        /// </summary>
        Microsoft.Win32.SafeHandles.SafeFileHandle SafeHandle { get; }

        /// <summary>
        /// Gets file stream.
        /// </summary>
        FileStream FileStream { get; }

        /// <summary>
        /// Gets handle.
        /// </summary>
        int SystemPointer
        {
            get;
        }

        /// <summary>
        /// Gets if handle is colsed.
        /// </summary>
        bool IsClosed
        {
            get;
        }

        /// <summary>
        /// Gets file options.
        /// </summary>
        FileOptions Options
        {
            get;
        }

        /// <summary>
        /// Gets if handle was opened for async operation.
        /// </summary>
        bool IsAsync
        {
            get;
        }

        #endregion

        #region FUNCTIONS
        
        /// <summary>
        /// Closes file handle.
        /// </summary>
        void Close(); 

        #endregion
    }
}
