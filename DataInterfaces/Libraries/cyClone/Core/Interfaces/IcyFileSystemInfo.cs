using System;
using System.Threading.Tasks;

namespace CyClone.Core
{
    /// <summary>
    /// File system info interface.
    /// </summary>
    public interface IcyFileSystemInfo
    {
        #region PROPERTIES

        /// <summary>
        /// Gets or sets attributes.
        /// </summary>
        System.IO.FileAttributes Attributes { get; set; }

        /// <summary>
        /// Gets or sets creation time.
        /// </summary>
        DateTime CreationTime { get; set; }

        /// <summary>
        /// Gets or sets last access time.
        /// </summary>
        DateTime LastAccessTime { get; set; }

        /// <summary>
        /// Gets or sets last write time.
        /// </summary>
        DateTime LastWriteTime { get; set; }

        /// <summary>
        /// Gets if entry exists.
        /// </summary>
        bool Exists { get; }

        /// <summary>
        /// Gets full file name.
        /// </summary>
        string FullName
        {
            get;
        }

        /// <summary>
        /// Gets enumeration id.
        /// </summary>
        /// <remarks>
        /// This value is only used to identify file during enumeration.
        /// </remarks>
        int Id { get; set; }

        /// <summary>
        /// Gets or sets flags.
        /// </summary>
        FileInfoLevel Flags
        {
            get;
            set;
        }

        /// <summary>
        /// Gets if entry is virtual.
        /// </summary>
        bool IsVirtual
        {
            get;
        }

        /// <summary>
        /// Gets entry represents virtual file.
        /// </summary>
        bool IsHidden
        {
            get;
        }

        /// <summary>
        /// Gets if file system entry is system file.
        /// </summary>
        /// <remarks>
        /// Value is based on file attributes.
        /// </remarks>
        bool IsSystem { get; }

        /// <summary>
        /// Gets file extension.         
        /// </summary>
        /// <remarks>
        /// Value always equal null for directories.
        /// </remarks>
        string Extension { get; }

        /// <summary>
        /// Gets if entry is directory.
        /// </summary>
        bool IsDirectory { get; }

        /// <summary>
        /// Gets if entry is file.
        /// </summary>
        bool IsFile { get; }

        /// <summary>
        /// Gets if entry is read only.
        /// </summary>
        bool IsReadOnly { get; }

        /// <summary>
        /// Gets total length.
        /// </summary>
        long Length { get; set; }

        /// <summary>
        /// Gets entry name.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Get UNC entry name.
        /// </summary>
        string UNCFileName { get; }

        /// <summary>
        /// Gets or sets relative path.
        /// </summary>
        string RelativePath { get; set; }

        /// <summary>
        /// Gets parent directory.
        /// </summary>
        string ParentDirectory { get; }

        /// <summary>
        /// Gets relative directory.
        /// </summary>
        string RelativeDirectory { get; }

        #endregion

        #region FUNCTIONS

        /// <summary>
        /// Deletes file system entry.
        /// </summary>
        void Delete();

        /// <summary>
        /// Deletes file system entry.
        /// </summary>
        Task DeleteAsync();

        /// <summary>
        /// Sets the current file info to the entry.
        /// <remarks>File info includes File Times and File Atributes.</remarks>
        /// </summary>
        void SetFileInfo();

        /// <summary>
        /// Sets the current attributes to the entry.
        /// </summary>
        void SetAtributes();

        /// <summary>
        /// Sets the current file times to the entry.
        /// </summary>
        void SetFileTimes();

        /// <summary>
        /// Moves entry to new destination.
        /// </summary>
        /// <param name="destinationFileName">Destination file name.</param>
        void MoveTo(string destinationFileName);

        /// <summary>
        /// Gets file info.
        /// </summary>
        /// <returns>True for sucess otherwise false.</returns>
        bool GetFileInfo();

        /// <summary>
        /// Checks if the current File System Entry values are equal to the specified entry.
        /// </summary>
        /// <param name="item">File system entry.</param>
        /// <returns>True or false.</returns>
        bool IsEqual(IcyFileSystemInfo item);

        #endregion
    }
}
