using System;
using SharedLib.Dispatcher;
namespace SharedLib.Commands
{
    #region Delegates
    /// <summary>
    /// Command state change event.
    /// </summary>
    /// <param name="sender">Command object that raised the event.</param>
    /// <param name="state">New Command state.</param>
    /// <param name="resstates">Reponse states of this command.</param>
    /// <param name="paramarray">New paramaters array for this command.</param>
    public delegate void StateChangeDelegate(IDispatcherCommand sender, CommandStates state, CommandStates resstates, params Object[] paramarray);
    #endregion

    #region IExecutionCommand
    public interface IExecutionCommand
    {

    } 
    #endregion

    #region IDispatcherCommand
    /// <summary>
    /// IDispatcherCommand command interface.
    /// </summary>
    public interface IDispatcherCommand : IExecutionCommand
    {
        int Id { get; set; }
        int RequestID { get; set; }
        IMessageDispatcher Dispatcher { get; set; }
        bool NeedsResponse { get; }
        IOperation Operation { get; set; }
        object Params { get; set; }
        object[] ParamsArray { get; }
        RequestsType RequestType { get; set; }
        CommandStates ResponseStates { get; set; }
        CommandStates State { get; set; }
        event StateChangeDelegate StateChange;
        CommandType Type { get; set; }
        void UpdateState(CommandStates state, params object[] paramarray);
        void UpdateState(CommandStates state, CommandStates resstates, params object[] paramarray);
        int SourceID { get; set; }
        int DestinationID { get; set; }
    } 
    #endregion    
}
