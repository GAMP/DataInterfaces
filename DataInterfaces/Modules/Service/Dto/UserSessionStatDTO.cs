using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// User session stat dto.
    /// </summary>
    [NotMapped()]
    [DataContract()]
    [Serializable()]
    public class UserSessionStatDTO : UserBaseDTO
    {
        #region PROPERTIES
        
        /// <summary>
        /// Gets total hours.
        /// </summary>
        [DataMember(Order = 2)]
        public string Hours
        {
            get { return string.Format("{0}:{1}:{2}", (int)this.TotalSpan.TotalHours, this.TotalSpan.Minutes, this.TotalSpan.Seconds); }
        }

        /// <summary>
        /// Gets or sets total session time span.
        /// </summary>
        [DataMember(Order = 3)]
        public TimeSpan TotalSpan
        {
            get; set;
        } 

        #endregion
    }
}
