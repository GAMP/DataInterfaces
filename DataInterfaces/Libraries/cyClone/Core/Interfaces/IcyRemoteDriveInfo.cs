using SharedLib.Dispatcher;

namespace CyClone.Core
{
    /// <summary>
    /// Remote drive interface.
    /// </summary>
    public interface IcyRemoteDriveInfo : IcyDriveInfo
    {
        #region PROPERTIES

        /// <summary>
        /// Gets remote dispatcher.
        /// </summary>
        IMessageDispatcher Dispatcher
        {
            get;
        }

        #endregion
    }
}
