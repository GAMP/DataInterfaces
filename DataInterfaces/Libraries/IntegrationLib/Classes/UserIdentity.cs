using System;
using System.Security.Principal;
using SharedLib;
using System.Runtime.Serialization;

namespace IntegrationLib
{
    #region UserIdenity
    [Serializable()]
    [DataContract()]
    public class UserIdentity : GenericIdentity, IUserIdentity
    {
        #region Constructor

        public UserIdentity(string name, int userId, UserRoles role)
            : base(name)
        {
            UserId = userId;
            Role = role;
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
}
