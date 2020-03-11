using System;
using System.Runtime.Serialization;

namespace ServerService.Web.Api.Controllers.Models
{
    /// <summary>
    /// App title.
    /// </summary>
    [Serializable]
    [DataContract]
    public class AppTitle
    {
        /// <summary>
        /// Gets or Sets application Id.
        /// </summary>
        [DataMember]
        public int Id
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or Sets application title.
        /// </summary>
        [DataMember]
        public string Title
        {
            get;
            set;
        }
    }
}
