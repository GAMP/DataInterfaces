using System;
using System.Runtime.Serialization;
using SharedLib;
using SharedLib.User;

namespace IntegrationLib
{
    /// <summary>
    /// Base user profile class.
    /// </summary>
    [Serializable()]
    [DataContract()]
    public class UserProfileBase : ItemObject, IUserProfile
    {
        #region FIELDS
        protected string
            userName = string.Empty,
            firstName = string.Empty,
            lastName = string.Empty,
            country = string.Empty,
            email = string.Empty,
            phone = string.Empty,
            mobilePhone = string.Empty,
            address = string.Empty,
            city = string.Empty,
            postCode = string.Empty,
            groupName = string.Empty;
        protected int
            groupId;
        protected DateTime
            birthDate,
            registered;
        protected UserRoles role;
        protected Sex sex = Sex.Male;
        protected bool isEnabled = true;
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets or sets username.
        /// </summary>
        [DataMember()]
        public virtual string UserName
        {
            get { return userName; }
            set
            {
                userName = value;
                RaisePropertyChanged("UserName");
            }
        }

        /// <summary>
        /// Gets or sets users first name.
        /// </summary>
        [DataMember()]
        public virtual string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                RaisePropertyChanged("FirstName");
            }
        }

        /// <summary>
        /// Gets or sets users last name.
        /// </summary>
        [DataMember()]
        public virtual string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                RaisePropertyChanged("LastName");
            }
        }

        /// <summary>
        /// Gets or sets users birth date.
        /// </summary>
        [DataMember()]
        public virtual DateTime BirthDate
        {
            get { return birthDate; }
            set
            {
                birthDate = value;
                RaisePropertyChanged("BirthDate");
            }
        }

        /// <summary>
        /// Gets or sets user registration date.
        /// </summary>
        [DataMember()]
        public virtual DateTime Registered
        {
            get { return registered; }
            set
            {
                registered = value;
                RaisePropertyChanged("Registered");
            }
        }

        /// <summary>
        /// Gets or sets users city.
        /// </summary>
        [DataMember()]
        public virtual string City
        {
            get { return city; }
            set
            {
                city = value;
                RaisePropertyChanged("City");
            }
        }

        /// <summary>
        /// Gets or sets users address.
        /// </summary>
        [DataMember()]
        public virtual string Address
        {
            get { return address; }
            set
            {
                address = value;
                RaisePropertyChanged("Address");
            }
        }

        /// <summary>
        /// Gets or sets users group id.
        /// </summary>
        [DataMember()]
        public virtual int GroupId
        {
            get { return groupId; }
            set
            {
                groupId = value;
                RaisePropertyChanged("GroupId");
            }
        }

        /// <summary>
        /// Gets or sets users group name.
        /// </summary>
        public virtual string GroupName
        {
            get { return groupName; }
            set
            {
                groupName = value;
                RaisePropertyChanged("GroupName");
            }
        }

        /// <summary>
        /// Gets or sets users country string.
        /// </summary>
        [DataMember()]
        public virtual string Country
        {
            get { return country; }
            set
            {
                country = value;
                RaisePropertyChanged("Country");
            }
        }

        /// <summary>
        /// Gets or sets users email address.
        /// </summary>
        [DataMember()]
        public virtual string Email
        {
            get { return email; }
            set
            {
                email = value;
                RaisePropertyChanged("Email");
            }
        }

        /// <summary>
        /// Gets or sets users phone number.
        /// </summary>
        [DataMember()]
        public virtual string Phone
        {
            get { return phone; }
            set
            {
                phone = value;
                RaisePropertyChanged("Phone");
            }
        }

        /// <summary>
        /// Gets or sets users mobile phone number.
        /// </summary>
        [DataMember()]
        public virtual string MobilePhone
        {
            get { return mobilePhone; }
            set
            {
                mobilePhone = value;
                RaisePropertyChanged("MobilePhone");
            }
        }

        /// <summary>
        /// Gets or sets users post code.
        /// </summary>
        [DataMember()]
        public virtual string PostCode
        {
            get { return postCode; }
            set
            {
                postCode = value;
                RaisePropertyChanged("PostCode");
            }
        }

        /// <summary>
        /// Gets or sets users sex.
        /// </summary>
        [DataMember()]
        public virtual Sex Sex
        {
            get { return sex; }
            set
            {
                sex = value;
                RaisePropertyChanged("Sex");
            }
        }

        /// <summary>
        /// Gets or sets user role.
        /// </summary>
        [DataMember()]
        public virtual UserRoles Role
        {
            get { return role; }
            set
            {
                role = value;
                RaisePropertyChanged("Role");
            }
        }

        /// <summary>
        /// When ovveriden indicates if user is administrator [Operator].
        /// </summary>
        public virtual bool IsAdmin
        {
            get { return Role == UserRoles.Operator; }
            set { }
        }

        /// <summary>
        /// When ovveriden indicates if user is guest.
        /// </summary>
        public virtual bool IsGuest
        {
            get { return Role == UserRoles.Guest; }
            set { }
        }

        /// <summary>
        /// Gets or sets if user profile is enabled.
        /// </summary>
        [DataMember()]
        public virtual bool IsEnabled
        {
            get { return isEnabled; }
            set
            {
                isEnabled = value;
                RaisePropertyChanged("IsEnabled");
            }
        }

        #endregion

        #region FUNCTIONS
        /// <summary>
        /// Reset profile to default values.
        /// </summary>
        public virtual void Reset()
        {
            Id = 0;
            Address = string.Empty;
            BirthDate = DateTime.MinValue;
            City = string.Empty;
            Country = string.Empty;
            Email = string.Empty;
            FirstName = string.Empty;
            LastName = string.Empty;
            MobilePhone = string.Empty;
            Phone = string.Empty;
            PostCode = string.Empty;
            Sex = Sex.Unspecified;
            Role = UserRoles.None;
            UserName = string.Empty;
            IsEnabled = false;
        }
        #endregion
    }
}
