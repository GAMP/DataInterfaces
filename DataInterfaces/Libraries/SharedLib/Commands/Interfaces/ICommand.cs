using SharedLib.Dispatcher;
namespace SharedLib.Commands
{
    #region Delegates
    /// <summary>
    /// Command state change event.
    /// </summary>
    /// <param name="sender">Command object that raised the event.</param>
    /// <param name="state">New Command state.</param>
    /// <param name="parameters">New parameters.</param>
    public delegate void StateChangeDelegate(IDispatcherCommand sender, CommandStates state, params object[] parameters);
    #endregion       

    #region IDispatcherCommand
    /// <summary>
    /// IDispatcherCommand command interface.
    /// </summary>
    public interface IDispatcherCommand
    {
        /// <summary>
        /// Gets or sets command unique id.
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Gets command request id.
        /// </summary>
        int RequestID { get; set; }

        /// <summary>
        /// Gets or sets command source dispatcher id.
        /// </summary>
        int SourceID { get; set; }

        /// <summary>
        /// Gets or sets command destination dispatcher id.
        /// </summary>
        int DestinationID { get; set; }

        /// <summary>
        /// Gets or sets command dispatcher.
        /// </summary>
        IMessageDispatcher Dispatcher { get; set; }

        /// <summary>
        /// Gets if command requiers a response based on its current state.
        /// </summary>
        bool NeedsResponse { get; }

        /// <summary>
        /// Gets or sets command assigned operation.
        /// </summary>
        IOperation Operation { get; set; }

        /// <summary>
        /// Gets or sets command parameters object.
        /// </summary>
        object Params { get; set; }

        /// <summary>
        /// Gets or sets command parameters array.
        /// </summary>
        object[] ParamsArray { get; }

        /// <summary>
        /// Gets or sets command request type.
        /// </summary>
        RequestsType RequestType { get; set; }

        /// <summary>
        /// Gets or sets states for which command requires a response.
        /// </summary>
        CommandStates ResponseStates { get; set; }

        /// <summary>
        /// Gets or sets current command state.
        /// </summary>
        CommandStates State { get; set; }

        /// <summary>
        /// Gets or sets operation state.
        /// </summary>
        OperationState OperationState { get; set; }

        /// <summary>
        /// Occurs on command state change. 
        /// </summary>
        event StateChangeDelegate StateChange;

        /// <summary>
        /// Gets or sets predefined command type.
        /// </summary>
        CommandType Type { get; set; }

        /// <summary>
        /// Checks if current command needs a response to specified state.
        /// </summary>
        /// <param name="newState">New command state.</param>
        /// <returns>True or false.</returns>
        bool NeedsResponseToState(CommandStates newState);

        /// <summary>
        /// Updaates current command state.
        /// </summary>
        /// <param name="state">New command state.</param>
        /// <param name="parameters">State change additional parameters.</param>
        void UpdateState(CommandStates state, params object[] parameters);

        /// <summary>
        /// Converts command parameter to specified type.
        /// </summary>
        /// <typeparam name="T">Type.</typeparam>
        /// <returns>Converted parameter.</returns>
        T ParamsAs<T>();
    } 
    #endregion    
}
