using System;
using System.Runtime.Serialization;

namespace ServerService.Web.Api.Controllers.Models
{
    /// <summary>
    /// App image data model.
    /// </summary>
    [DataContract()]
    public class AppImageData
    {
        #region PROPERTIES
        
        /// <summary>
        /// Application id.
        /// </summary>
        [DataMember()]
        public int AppId
        {
            get; set;
        }

        /// <summary>
        /// Created time.
        /// </summary>
        [DataMember()]
        public DateTime CreatedTime
        {
            get; set;
        }

        /// <summary>
        /// Image data.
        /// </summary>
        [DataMember()]
        public byte[] ImageData
        {
            get; set;
        }

        /// <summary>
        /// Application title.
        /// </summary>
        [DataMember()]
        public string AppTitle
        {
            get; set;
        } 

        #endregion
    }
}
