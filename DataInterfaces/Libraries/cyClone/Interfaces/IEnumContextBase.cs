using System;

namespace CyClone.Core
{
    public interface IEnumerationContext : IDisposable
    {
        void Close();
        string DirectoryName { get; }
        string FileName { get; }
        IcyFileSystemInfo FindNextEntry();
        IcyFileSystemInfo FindNextInfo();
        IcyFileSystemInfo FindFirstInfo();
        bool IsOpen { get; }
    }
}
