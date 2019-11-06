using SharedLib.Dispatcher;

namespace CyClone.Core
{
    /// <summary>
    /// Remote file info interface.
    /// </summary>
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
