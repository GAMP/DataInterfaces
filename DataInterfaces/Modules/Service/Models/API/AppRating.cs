using System;
using System.Runtime.Serialization;

namespace ServerService.Web.Api.Controllers.Models
{
    /// <summary>
    /// App rating entity.
    /// </summary>
    [Serializable()]
    [DataContract()]
    public class AppRating
    {
        #region AppRating

        /// <summary>
        /// Gets or sets value.
        /// </summary>
        [DataMember()]
        public int Value { get; set; }

        /// <summary>
        /// Gets or sets last vote time.
        /// </summary>
        [DataMember()]
        public DateTime Date { get; set; }
        
        /// <summary>
        /// Gets or sets user id.
        /// </summary>
        [DataMember()]
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets user name.
        /// </summary>
        [DataMember()]
        public string Username { get; set; }

        #endregion

    }
}
