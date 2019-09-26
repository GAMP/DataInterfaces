using System;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// User base DTO.
    /// </summary>
    [DataContract()]
    [Serializable()]
    public abstract class UserBaseDTO
    {
        #region PROPERTIES
        
        /// <summary>
        /// Gets or sets user id.
        /// </summary>
        [DataMember(Order = 0)]
        public int UserId
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets user name.
        /// </summary>
        [DataMember(Order = 1)]
        public string Username
        {
            get; set;
        } 

        #endregion
    }
}
