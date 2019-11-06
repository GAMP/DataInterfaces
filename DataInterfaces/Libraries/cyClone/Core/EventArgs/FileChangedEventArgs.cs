using System;

namespace CyClone.Core
{
    /// <summary>
    /// File changed event args.
    /// </summary>
    [Serializable()]
    public class FileChangedEventArgs : EventArgs
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance of FileChangedEventArgs.
        /// </summary>
        /// <param name="currentFile">Current file.</param>
        /// <param name="previousFile">Previous file.</param>
        public FileChangedEventArgs(IcyFileSystemInfo currentFile, IcyFileSystemInfo previousFile)
        {
            CurrentFile = currentFile;
            PreviousFile = previousFile;
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets current file.
        /// </summary>
        public IcyFileSystemInfo CurrentFile
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets previous file.
        /// </summary>
        public IcyFileSystemInfo PreviousFile
        {
            get;
            protected set;
        }

        #endregion
    }
}
