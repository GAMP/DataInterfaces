using System;
using CyClone.Core;
using CoreLib;

namespace CyClone.Core
{
    #region IcySync
    public interface IcySync
    {
        /// <summary>
        /// Occurs when the source file is changed during the synchronization routine.
        /// </summary>
        event EventHandler<FileChangedEventArgs> FileChanged;

        /// <summary>
        /// Occurs on synchronization error.
        /// </summary>
        event EventHandler<ExceptionEventArgs> Error;

        /// <summary>
        /// Occurs when progress being made.
        /// </summary>
        event EventHandler<SyncProgressEventArgs> Progress;

        /// <summary>
        /// Gets current file info.
        /// </summary>
        IcyFileSystemInfo CurrentFile { get; }

        /// <summary>
        /// Gets current offset in current file.
        /// </summary>
        long CurrentOffset { get; }

        /// <summary>
        /// Gets or sets read buffer size.
        /// </summary>
        int ReadBufferSize { get; set; }

        /// <summary>
        /// Gets total ammoun of data written.
        /// </summary>
        long TotalWritten { get; }

        /// <summary>
        /// Gets or sets write buffer size.
        /// </summary>
        int WriteBufferSize { get; set; }

        /// <summary>
        /// Gets or sets the ammount of time to wait before retrying.
        /// </summary>
        /// <remarks>
        /// Ammount is in milliseconds.
        /// </remarks>
        int RetryWait { get; set; }

        /// <summary>
        /// Gets or sets ammount of retries.
        /// </summary>
        int RetryCount { get; set; }
    } 
    #endregion
}
