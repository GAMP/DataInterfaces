using System;
using CyClone.Core;
using CoreLib;

namespace CyClone.Core
{
    #region IcySync
    public interface IcySync
    {
        /// <summary>
        /// Gets current file info.
        /// </summary>
        IcyFileSystemInfo CurrentFile { get; }

        /// <summary>
        /// Gets current offset in current file.
        /// </summary>
        long CurrentOffset { get; }

        /// <summary>
        /// Occurs on exception.
        /// </summary>
        event ExceptionEventDelegate Error;

        /// <summary>
        /// Occurs on file change.
        /// </summary>
        event FileChangedDelegate FileChanged;

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
    } 
    #endregion
}
