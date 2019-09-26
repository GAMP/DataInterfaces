using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharedLib
{
    #region OBSOLETE

    #region ContainerItemEventArgs
    [Serializable()]
    public class ContainerItemEventArgs : EventArgs
    {
        #region CONSTRUCTOR

        public ContainerItemEventArgs(ContainerItemEventType action)
        {
            Action = action;
        }

        public ContainerItemEventArgs(int containerId, IEnumerable<object> itemsList, ContainerItemEventType action) : this(action)
        {
            NewItems = itemsList;
            ContainerID = containerId;
        }

        public ContainerItemEventArgs(int containerId, IEnumerable<object> newItems, IEnumerable<object> oldItems, ContainerItemEventType action) : this(containerId, newItems, action)
        {
            OldItems = oldItems;
        }

        #endregion

        #region FIELDS
        private ContainerItemEventType action;
        private IEnumerable<object> newItems, oldItems;
        private int containerId;
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets the container id that raised the event.
        /// </summary>
        public int ContainerID
        {
            get { return containerId; }
            protected set { containerId = value; }
        }

        /// <summary>
        /// Gets the type of the event.
        /// </summary>
        public ContainerItemEventType Action
        {
            get { return action; }
            protected set { action = value; }
        }

        /// <summary>
        /// Gets the list of new items affected by this event.
        /// </summary>
        public IEnumerable<object> NewItems
        {
            get
            {
                if (newItems == null)
                {
                    newItems = new List<object>();
                }
                return newItems;
            }
            protected set { newItems = value; }
        }

        /// <summary>
        /// Gets the list of olde items affected by this event.
        /// </summary>
        public IEnumerable<object> OldItems
        {
            get
            {
                if (oldItems == null)
                {
                    oldItems = new List<object>();
                }
                return oldItems;
            }
            protected set { oldItems = value; }
        }

        #endregion

        #region OVERRIDES

        public override string ToString()
        {
            try
            {
                StringBuilder builder = new StringBuilder();
                builder.AppendLine(String.Format("Event Type:{0}", Action));
                builder.AppendLine(String.Format("New Items Count:{0}", NewItems.Count()));
                foreach (var item in NewItems)
                {
                    builder.AppendLine(item.ToString());
                }
                builder.AppendLine(String.Format("Old Items Count:{0}", OldItems.Count()));
                foreach (var item in OldItems)
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

    #endregion

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
        public MessageLogEventArgs(string message, string endpoint, EventTypes type, Exception exception) :
            this(message)
        {
            Endpoint = endpoint;
            EventType = type;
            Exception = exception;
            Time = InternalDate.Now;
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
