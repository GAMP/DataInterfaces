using System;
using System.IO;

namespace CyClone.Core
{
    public interface IcyHandleInfo
    {
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
        /// Closes file handle.
        /// </summary>
        void Close();
    }
}
