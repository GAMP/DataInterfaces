using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IntegrationLib;
using NetLib;
using SharedLib;
using SharedLib.Dispatcher;
using SharedLib.Logging;
using System.Runtime.Serialization;

namespace ServerService
{
    #region OBSOLETE

    #region HOSTEVENTARGS
    [Obsolete()]
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

        #region OVERRIDES
        public override string ToString()
        {
            return String.Format("Host {0} event {1}", this.Host.HostName, this.Type);
        }
        #endregion
    }
    #endregion

    #region USERSTATEEVENTARGS
    [Obsolete()]
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

        #region OVERRIDES
        public override string ToString()
        {
            return String.Format("User Id:{0} New State {1} Old State: {2}", this.UserId, this.NewState, this.OldState);
        }
        #endregion
    }
    #endregion

    #endregion

    #region BASE ABSTRACT

    #region UserIdEventArgsBase
    [Serializable()]
    [DataContract()]
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
        [DataMember()]
        public int UserId
        {
            get;
            protected set;
        }

        #endregion
    }
    #endregion

    #region HostIdArgs
    [Serializable()]
    [DataContract()]
    public abstract class HostIdArgs : EventArgs
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
        [DataMember()]
        public int HostId
        {
            get;
            protected set;
        }
        #endregion
    }
    #endregion

    #endregion

    #region RESERVATIONEVENTARGS
    [Serializable()]
    public class ReservationEventArgs : EventArgs
    {
        #region CONSTRUCTOR
        public ReservationEventArgs(ILicenseReservation reservation, bool released)
        {
            if (reservation == null)
                throw new ArgumentNullException("reservation");

            this.Released = released;
            this.Reservation = reservation;

        }
        #endregion

        #region PROPERTIES

        [DataMember()]
        public bool Released
        {
            get;
            private set;
        }

        [DataMember()]
        public ILicenseReservation Reservation
        {
            get;
            private set;
        }

        #endregion
    }
    #endregion

    #region USERPROFILECHANGEEVENTARGS
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

        #region OVERRIDES
        public override string ToString()
        {
            return String.Format("USERID:{0} TYPE:{1}", this.UserId, this.Type);
        }
        #endregion
    }
    #endregion

    #region USERRENAMEDEVENTARGS
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

    #region USEREMAILCHANGEDEVENTARGS
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

    #region USERPASSWORDCHANGEDEVENTARGS
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

    #region USERGROUPCHANGEDEVENTARGS
    [Serializable()]
    public class UserGroupChangedEventArgs : UserProfileChangeEventArgs
    {
        #region CONSTRUCTOR
        public UserGroupChangedEventArgs(int userId, int? oldGroupId, int? newGroupId)
            : base(userId, UserChangeType.UserGroup)
        {
            this.OldGroupId = oldGroupId;
            this.NewGroupId = newGroupId;
        }
        #endregion

        #region PROPERTIES

        public int? OldGroupId
        {
            get;
            protected set;
        }

        public int? NewGroupId
        {
            get;
            protected set;
        }

        #endregion
    }
    #endregion

    #region USERROLECHANGEDEVENTARGS
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

    #region USERENABLEDCHANGEDEVENTARGS
    [Serializable()]
    public class UserEnabledChangedEventArgs : UserProfileChangeEventArgs
    {
        #region CONSTRUCTOR
        public UserEnabledChangedEventArgs(int userId, bool disabled)
            : base(userId, UserChangeType.Enabled)
        {
            this.Disabled = disabled;
        }
        #endregion

        #region PROPERTIES
        public bool Disabled
        {
            get;
            protected set;
        }

        #endregion
    }
    #endregion

    #region USERPICTURECHANGEDEVENTARGS
    [Serializable()]
    public class UserPictureChangedEventArgs : UserProfileChangeEventArgs
    {
        #region CONSTRUCTOR
        public UserPictureChangedEventArgs(int userId, byte[] oldPicture, byte[] newPicture)
            : base(userId, UserChangeType.Picture)
        {
            this.OldPicture = oldPicture;
            this.NewPicture = newPicture;
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets old picture.
        /// </summary>
        public byte[] OldPicture
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets new picture.
        /// </summary>
        public byte[] NewPicture
        {
            get;
            protected set;
        }

        #endregion
    }
    #endregion

    #region HOSTIDEVENTARGS
    [Serializable()]
    public class HostIdEventArgs : HostIdArgs
    {
        #region CONSTRUCTOR
        public HostIdEventArgs(int hostId, HostEventType type, object parameters)
            : base(hostId)
        {
            this.Type = type;
            this.Parameters = parameters;
        }

        public HostIdEventArgs(int hostId, HostEventType type)
            : this(hostId, type, null)
        { }
        #endregion

        #region PROPERTIES
        /// <summary>
        /// Gets type.
        /// </summary>
        public HostEventType Type
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets parameters.
        /// </summary>
        public object Parameters
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets parameters as array.
        /// </summary>
        public object[] ParametersArray
        {
            get
            {
                return this.Parameters as object[];
            }
        }
        #endregion
    }
    #endregion

    #region HOSTPROPERTIESCHANGEDEVENTARGS
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
        public HostPropertiesChangedEventArgs(int hostId, HostPropertyType type, object value)
            : base(hostId)
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
            get
            {
                if (this.properties == null)
                    this.properties = new Dictionary<HostPropertyType, object>();
                return this.properties;
            }
            private set
            {
                this.properties = value;
            }
        }

        #endregion

        #region FUNCTIONS

        /// <summary>
        /// Gets if specified property exists.
        /// </summary>
        /// <param name="type">Property type.</param>
        /// <returns>True if exists, otherwise false.</returns>
        public bool HasProperty(HostPropertyType type)
        {
            return this.Properties.ContainsKey(type);
        }

        /// <summary>
        /// Gets the spcecified property.
        /// </summary>
        /// <typeparam name="T">Object type of the property.</typeparam>
        /// <param name="type">HostPropertyType.</param>
        /// <returns>Property value.</returns>
        public T GetProperty<T>(HostPropertyType type)
        {
            return (T)this.Properties[type];
        }

        #endregion
    }
    #endregion

    #region USERSTATECHANGEEVENTARGS
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

        #region OVERRIDES
        public override string ToString()
        {
            return String.Format("User Id:{0} New State {1} Old State: {2}", this.UserId, this.NewState, this.OldState);
        }
        #endregion
    }
    #endregion

    #region LOGCHANGEEVENTARGS
    public class LogChangeEventArgs
    {
    }
    #endregion

    #region USERSESSIONCHNAGEDEVENTARGS
    public class UserSessionChnagedEventArgs : EventArgs
    {
        public int UserId
        {
            get;
            protected set;
        }

        public int HostId
        {
            get;
            protected set;
        }
    }
    #endregion    
}
