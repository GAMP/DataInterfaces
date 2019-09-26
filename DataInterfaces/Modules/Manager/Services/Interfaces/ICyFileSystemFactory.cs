using CyClone.Core;
using SharedLib.Dispatcher;
using System.Threading.Tasks;

namespace Manager.Services
{
    public interface ICyFileSystemFactory
    {
        #region FUNCTIONS

        IcyFileInfo GetFile(string path, IMessageDispatcher dispatcher);

        Task<IcyFileInfo> GetFileAsync(string path, IMessageDispatcher dispatcher);

        bool FileExists(string path, IMessageDispatcher dispatcher);

        Task<bool> FileExistsAsync(string path, IMessageDispatcher dispatcher);

        IcyDirectoryInfo GetDirectory(string path, IMessageDispatcher dispatcher);

        Task<IcyDirectoryInfo> GetDirectoryAsync(string path, IMessageDispatcher dispatcher);

        bool DirectoryExists(string path, IMessageDispatcher dispatcher);

        Task<bool> DirectoryExistsAsync(string path, IMessageDispatcher dispatcher); 

        #endregion
    }
}
