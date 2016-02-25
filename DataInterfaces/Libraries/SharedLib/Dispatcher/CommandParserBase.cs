using SharedLib.Commands;

namespace SharedLib.Dispatcher
{
    #region CommandParserBase
    /// <summary>
    /// Command parsing implementation base class.
    /// </summary>
    public abstract class CommandParserBase : ICommandParser
    {
        /// <summary>
        /// When overriden tries to parse specified command.
        /// </summary>
        /// <param name="cmd">Command to parse.</param>
        /// <returns>True if parsed sucessfully; otherwise, false.</returns>
        public abstract bool TryParse(IDispatcherCommand cmd);
    }
    #endregion
}
