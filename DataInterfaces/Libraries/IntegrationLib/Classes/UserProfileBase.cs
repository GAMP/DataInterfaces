using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using SharedLib;
using SharedLib.User;

namespace IntegrationLib
{
    #region UserProfileBase
    /// <summary>
    /// Base user profile class.
    /// </summary>
    [Serializable()]
    [DataContract()]
    public class UserProfileBase : ItemObject, IUserProfile
    {
        #region FILEDS
        protected string
            userName = String.Empty,
            firstName = String.Empty,
            lastName = String.Empty,
            country = String.Empty,
            email = String.Empty,
            phone = String.Empty,
            mobilePhone = String.Empty,
            address = String.Empty,
            city = String.Empty,
            postCode = String.Empty,
            groupName = String.Empty;
        protected int
            groupId;
        protected DateTime
            birthDate,
            registered;
        protected UserRoles role;
        protected Sex sex= Sex.Male;
        protected bool isEnabled=true;
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets or sets username.
        /// </summary>
        [DataMember()]
        public virtual string UserName
        {
            get { return this.userName; }
            set
            {
                this.userName = value;
                this.RaisePropertyChanged("UserName");
            }
        }

        /// <summary>
        /// Gets or sets users first name.
        /// </summary>
        [DataMember()]
        public virtual string FirstName
        {
            get { return this.firstName; }
            set
            {
                this.firstName = value;
                this.RaisePropertyChanged("FirstName");
            }
        }

        /// <summary>
        /// Gets or sets users last name.
        /// </summary>
        [DataMember()]
        public virtual string LastName
        {
            get { return this.lastName; }
            set
            {
                this.lastName = value;
                this.RaisePropertyChanged("LastName");
            }
        }

        /// <summary>
        /// Gets or sets users birth date.
        /// </summary>
        [DataMember()]
        public virtual DateTime BirthDate
        {
            get { return this.birthDate; }
            set
            {
                this.birthDate = value;
                this.RaisePropertyChanged("BirthDate");
            }
        }

        /// <summary>
        /// Gets or sets user registration date.
        /// </summary>
        [DataMember()]
        public virtual DateTime Registered
        {
            get { return this.registered; }
            set
            {
                this.registered = value;
                this.RaisePropertyChanged("Registered");
            }
        }

        /// <summary>
        /// Gets or sets users city.
        /// </summary>
        [DataMember()]
        public virtual string City
        {
            get { return this.city; }
            set
            {
                this.city = value;
                this.RaisePropertyChanged("City");
            }
        }

        /// <summary>
        /// Gets or sets users address.
        /// </summary>
        [DataMember()]
        public virtual string Address
        {
            get { return this.address; }
            set
            {
                this.address = value;
                this.RaisePropertyChanged("Address");
            }
        }

        /// <summary>
        /// Gets or sets users group id.
        /// </summary>
        [DataMember()]
        public virtual int GroupId
        {
            get { return this.groupId; }
            set
            {
                this.groupId = value;
                this.RaisePropertyChanged("GroupId");
            }
        }

        /// <summary>
        /// Gets or sets users group name.
        /// </summary>
        public virtual string GroupName
        {
            get { return this.groupName; }
            set
            {
                this.groupName = value;
                this.RaisePropertyChanged("GroupName");
            }
        }

        /// <summary>
        /// Gets or sets users country string.
        /// </summary>
        [DataMember()]
        public virtual string Country
        {
            get { return this.country; }
            set
            {
                this.country = value;
                this.RaisePropertyChanged("Country");
            }
        }

        /// <summary>
        /// Gets or sets users email address.
        /// </summary>
        [DataMember()]
        public virtual string Email
        {
            get { return this.email; }
            set
            {
                this.email = value;
                this.RaisePropertyChanged("Email");
            }
        }

        /// <summary>
        /// Gets or sets users phone number.
        /// </summary>
        [DataMember()]
        public virtual string Phone
        {
            get { return this.phone; }
            set
            {
                this.phone = value;
                this.RaisePropertyChanged("Phone");
            }
        }

        /// <summary>
        /// Gets or sets users mobile phone number.
        /// </summary>
        [DataMember()]
        public virtual string MobilePhone
        {
            get { return this.mobilePhone; }
            set
            {
                this.mobilePhone = value;
                this.RaisePropertyChanged("MobilePhone");
            }
        }

        /// <summary>
        /// Gets or sets users post code.
        /// </summary>
        [DataMember()]
        public virtual string PostCode
        {
            get { return this.postCode; }
            set
            {
                this.postCode = value;
                this.RaisePropertyChanged("PostCode");
            }
        }

        /// <summary>
        /// Gets or sets users sex.
        /// </summary>
        [DataMember()]
        public virtual Sex Sex
        {
            get { return this.sex; }
            set
            {
                this.sex = value;
                this.RaisePropertyChanged("Sex");
            }
        }

        /// <summary>
        /// Gets or sets user role.
        /// </summary>
        [DataMember()]
        public virtual UserRoles Role
        {
            get { return this.role; }
            set
            {
                this.role = value;
                this.RaisePropertyChanged("Role");
            }
        }

        /// <summary>
        /// When ovveriden indicates if user is administrator [Operator].
        /// </summary>
        public virtual bool IsAdmin
        {
            get { return this.Role == UserRoles.Operator; }
            set {}
        }

        /// <summary>
        /// When ovveriden indicates if user is guest.
        /// </summary>
        public virtual bool IsGuest
        {
            get { return this.Role == UserRoles.Guest; }
            set {}
        }

        /// <summary>
        /// Gets or sets if user profile is enabled.
        /// </summary>
        [DataMember()]
        public virtual bool IsEnabled
        {
            get { return this.isEnabled; }
            set
            {
                this.isEnabled = value;
                this.RaisePropertyChanged("IsEnabled");
            }
        }       

        #endregion

        #region FUNCTIONS
        /// <summary>
        /// Reset profile to default values.
        /// </summary>
        public virtual void Reset()
        {
            this.Id = 0;
            this.Address = string.Empty;
            this.BirthDate = DateTime.MinValue;
            this.City = string.Empty;
            this.Country = string.Empty;
            this.Email = string.Empty;
            this.FirstName = string.Empty;
            this.LastName = string.Empty;
            this.MobilePhone = string.Empty;
            this.Phone = string.Empty;
            this.PostCode = string.Empty;
            this.Sex = SharedLib.Sex.Unspecified;
            this.Role = UserRoles.None;
            this.UserName = string.Empty;
            this.IsEnabled = false;
        }
        #endregion        
    }
    #endregion

    #region IntegrationUserProfile

    /// <summary>
    /// User profile class used for integration plugins.
    /// </summary>
    [Serializable()]
    [DataContract()]
    public class IntegrationUserProfile : UserProfileBase
    {
        #region Fileds
        protected IUserTimeStatus timeStatus;
        protected bool isGuest, isAdmin;
        #endregion

        #region Properties

        /// <summary>
        /// Gets the time status information for the user profile.
        /// </summary>
        [DataMember()]
        IUserTimeStatus TimeStatus
        {
            get { return this.timeStatus; }
        }

        public override bool IsAdmin
        {
            get
            {
                return this.isAdmin;
            }
            set
            {
                this.isAdmin = value;
                this.RaisePropertyChanged("IsAdmin");
            }
        }

        public override bool IsGuest
        {
            get
            {
                return this.isGuest;
            }
            set
            {
                this.isGuest = value;
                this.RaisePropertyChanged("IsGuest");
            }
        }

        #endregion
    }

    #endregion
}
