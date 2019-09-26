using SharedLib.Dispatcher;

namespace CyClone.Core
{
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
