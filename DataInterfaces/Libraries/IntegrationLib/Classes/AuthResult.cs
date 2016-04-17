using SharedLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLib
{
    #region AuthResult
    [DataContract()]
    [Serializable()]
    public class AuthResult : IAuthResult
    {
        #region CONSTRUCTOR

        public AuthResult(LoginResult result) : this(result, null)
        {
        }

        public AuthResult(LoginResult result, IUserIdentity identity):this(result,identity, UserInfoTypes.None)
        {          
        }

        public AuthResult(LoginResult result,IUserIdentity identity, UserInfoTypes requiredInfo)
        {
            this.Identity = identity;
            this.Result = result;
            this.RequiredInfo = requiredInfo;
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
        /// Login result.
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
}
