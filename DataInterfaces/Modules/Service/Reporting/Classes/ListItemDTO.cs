using System;
using System.Runtime.Serialization;

namespace ServerService.Reporting
{
    /// <summary>
    /// List Item.
    /// </summary>
    [Serializable]
    [DataContract]
    public class ListItemDTO
    {
        /// <summary>
        /// Item Id.
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// Item name.
        /// </summary>
        [DataMember]
        public string Name { get; set; }
    }
}