using SharedLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLib
{
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
