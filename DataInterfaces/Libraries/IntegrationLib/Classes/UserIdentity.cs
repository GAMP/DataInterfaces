using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Principal;
using SharedLib;
using System.Threading;
using System.Runtime.Serialization;

namespace IntegrationLib
{
    #region UserIdenity
    [Serializable()]
    [DataContract()]
    public class UserIdentity : GenericIdentity, IUserIdentity
    {
        #region Constructor

        public UserIdentity(string name, int userId, UserRoles role, string type)
            : base(name, type)
        {
            this.UserId = userId;
            this.Role = role;
        }

        public UserIdentity(string name, int userId, UserRoles role)
            : this(name, userId,role,"Basic")
        {
            this.UserId = userId;
            this.Role = role;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets user id.
        /// </summary>
        [DataMember()]
        public int UserId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets user role.
        /// </summary>
        [DataMember()]
        public UserRoles Role
        {
            get;
            set;
        }

        #endregion
    }
    #endregion

    #region UserPrincipal
    public class UserPrincipal : GenericPrincipal
    {
        #region Constructor
        public UserPrincipal(UserIdentity idenity, string[] roles)
            : base(idenity, roles)
        {
        }

        public UserPrincipal(UserIdentity idenity)
            : this(idenity, new string[] { idenity.Role.ToString() } )
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets current thread Principal.
        /// </summary>
        public static UserPrincipal Current
        {
            get { return Thread.CurrentPrincipal as UserPrincipal; }
        }

        /// <summary>
        /// Gets user identity.
        /// </summary>
        public UserIdentity UserIdentity
        {
            get { return this.Identity as UserIdentity; }
        }

        #endregion
    }
    #endregion

    #region AuthResult
    [DataContract()]
    [Serializable()]
    public class AuthResult
    {
        #region CONSTRUCTOR

        public AuthResult(LoginResult result, IUserIdentity identity)
        {
            this.Identity = identity;
            this.Result = result;
        }

        #endregion

        #region FIELDS
        private Dictionary<string, object> custom;
        #endregion

        #region PROPERTIES

        /// <summary>
        /// User identity.
        /// </summary>
        [DataMember()]
        public IUserIdentity Identity
        {
            get;
            set;
        }

        /// <summary>
        /// Authentication result.
        /// </summary>
        [DataMember()]
        public LoginResult Result
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets user info required after authentication.
        /// </summary>
        [DataMember()]
        public UserInfoTypes RequiredInfo
        {
            get;
            set;
        }

        /// <summary>
        /// Custom fields dictionary.
        /// <remarks>This can used to provide custom data to authenticated party.</remarks>
        /// </summary>
        [DataMember()]
        public Dictionary<string, object> Custom
        {
            get
            {
                if (this.custom == null)
                    this.custom = new Dictionary<string, object>();
                return this.custom;
            }
        }

        #endregion
    }
    #endregion

    #region DbCredentials
    /// <summary>
    /// Generic user credentials stored in user credentials database.
    /// </summary>
    public class DbCredentials
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Creates new credentials instance.
        /// </summary>
        /// <param name="id">User Id.</param>
        /// <param name="userName">User Name.</param>
        /// <param name="email">User Email Address.</param>
        /// <param name="role">User role.</param>
        /// <param name="password">User Password.</param>
        /// <param name="salt">Password salt.</param>
        /// <param name="enabled">Sets if user credentials are enabled.</param>
        public DbCredentials(int id, string userName, string email, UserRoles role, byte[] password, byte[] salt, bool enabled)
        {
            this.UserId = id;
            this.UserName = userName;
            this.Email = email;
            this.Role = role;
            this.Password = password;
            this.Salt = salt;
            this.Enabled = enabled;
        }

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets or sets user id.
        /// </summary>
        public int UserId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets user role.
        /// </summary>
        public UserRoles Role
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets user name.
        /// </summary>
        public string UserName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets user email.
        /// </summary>
        public string Email
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets password.
        /// </summary>
        public byte[] Password
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets salt.
        /// </summary>
        public byte[] Salt
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets if credentials enabled.
        /// </summary>
        public bool Enabled
        {
            get;
            set;
        }

        /// <summary>
        /// Gets if credentials is currently unset.
        /// <remarks>Unset credentials are gennerally found for newly created user accounts.
        /// Unset credentials require user to specify new password at login.</remarks>
        /// </summary>
        public bool IsUnset
        {
            get { return this.Password == null && this.Salt == null; }
        }

        #endregion
    }
    #endregion
}
