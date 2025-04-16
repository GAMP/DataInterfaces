using System;

namespace SharedLib.Commands
{
    #region CommandStates
    /// <summary>
    /// Represents a states of the commands.
    /// </summary>
    [Flags()]
    public enum CommandStates : uint
    {
        /// <summary>
        /// None state.
        /// <remarks >
        /// This should be set in responses if command not requires any callback.
        /// </remarks>
        /// </summary>
        None = 0,

        /// <summary>
        /// Command is not supported.
        /// </summary>
        NotSupported = 32,

        /// <summary>
        /// Invalid command parameters specified.
        /// <remarks>
        /// </remarks>
        /// </summary>
        InvalidParameters = 64,

        /// <summary>
        /// State should be set when request or response sending failed.
        /// </summary>
        SendFailed = 128,

        /// <summary>
        /// Occurs when command carries an operation or a state update and requested command is not present.
        /// </summary>
        RequestNotFound = 256,

        /// <summary>
        /// This state is set when operation exception is unhandled.
        /// </summary>
        UnhandledOperationException = 512,

        /// <summary>
        /// Occurs when command data is not recognized.
        /// </summary>
        Unrecognized = 1024,

        /// <summary>
        /// Command cannot execute due to authorization.
        /// </summary>
        UnAuthorized = 2048,

        /// <summary>
        /// All states flag.
        /// </summary>
        AllStates = 65535,
    }
    #endregion
}
