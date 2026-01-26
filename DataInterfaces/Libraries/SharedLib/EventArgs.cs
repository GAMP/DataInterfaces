using System;
using Gizmo.Web.Api.Models;

namespace SharedLib
{
    #region StartUpEventArgs
    [Serializable()]
    public class StartUpEventArgs : EventArgs
    {
    }
    #endregion

    #region ShutDownEventArgs
    public class ShutDownEventArgs : EventArgs
    {
        #region CONSTRUCTOR

        public ShutDownEventArgs(bool restarting = false, bool isCrashed = false)
        {
            IsRestarting = restarting;
            IsCrashed = isCrashed;
        }

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets if application is restarting.
        /// </summary>
        public bool IsRestarting
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets if application is sutting down due to a crash.
        /// </summary>
        public bool IsCrashed
        {
            get;
            protected set;
        }

        #endregion
    }
    #endregion

    #region MaintenanceEventArgs
    [Serializable()]
    public class MaintenanceEventArgs : EventArgs
    {
        #region CONSTRUCTOR

        public MaintenanceEventArgs(bool enabled)
        {
            IsEnabled = enabled;
        }

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets if maintenance mod is enabled.
        /// </summary>
        public bool IsEnabled
        {
            get;
            protected set;
        }

        #endregion
    }
    #endregion

    #region SelectedChangeEventArgs
    /// <summary>
    /// Generic selected changed event args.
    /// </summary>
    /// <typeparam name="T">Item type.</typeparam>
    public class SelectedChangeEventArgs<T> : EventArgs
    {
        #region CONSTRUCTOR

        protected SelectedChangeEventArgs()
        { }

        public SelectedChangeEventArgs(T current, T previous)
        {
            Current = current;
            Previous = previous;
        }

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets instance of current item.
        /// </summary>
        public T Current
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets instance of previous item.
        /// </summary>
        public T Previous
        {
            get;
            protected set;
        }

        #endregion
    }
    #endregion

    #region MessageLogEventArgs
    [Serializable()]
    public class MessageLogEventArgs : EventArgs
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="message">Message.</param>
        public MessageLogEventArgs(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
                throw new ArgumentNullException(nameof(message));

            Message = message;
        }

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="endpoint">Endpoint.</param>
        /// <param name="type">Event type.</param>
        /// <param name="exception">Exception.</param>
        public MessageLogEventArgs(string message, string endpoint, LogMessageType type, Exception exception) :
            this(message)
        {
            Endpoint = endpoint;
            EventType = type;
            Exception = exception;
            Time = DateTime.Now;
        }

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets message.
        /// </summary>
        public string Message
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets endpoint.
        /// </summary>
        public string Endpoint
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets event type.
        /// </summary>
        public LogMessageType EventType
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets exception.
        /// </summary>
        public Exception Exception
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets time.
        /// </summary>
        public DateTime Time
        {
            get;
            protected set;
        }

        #endregion
    }
    #endregion
}
