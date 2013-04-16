using System;
using Microsoft.Win32.SafeHandles;
using SharedLib.Dispatcher;

namespace CyClone.Core
{
    public interface IcyFileSystemInfo
    {
        System.IO.FileAttributes Attributes { get; set; }
        DateTime CreationTime { get; set; }
        void Delete();
        bool Exists { get; }
        bool IsVirtual
        {
            get;
        }
        bool IsHidden
        {
            get;
        }
        bool IsSystem { get; }
        string Extension { get; }
        bool IsDirectory { get; }
        bool IsFile { get; }
        bool IsReadOnly { get; }
        DateTime LastAccessTime { get; set; }
        DateTime LastWriteTime { get; set; }
        long Length { get; set; }
        string Name { get; }
        string UNCFileName { get; }
        string RelativePath { get; set; }
        string ParentDirectory { get; }
        string RelativeDirectory{get;}
        /// <summary>
        /// Sets the current file info to the file.
        /// <remarks>File info includes File Times and File Atributes.</remarks>
        /// </summary>
        void SetFileInfo();
        /// <summary>
        /// Sets the current attributes to the file.
        /// </summary>
        void SetAtributes();
        /// <summary>
        /// Sets the current file times to the file.
        /// </summary>
        void SetFileTimes();
        string FullName
        {
            get;
        }
        int Id { get; set; }
        FileInfoLevel Flags
        {
            get;
            set;
        }
        void MoveTo(string destinationFileName);
        bool GetFileInfo();
        /// <summary>
        /// Checks if the current File System Entry values are equal to the specified entry.
        /// </summary>
        /// <param name="item">File system entry.</param>
        /// <returns>True or false.</returns>
        bool IsEqual(IcyFileSystemInfo item);
    }
    public interface IcyRemoteFileSystemInfo : IcyFileSystemInfo
    {
        IMessageDispatcher Dispatcher
        {
            get;
        }
    }
}
