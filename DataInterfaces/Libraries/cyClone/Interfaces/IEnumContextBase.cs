using System;
using System.Threading.Tasks;

namespace CyClone.Core
{
    public interface IEnumerationContext : IDisposable
    {
        void Close();
        Task CloseAsync();
        string DirectoryName { get; }
        string FileName { get; }
        IcyFileSystemInfo FindNextEntry();
        Task<IcyFileSystemInfo> FindNextEntryAsync();
        IcyFileSystemInfo FindNextInfo();
        Task<IcyFileSystemInfo> FindNextInfoAsync();
        IcyFileSystemInfo FindFirstInfo();
        Task<IcyFileSystemInfo> FindFirstInfoAsync();
        bool IsOpen { get; }
    }
}
