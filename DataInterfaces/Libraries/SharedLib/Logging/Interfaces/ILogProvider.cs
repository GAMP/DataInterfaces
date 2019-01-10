namespace SharedLib.Logging
{
    #region ILogProvider
    /// <summary>
    /// Generic log provider interface.
    /// </summary>
    public interface ILogProvider
    {
        void Open();
        void Close();
        bool IsAvailable { get; }
        void AddMessage(ILogMessage messege);
        bool IsOpened { get; }
    }
    #endregion
}
