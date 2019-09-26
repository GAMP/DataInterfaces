using SharedLib.Dispatcher;

namespace CyClone.Core
{
    public interface IcyRemoteFileSystemInfo : IcyFileSystemInfo
    {
        #region PROPERTIES

        /// <summary>
        /// Gets message dispatcher.
        /// </summary>
        IMessageDispatcher Dispatcher
        {
            get;
        }

        #endregion
    }
}
