namespace CoreLib.Diagnostics
{
    /// <summary>
    /// Remote core process interface.
    /// </summary>
    public interface IRemoteCoreProcess
    {
        #region PROPERTIES

        /// <summary>
        /// Gets message dispatcher.
        /// </summary>
        SharedLib.Dispatcher.IMessageDispatcher Dispatcher { get; }

        #endregion
    }
}
