using SharedLib.Commands;
using SharedLib.Dispatcher.Exceptions;
using System;

namespace SharedLib.Dispatcher
{
    /// <summary>
    /// Dispatcher exception event args.
    /// </summary>
    public class DispatcherExceptionEventArgs : EventArgs
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="command"></param>
        public DispatcherExceptionEventArgs(DispatcherException exception, IDispatcherCommand command = default)
        {
            Exception = exception ?? throw new ArgumentNullException(nameof(exception));
            Command = command;
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets dispatcher exception.
        /// </summary>
        public DispatcherException Exception
        {
            get; protected set;
        }

        /// <summary>
        /// Gets optional command associated with exception event.
        /// </summary>
        public IDispatcherCommand Command
        {
            get; protected set;
        }

        #endregion
    }
}
