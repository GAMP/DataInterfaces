using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharedLib.Applications;
using SharedLib.Logging;

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
        #region Constructor

        public ShutDownEventArgs(bool restarting = false, bool isCrashed = false)
        {
            this.IsRestarting = restarting;
            this.IsCrashed = isCrashed;
        }

        #endregion

        #region Properties

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

    #region LogEventArgs
    public class LogEventArgs : EventArgs
    {
        #region Constructor
        /// <summary>
        /// Creates new LogEventArgs instance.
        /// </summary>
        /// <param name="message">Log Message.</param>
        /// <param name="sucess">Storage add sucess.</param>
        public LogEventArgs(ILogMessage message, bool sucess = true)
        {
            #region Validation
            if (message == null)
                throw new ArgumentNullException("Message", "Log message may not be null");
            #endregion

            this.Message = message;
            this.Sucess = sucess;
        }
        #endregion

        #region Properties

        /// <summary>
        /// Gets the log message.
        /// </summary>
        public ILogMessage Message
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets if message was added sucessfully to log storage.
        /// </summary>
        public bool Sucess
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
        #region Constructor
        
        public MaintenanceEventArgs(bool enabled)
        {
            this.IsEnabled = enabled;
        }       

        #endregion

        #region Properties
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

    #region ContainerChangedEventArgs
    /// <summary>
    /// Container change event arguments.
    /// </summary>
    [Serializable()]
    public class ContainerChangedEventArgs : EventArgs
    {
        #region CONSTRUCTOR
        public ContainerChangedEventArgs(IApplicationContainer oldContainer, IApplicationContainer newContainer)
        {
            this.OldContainer = oldContainer;
            this.NewContainer = newContainer;
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets the instance of the new Application Container.
        /// <remarks>Can be equal to null.</remarks>
        /// </summary>
        public IApplicationContainer NewContainer
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets the instance of the old Application Container.
        /// <remarks>Will be null if container set for the fisrt time.</remarks>
        /// </summary>
        public IApplicationContainer OldContainer
        {
            get;
            protected set;
        }

        #endregion
    }
    #endregion

    #region ContainerItemEventArgs
    [Serializable()]
    public class ContainerItemEventArgs : EventArgs
    {
        #region CONSTRUCTOR

        public ContainerItemEventArgs(ContainerItemEventType action)
        {
            this.Action = action;
        }

        public ContainerItemEventArgs(int containerId, IEnumerable<object> itemsList, ContainerItemEventType action):this(action)
        {
            this.NewItems = itemsList;
            this.ContainerID = containerId;
        }

        public ContainerItemEventArgs(int containerId, IEnumerable<object> newItems, IEnumerable<object> oldItems, ContainerItemEventType action):this(containerId,newItems,action)
        {
            this.OldItems = oldItems;
        }

        #endregion

        #region FIELDS
        private ContainerItemEventType action;
        private IEnumerable<object> newItems,oldItems;
        private int containerId;
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets the container id that raised the event.
        /// </summary>
        public int ContainerID
        {
            get { return this.containerId; }
            protected set { this.containerId = value; }
        }

        /// <summary>
        /// Gets the type of the event.
        /// </summary>
        public ContainerItemEventType Action
        {
            get { return this.action; }
            protected set { this.action = value; }
        }

        /// <summary>
        /// Gets the list of new items affected by this event.
        /// </summary>
        public IEnumerable<object> NewItems
        {
            get
            {
                if (this.newItems == null)
                {
                    this.newItems = new List<object>();
                }
                return this.newItems;
            }
            protected set { this.newItems = value; }
        }

        /// <summary>
        /// Gets the list of olde items affected by this event.
        /// </summary>
        public IEnumerable<object> OldItems
        {
            get
            {
                if (this.oldItems == null)
                {
                    this.oldItems = new List<object>();
                }
                return this.oldItems;
            }
            protected set { this.oldItems = value; }
        }

        #endregion

        #region OVERRIDES

        public override string ToString()
        {
            try
            {
                StringBuilder builder = new StringBuilder();
                builder.AppendLine(String.Format("Event Type:{0}", this.Action));
                builder.AppendLine(String.Format("New Items Count:{0}", this.NewItems.Count()));
                foreach (var item in this.NewItems)
                {
                    builder.AppendLine(item.ToString());
                }
                builder.AppendLine(String.Format("Old Items Count:{0}", this.OldItems.Count()));
                foreach (var item in this.OldItems)
                {
                    builder.AppendLine(item.ToString());
                }
                return builder.ToString();
            }
            catch
            {
                return base.ToString();
            }
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
            this.Current = current;
            this.Previous = previous;
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

    #region CurrentChangedEventArgs
    /// <summary>
    /// Generic current changed event args.
    /// </summary>
    /// <typeparam name="T">Item type.</typeparam>
    public class CurrentChangedEventArgs<T> : SelectedChangeEventArgs<T>
    {
        #region CONSTRUCTOR

        protected CurrentChangedEventArgs() : base()
        {
        }

        public CurrentChangedEventArgs(T current, T previous) : base(current, previous)
        {
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
        }

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="endpoint">Endpoint.</param>
        /// <param name="type">Event type.</param>
        /// <param name="exception">Exception.</param>
        public MessageLogEventArgs(string message, string endpoint, EventTypes type, Exception exception):
            this(message)
        {
            this.Endpoint = endpoint;
            this.EventType = type;
            this.Exception = exception;
            this.Time = InternalDate.Now;
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
        public EventTypes EventType
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
