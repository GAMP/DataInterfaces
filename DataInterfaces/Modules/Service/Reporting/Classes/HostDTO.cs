using System;
using System.Runtime.Serialization;

namespace ServerService.Reporting
{
    /// <summary>
    /// Host Information.
    /// </summary>
    [Serializable]
    [DataContract]
    public class HostDTO
    {
        /// <summary>
        /// Host Id.
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// Host name.
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Host created time.
        /// </summary>
        public DateTime CreatedTime { get; set; }

        /// <summary>
        /// Host is deleted.
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Host modified time.
        /// </summary>
        public DateTime? ModifiedTime { get; set; }

    }
}
