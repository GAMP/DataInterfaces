using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IntegrationLib;
using NetLib;
using SharedLib;
using SharedLib.Dispatcher;
using SharedLib.Logging;

namespace ServerService
{
    #region HostEventArgs
    public class HostEventArgs : EventArgs
    {
        #region Constructor
        public HostEventArgs(IHostEntry host, HostEventType type)
        {
            this.Host = host;
            this.Type = type;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the host of event.
        /// </summary>
        public IHostEntry Host
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets the type of event.
        /// </summary>
        public HostEventType Type
        {
            get;
            protected set;
        }
        #endregion

        #region Ovverides
        public override string ToString()
        {
            return String.Format("Host {0} event {1}", this.Host.HostName, this.Type);
        }
        #endregion
    }
    #endregion

    #region UserStateEventArgs
    public class UserStateEventArgs : UserIdEventArgsBase
    {
        #region CONSTRUCTOR
        public UserStateEventArgs(int userId, LoginState newState, LoginState oldState, IHostEntry host, IMessageDispatcher dispatcher)
            : base(userId)
        {
            #region VALIDATION
            if (host == null)
                throw new ArgumentNullException("Host", "Host may not be null");
            #endregion

            this.NewState = newState;
            this.OldState = oldState;
            this.HostEntry = host;
            this.Dispatcher = dispatcher;
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets new user state.
        /// </summary>
        public LoginState NewState
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets old user state.
        /// </summary>
        public LoginState OldState
        {
            get;
            protected set;
        }

        public IHostEntry HostEntry
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets message dispatcher.
        /// </summary>
        public IMessageDispatcher Dispatcher
        {
            get;
            protected set;
        }

        #endregion

        #region OVVERIDES
        public override string ToString()
        {
            return String.Format("User Id:{0} New State {1} Old State: {2}", this.UserId, this.NewState, this.OldState);
        }
        #endregion
    }
    #endregion

    #region ReservationEventArgs
    [Serializable()]
    public class ReservationEventArgs : EventArgs
    {
        #region CONSTRUCTOR
        public ReservationEventArgs(ILicenseReservation reservation, bool released)
        {
            if (reservation != null)
            {
                this.Released = released;
                this.Reservation = reservation;
            }
            else
            {
                throw new Exception("Reservation cannot be null.");
            }
        }
        #endregion

        #region PROPERTIES

        public bool Released
        {
            get;
            private set;
        }

        public ILicenseReservation Reservation
        {
            get;
            private set;
        }

        #endregion
    }
    #endregion

    #region UserIdEventArgsBase
    [Serializable()]
    public abstract class UserIdEventArgsBase : EventArgs
    {
        #region CONSTRUCTOR
        public UserIdEventArgsBase(int userId)
        {
            this.UserId = userId;
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets user id.
        /// </summary>
        public int UserId
        {
            get;
            protected set;
        }

        #endregion
    }
    #endregion

    #region UserChangeEventArgs
    [Serializable()]
    public class UserProfileChangeEventArgs : UserIdEventArgsBase
    {
        #region CONSTRUCTOR
        public UserProfileChangeEventArgs(int userId, UserChangeType changeType)
            : base(userId)
        {
            this.Type = changeType;
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets change type.
        /// </summary>
        public UserChangeType Type
        {
            get;
            protected set;
        }

        #endregion

        #region OVVERIDES
        public override string ToString()
        {
            return String.Format("USERID:{0} TYPE:{1}", this.UserId, this.Type);
        }
        #endregion
    }
    #endregion

    #region UserRenamedEventArgs
    [Serializable()]
    public class UserRenamedEventArgs : UserProfileChangeEventArgs
    {
        #region CONSTRUCTOR
        public UserRenamedEventArgs(int userId, string oldUserName, string newUserName)
            : base(userId, UserChangeType.UserName)
        {
            #region VALIDATION

            if (String.IsNullOrWhiteSpace(oldUserName))
                throw new ArgumentNullException("OldUserName", "Old user name may not be null or empty");

            if (String.IsNullOrWhiteSpace(newUserName))
                throw new ArgumentNullException("NewUserName", "New user name may not be null or empty");

            #endregion

            this.OldUserName = oldUserName;
            this.NewUserName = newUserName;
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets new user name.
        /// </summary>
        public string NewUserName
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets old user name.
        /// </summary>
        public string OldUserName
        {
            get;
            protected set;
        }

        #endregion
    }
    #endregion

    #region UserEmailChangedEventArgs
    [Serializable()]
    public class UserEmailChangedEventArgs : UserProfileChangeEventArgs
    {
        #region CONSTRUCTOR
        public UserEmailChangedEventArgs(int userId, string oldEmail, string newEmail)
            : base(userId, UserChangeType.Email)
        {
            this.NewEmail = newEmail;
            this.OldEmail = oldEmail;
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets new email value.
        /// </summary>
        public string NewEmail
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets old email value.
        /// </summary>
        public string OldEmail
        {
            get;
            protected set;
        }

        #endregion
    }
    #endregion

    #region UserPasswordChangedEventArgs
    [Serializable()]
    public class UserPasswordChangedEventArgs : UserProfileChangeEventArgs
    {
        #region CONSTRUCTOR
        public UserPasswordChangedEventArgs(int userId, string newPassword)
            : base(userId, UserChangeType.Password)
        {
            this.NewPassword = newPassword;
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets new password value.
        /// </summary>
        public string NewPassword
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets if user password equals to null or empty thus causing a password reset.
        /// </summary>
        public bool IsReset
        {
            get { return String.IsNullOrWhiteSpace(this.NewPassword); }
        }

        #endregion
    }
    #endregion

    #region UserGroupChangedEventArgs
    [Serializable()]
    public class UserGroupChangedEventArgs : UserProfileChangeEventArgs
    {
        #region CONSTRUCTOR
        public UserGroupChangedEventArgs(int userId, int oldGroupId, int newGroupId)
            : base(userId, UserChangeType.UserGroup)
        {
            this.OldGroupId = oldGroupId;
            this.NewGroupId = newGroupId;
        }
        #endregion

        #region PROPERTIES
        public int OldGroupId
        {
            get;
            protected set;
        }

        public int NewGroupId
        {
            get;
            protected set;
        }
        #endregion
    }
    #endregion

    #region UserRoleChangedEventArgs
    [Serializable()]
    public class UserRoleChangedEventArgs : UserProfileChangeEventArgs
    {
        #region CONSTRUCTOR
        public UserRoleChangedEventArgs(int userId, UserRoles oldRole, UserRoles newRole)
            : base(userId, UserChangeType.Role)
        {
            this.OldRole = oldRole;
            this.NewRole = newRole;
        }
        #endregion

        #region PROPERTIES
        public UserRoles OldRole
        {
            get;
            protected set;
        }

        public UserRoles NewRole
        {
            get;
            protected set;
        }
        #endregion
    }
    #endregion

    #region UserRoleChangedEventArgs
    [Serializable()]
    public class UserEnabledChangedEventArgs : UserProfileChangeEventArgs
    {
        #region CONSTRUCTOR
        public UserEnabledChangedEventArgs(int userId, bool enabled)
            : base(userId, UserChangeType.Enabled)
        {
            this.Enabled = enabled;
        }
        #endregion

        #region PROPERTIES
        public bool Enabled
        {
            get;
            protected set;
        }

        #endregion
    }
    #endregion

    #region HostIdArgs
    [Serializable()]
    public class HostIdArgs : EventArgs
    {
        #region CONSTRUCTOR
        public HostIdArgs(int hostId)
            : base()
        {
            this.HostId = hostId;
        }
        #endregion

        #region PROPERTIES
        /// <summary>
        /// Gets host id.
        /// </summary>
        public int HostId
        {
            get;
            protected set;
        }
        #endregion
    }
    #endregion

    #region HostIdEventArgs
    [Serializable()]
    public class HostIdEventArgs : HostIdArgs
    {
        public HostIdEventArgs(int hostId, HostEventType type, object parameters)
            : base(hostId)
        {
            this.Type = type;
            this.Parameters = parameters;
        }

        public HostIdEventArgs(int hostId, HostEventType type)
            : this(hostId, type, null)
        { }

        public HostEventType Type
        {
            get;
            private set;
        }

        public object Parameters
        {
            get;
            private set;
        }
    }
    #endregion

    #region HostPropertiesChangedEventArgs
    [Serializable()]
    public class HostPropertiesChangedEventArgs : HostIdArgs
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Single property change constructor.
        /// </summary>
        /// <param name="hostId">Host id.</param>
        /// <param name="type">Property type.</param>
        /// <param name="value">Property value.</param>
        public HostPropertiesChangedEventArgs(int hostId, HostPropertyType type, object value):base(hostId)
        {
            this.Properties = new Dictionary<HostPropertyType, object>();
            this.Properties.Add(type, value);

        }

        public HostPropertiesChangedEventArgs(int hostId, IDictionary<HostPropertyType, object> properties)
            : base(hostId)
        {
            this.Properties = properties;
        }

        #endregion

        #region FIELDS
        private IDictionary<HostPropertyType, object> properties;
        #endregion

        #region PROPERTIES
        /// <summary>
        /// Gets affected properties.
        /// </summary>
        public IDictionary<HostPropertyType, object> Properties
        {
            get { return this.properties; }
            private set { this.properties = value; }
        }
        #endregion

        #region FUNCTIONS

        public bool HasProperty(HostPropertyType type)
        {
            return this.Properties.ContainsKey(type);
        }

        public object GetProperty<T>(HostPropertyType type)
        {
            return (T)this.Properties[type];
        }

        #endregion
    }
    #endregion

    #region UserEnabledChangedEventArgs
    [Serializable()]
    public class UserStateChangeEventArgs : UserIdEventArgsBase
    {
        #region CONSTRUCTOR
        public UserStateChangeEventArgs(int userId, int hostId, LoginState newState, LoginState oldState)
            : base(userId)
        {
            this.NewState = newState;
            this.OldState = oldState;
            this.HostId = hostId;
        }
        #endregion

        #region PROPERTIES
        /// <summary>
        /// Gets new user state.
        /// </summary>
        public LoginState NewState
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets old user state.
        /// </summary>
        public LoginState OldState
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets host id.
        /// </summary>
        public int HostId
        {
            get;
            private set;
        }
        #endregion

        #region OVVERIDES
        public override string ToString()
        {
            return String.Format("User Id:{0} New State {1} Old State: {2}", this.UserId, this.NewState, this.OldState);
        }
        #endregion
    }
    #endregion

    #region LogChangeEventArgs
    [Serializable()]
    public class LogChangeEventArgs : EventArgs
    {
        #region CONSTRUCTOR
        public LogChangeEventArgs(DateTime trimTime)
        {
            this.IsTrim = true;
            this.Time = trimTime;
        }

        public LogChangeEventArgs(ILogMessage message)
            : this(DateTime.MinValue)
        {
            if (message == null)
                throw new ArgumentNullException();

            this.Message = message;
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets log message causing this event.
        /// </summary>
        public ILogMessage Message
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets trim time.
        /// </summary>
        public DateTime Time
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets if argumenets indicate log trim.
        /// </summary>
        public bool IsTrim
        {
            get;
            private set;
        }
        #endregion
    } 
    #endregion
}
