using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharedLib.Applications;
using SharedLib.Logging;

namespace SharedLib
{
    #region BaseEventArgs
    [Serializable()]
    public class BaseEventArgs : EventArgs
    {
        #region Constructor

        public BaseEventArgs()
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets if the event should be canceled.
        /// </summary>
        public bool Cancel
        {
            get;
            set;
        }

        #endregion
    }
    #endregion

    #region StartUpEventArgs
    [Serializable()]
    public class StartUpEventArgs : EventArgs
    {

    }
    #endregion

    #region ShutDownEventArgs
    public class ShutDownEventArgs : BaseEventArgs
    {
        #region Constructor

        public ShutDownEventArgs(bool restarting = false, bool isCrashed = false)
        {
            this.IsRestarting = restarting;
            this.IsCrashed = isCrashed;
        }

        #endregion

        #region Fields
        private bool isRestarting, crashed;
        #endregion        

        #region Properties

        /// <summary>
        /// Gets if the client is restarting.
        /// </summary>
        public bool IsRestarting
        {
            get { return this.isRestarting; }
            protected set { this.isRestarting = value; }
        }

        /// <summary>
        /// Indicates that event occurred due an application crash.
        /// </summary>
        public bool IsCrashed
        {
            get { return this.crashed; }
            protected set { this.crashed = value; }
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
        #region Constructor
        public ContainerChangedEventArgs(IApplicationContainer oldContainer, IApplicationContainer newContainer)
        {
            this.OldContainer = oldContainer;
            this.NewContainer = newContainer;
        }
        #endregion

        #region Properties

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
}
