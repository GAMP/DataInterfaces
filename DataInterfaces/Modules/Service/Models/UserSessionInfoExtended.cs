using SharedLib;
using System;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// User session info extended model.
    /// </summary>
    [Serializable()]
    [DataContract()]
    public class UserSessionInfoExtended
    {
        #region PROPERTIES

        /// <summary>
        /// Gets or sets user name.
        /// </summary>
        [DataMember()]
        public string Username
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets user id.
        /// </summary>
        [DataMember()]
        public int UserId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets total session span.
        /// </summary>
        [DataMember()]
        public double Span
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets last login date time.
        /// </summary>
        [DataMember()]
        public DateTime? LastLogin
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets last logout date time.
        /// </summary>
        [DataMember()]
        public DateTime? LastLogout
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets host id.
        /// </summary>
        [DataMember()]
        public int HostId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets host name.
        /// </summary>
        [DataMember()]
        public string HostName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets host number.
        /// </summary>
        [DataMember()]
        public int HostNumber
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets user group name.
        /// </summary>
        [DataMember()]
        public string UserGroupName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets user group id.
        /// </summary>
        [DataMember()]
        public int? UserGroupId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets host group name.
        /// </summary>
        [DataMember()]
        public string HostGroupName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets host group id.
        /// </summary>
        [DataMember()]
        public int? HostGroupId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets session state.
        /// </summary>
        [DataMember()]
        public SessionState SessionState
        {
            get;
            set;
        } 

        /// <summary>
        /// Gets or sets session slot.
        /// </summary>
        [DataMember()]
        public int Slot
        {
            get;set;
        }

        #endregion
    }
}
