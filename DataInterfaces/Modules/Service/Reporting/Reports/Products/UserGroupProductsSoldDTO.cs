using System;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Products
{
    /// <summary>
    /// Product sales for a user group.
    /// </summary>
    [Serializable]
    [DataContract]
    public class UserGroupProductsSoldDTO
    {
        /// <summary>
        /// User group name.
        /// </summary>
        [DataMember]
        public string UserGroupName { get; set; }

        /// <summary>
        /// Product information.
        /// </summary>
        [DataMember]
        public GroupProductSoldDTO Product { get; set; }

    }
}