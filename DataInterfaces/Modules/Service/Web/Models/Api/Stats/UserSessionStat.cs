using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace ServerService.Web.Api.Controllers.Models
{
    /// <summary>
    /// User session stat dto.
    /// </summary>
    [NotMapped()]
    [DataContract()]
    [Serializable()]
    public class UserSessionStat : UserBaseDTO
    {
        #region PROPERTIES
        
        /// <summary>
        /// Total hours.
        /// </summary>
        [DataMember(Order = 2)]
        public string Hours
        {
            get { return string.Format("{0}:{1}:{2}", (int)this.TotalSpan.TotalHours, this.TotalSpan.Minutes, this.TotalSpan.Seconds); }
        }

        /// <summary>
        /// Total session time span.
        /// </summary>
        [DataMember(Order = 3)]
        public TimeSpan TotalSpan
        {
            get; set;
        } 

        #endregion
    }
}
