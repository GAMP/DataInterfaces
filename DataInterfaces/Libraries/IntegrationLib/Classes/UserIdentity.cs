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
}
