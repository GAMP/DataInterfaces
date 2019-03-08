using System;
using System.Collections.Generic;
using IntegrationLib;
using SharedLib;
using System.Runtime.Serialization;
using GizmoDALV2.DTO;

namespace ServerService
{
    #region BASE ABSTRACT

    #region USERIDEVENTARGSBASE
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

    #region HOSTIDARGS
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

    #region ORDEREVENTARGSBASE
    [Serializable()]
    [DataContract()]
    public abstract class OrderEventArgsBase : UserIdEventArgsBase
    {
        #region CONSTRUCTOR
        public OrderEventArgsBase(int userId, int orderId) : base(userId)
        {
            OrderId = orderId;
        }
        #endregion

        #region PROPERTIES

        [DataMember()]
        public int OrderId
        {
            get; protected set;
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
            this.Released = released;
            this.Reservation = reservation ?? throw new ArgumentNullException("reservation");
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
            NewPassword = newPassword;
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
            get { return string.IsNullOrWhiteSpace(NewPassword); }
        }

        #endregion
    }
    #endregion

    #region USERGROUPCHANGEDEVENTARGS
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

        /// <summary>
        /// Gets old user group id.
        /// </summary>
        public int OldGroupId
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets new user group id.
        /// </summary>
        public int NewGroupId
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
            Disabled = disabled;
        }

        public UserEnabledChangedEventArgs(int userId, bool disabled, DateTime? enableDate,DateTime? disabledDate)
         : base(userId, UserChangeType.Enabled)
        {
            Disabled = disabled;
            EnableDate = enableDate;
            DisabledDate = disabledDate;
        }

        #endregion

        #region FIELDS
        [OptionalField(VersionAdded =1)]
        private DateTime? enableDate;
        [OptionalField(VersionAdded = 1)]
        private DateTime? disabledDate;
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets if user is disabled.
        /// </summary>
        public bool Disabled
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets enable date.
        /// </summary>
        public DateTime? EnableDate
        {
            get { return enableDate; }
            protected set { enableDate = value; }
        }

        /// <summary>
        /// Gets disabled date.
        /// </summary>
        public DateTime? DisabledDate
        {
            get { return disabledDate; }
            protected set { disabledDate = value; }
        }

        #endregion
    }
    #endregion

    #region USERSMARTCARDCHANGEDEVENTARGS
    [Serializable()]
    public class UserSmartCardChangedEventArgs : UserProfileChangeEventArgs
    {
        #region CONSTRUCTOR
        public UserSmartCardChangedEventArgs(int userId, string smartCardUID)
            : base(userId, UserChangeType.SmartCardUID)
        {
            this.SmartCardUID = smartCardUID;
        }
        #endregion

        #region PROPERTIES
        public string SmartCardUID
        {
            get;
            protected set;
        }

        #endregion
    }
    #endregion

    #region USERENABLENEGATIVEBALANCEEVENTARGS
    [Serializable()]
    [DataContract()]
    public class UserEnableNegativeBalanceEventArgs : UserProfileChangeEventArgs
    {
        #region CONSTRUCTOR
        public UserEnableNegativeBalanceEventArgs(int userId, bool? enabled) : base(userId, UserChangeType.NegativBalanceEnabled)
        {
            this.Enabled = enabled;
        }
        #endregion

        #region PROPERTIES
        /// <summary>
        /// Gets if negative balance allowed for user.
        /// </summary>
        [DataMember()]
        public bool? Enabled
        {
            get; protected set;
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
    public class LogChangeEventArgs : EventArgs
    {
    }
    #endregion    

    #region USERBALANCEEVENTARGS
    [Serializable()]
    [DataContract()]
    public class UserBalanceEventArgs : UserIdEventArgsBase
    {
        #region CONSTRUCTOR
        public UserBalanceEventArgs(int userId, UserBalance balance) : base(userId)
        {
            if (balance == null)
                throw new ArgumentNullException(nameof(balance));

            this.Balance = balance;
        }
        #endregion

        #region PROPERTIES
        /// <summary>
        /// Gets balance.
        /// </summary>
        public UserBalance Balance
        {
            get; protected set;
        }
        #endregion
    }
    #endregion

    #region USERSESSIONCHANGEDEVENTARGS
    [Serializable()]
    [DataContract()]
    public class UserSessionChangedEventArgs : UserIdEventArgsBase
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance user session state change.
        /// </summary>
        /// <param name="userId">User id.</param>
        /// <param name="state">New state.</param>
        /// <param name="span">Span.</param>
        public UserSessionChangedEventArgs(int userId, int hostId, int slot, SessionState state, double span) : base(userId)
        {
            this.State = state;
            this.Span = span;
            this.Slot = slot;
            this.HostId = hostId;
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets new state.
        /// </summary>
        [DataMember()]
        public SessionState State
        {
            get; protected set;
        }

        /// <summary>
        /// Gets span.
        /// </summary>
        [DataMember()]
        public double Span
        {
            get; protected set;
        }

        /// <summary>
        /// Gets slot.
        /// </summary>
        [DataMember()]
        public int Slot
        {
            get; protected set;
        }

        /// <summary>
        /// Gets host id.
        /// </summary>
        public int HostId
        {
            get; protected set;
        }

        #endregion
    }
    #endregion

    #region USAGESESSIONCHANGEDEVENTARGS
    [Serializable()]
    [DataContract()]
    public class UsageSessionChangedEventArgs : UserIdEventArgsBase
    {
        #region CONSTRUCTOR
        public UsageSessionChangedEventArgs(int userId, UsageType usageType, string timeProduct) : base(userId)
        {
            this.CurrentTimeProduct = timeProduct;
            this.CurrentUsageType = usageType;
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets current time poroduct name.
        /// </summary>
        public string CurrentTimeProduct
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets current usage type.
        /// </summary>
        public UsageType CurrentUsageType
        {
            get;
            private set;
        }

        #endregion
    }
    #endregion

    #region USERPROFILEEVENTARGS
    /// <summary>
    /// User profile event arguments.
    /// </summary>
    [Serializable()]
    [DataContract()]
    public class UserProfileEventArgs : UserProfileChangeEventArgs
    {
        #region CONSTRUCTOR
        public UserProfileEventArgs(int userId, object userProfile, UserChangeType type) : base(userId, type)
        {
            if (userProfile == null)
                throw new ArgumentNullException(nameof(userProfile));

            this.UserProfile = userProfile;
        }
        #endregion

        #region FIELDS
        private object userProfile;
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets user profile.
        /// </summary>
        [DataMember()]
        public object UserProfile
        {
            get { return this.userProfile; }
            protected set { this.userProfile = value; }
        }

        #endregion
    }
    #endregion

    #region USERBALANCECLOSEEVENTARGS
    [Serializable()]
    [DataContract()]
    public class UserBalanceCloseEventArgs : UserIdEventArgsBase
    {
        #region CONSTRUCTOR
        public UserBalanceCloseEventArgs(int userId) : base(userId)
        { }
        #endregion
    }
    #endregion

    #region BILLINGOPTIONSCHANGEDEVENTARGS
    [Serializable()]
    [DataContract()]
    public class BillingOptionsChangedEventArgs : UserProfileChangeEventArgs
    {
        #region CONSTRUCTOR
        public BillingOptionsChangedEventArgs(int userId, BillingOption? options) : base(userId, UserChangeType.BillingOptions)
        {
            this.Options = options;
        }
        #endregion

        #region PROPERTIES
        /// <summary>
        /// Gets billing options.
        /// </summary>
        public BillingOption? Options
        {
            get; protected set;
        }
        #endregion
    }
    #endregion

    #region APPRATEDEVENTARGS
    [DataContract()]
    [Serializable()]
    public class AppRatedEventArgs : UserIdEventArgsBase
    {
        #region CONSTRUCTOR
        public AppRatedEventArgs(int userId, int appId, int userRating, int appRating, int count) : base(userId)
        {
            this.AppId = appId;
            this.UserRating = userRating;
            this.AppRating = appRating;
            this.RatesCount = count;
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets rated app id.
        /// </summary>
        [DataMember()]
        public int AppId
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets global average rating value.
        /// </summary>
        [DataMember()]
        public int AppRating
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets user rating value.
        /// </summary>
        [DataMember()]
        public int UserRating
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets total ratings count.
        /// </summary>
        [DataMember()]
        public int RatesCount
        {
            get;
            private set;
        }

        #endregion
    }
    #endregion

    #region APPSTATEVENTARGS
    [DataContract()]
    [Serializable()]
    public class AppStatEventArgs : UserIdEventArgsBase
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="userId">User id.</param>
        /// <param name="appId">App id.</param>
        /// <param name="appExeId">App exe id.</param>
        /// <param name="totalAppTime">Total app time.</param>
        /// <param name="totalAppExecutions">Total app executions.</param>
        /// <param name="totalAppExeTime">Total app exe time.</param>
        /// <param name="totalAppExeExecutions">Total app exe executions.</param>
        /// <param name="totalAppExeUserTime">Total app exe user time.</param>
        /// <param name="totalAppExeUserExectutions">Total app exe user executions.</param>
        public AppStatEventArgs(int userId,
            int appId,
            int appExeId,
            double totalAppTime,
            int totalAppExecutions,
            double totalAppExeTime,
            int totalAppExeExecutions,
            double totalAppExeUserTime,
            int totalAppExeUserExectutions) : base(userId)
        {
            this.AppId = appId;
            this.AppExeId = appExeId;

            this.TotalAppTime = totalAppTime;
            this.TotalAppExecutions = totalAppExecutions;

            this.TotalAppExeTime = totalAppExeTime;
            this.TotalAppExeExecutions = totalAppExeExecutions;

            this.TotalAppExeUserTime = totalAppExeUserTime;
            this.TotalAppExeUserExecutions = totalAppExeUserExectutions;
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets app id.
        /// </summary>
        [DataMember()]
        public int AppId
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets app exe id.
        /// </summary>
        [DataMember()]
        public int AppExeId
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets total app time.
        /// </summary>
        [DataMember()]
        public double TotalAppTime
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets total app executions.
        /// </summary>
        [DataMember()]
        public int TotalAppExecutions
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets total executable time.
        /// </summary>
        [DataMember()]
        public double TotalAppExeTime
        {
            get;
            private set;
        }

        /// <summary>
        /// Get total executions.
        /// </summary>
        [DataMember()]
        public int TotalAppExeExecutions
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets total executable user time.
        /// </summary>
        [DataMember()]
        public double TotalAppExeUserTime
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets total user executions.
        /// </summary>
        [DataMember()]
        public int TotalAppExeUserExecutions
        {
            get;
            private set;
        }

        #endregion
    }
    #endregion

    #region WAITINGLINEEVENTARGS
    [Serializable()]
    [DataContract()]
    public class WaitingLineEventArgs : EventArgs
    {
        #region CONSTRUCTOR

        public WaitingLineEventArgs(int? hostGroupId, IEnumerable<WaitingEntryInfo> activeEntries)
        {
            ActiveEntries = activeEntries ?? throw new ArgumentNullException(nameof(activeEntries));
            HostGroupId = hostGroupId;
        }

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets or sets host group id.
        /// </summary>
        [DataMember()]
        public int? HostGroupId
        {
            get;set;
        }

        /// <summary>
        /// Gets affected lines.
        /// </summary>
        [DataMember()]
        public IEnumerable<WaitingEntryInfo> ActiveEntries
        {
            get; set;
        }

        #endregion
    }
    #endregion

    #region ORDERSTATUSCHANGEEVENTARGS
    [Serializable()]
    [DataContract()]
    public class OrderStatusChangeEventArgs : OrderEventArgsBase
    {
        #region CONSTRUCTOR    
        public OrderStatusChangeEventArgs(int userId,
            int orderId,
            OrderStatus newStatus,
            OrderStatus? oldStatus) : base(userId, orderId)
        {
            OrderId = orderId;
            NewStatus = newStatus;
            OldStatus = oldStatus;
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets new status.
        /// </summary>
        [DataMember()]
        public OrderStatus NewStatus
        {
            get; set;
        }

        /// <summary>
        /// Gets old status.
        /// </summary>
        [DataMember()]
        public OrderStatus? OldStatus
        {
            get; set;
        }

        #endregion
    }
    #endregion

    #region ORDERINVOICEDEVENTARGS
    [Serializable()]
    [DataContract()]
    public class OrderInvoicedEventArgs : OrderEventArgsBase
    {
        #region CONSTRUCTOR
        public OrderInvoicedEventArgs(int orderId, int userId, int invoiceId) : base(userId, orderId)
        {
            InvoiceId = invoiceId;
        }
        #endregion

        #region PROPERTIES

        [DataMember()]
        public int InvoiceId
        {
            get; set;
        }

        #endregion
    }
    #endregion

    #region ORDERINVOICEPAYMENTEVENTARGS
    [Serializable()]
    [DataContract()]
    public class OrderInvoicePaymentEventArgs : OrderInvoicedEventArgs
    {
        #region CONSTRUCTOR
        public OrderInvoicePaymentEventArgs(int orderId,
            int userId,
            int invoiceId,
            int paymentMethodId,
            decimal amount,
            decimal outstanding) : base(orderId, userId, invoiceId)
        {
            Amount = amount;
            PaymentMethodId = paymentMethodId;
            Outstanding = outstanding;
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets payment method id.
        /// </summary>
        [DataMember()]
        public int? PaymentMethodId
        {
            get; protected set;
        }

        /// <summary>
        /// Gets payment amount.
        /// </summary>
        [DataMember()]
        public decimal Amount
        {
            get; set;
        }

        /// <summary>
        /// Get outstanding amount on invoice.
        /// </summary>
        [DataMember()]
        public decimal Outstanding
        {
            get; protected set;
        }

        #endregion
    }
    #endregion

    #region ORDERDELIVEREDARGS
    [Serializable()]
    [DataContract()]
    public class OrderDeliveredArgs : OrderEventArgsBase
    {
        #region CONSTRUCTOR
        public OrderDeliveredArgs(int userId, int orderId) : base(userId, orderId)
        {
        }
        #endregion

        #region PROPERTIES

        [DataMember()]
        public bool IsDelivered
        {
            get; set;
        }

        [DataMember()]
        public DateTime? DeliverTime
        {
            get; set;
        }

        [DataMember()]
        public IEnumerable<OrderLineState> States
        {
            get; set;
        }

        #endregion
    } 
    #endregion
}
