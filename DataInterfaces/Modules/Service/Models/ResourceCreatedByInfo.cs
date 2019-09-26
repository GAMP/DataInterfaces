using ProtoBuf;
using System;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// Base model for created by modified by info classes.
    /// </summary>
    [DataContract()]
    [Serializable()]
    [ProtoContract()]
    public class ResourceCreatedByInfo
    {
        #region PROPERTIES

        /// <summary>
        /// Created by user id.
        /// </summary>
        /// <remarks>
        /// This can point to operator or normal user depending on resource.
        /// </remarks>
        [DataMember(EmitDefaultValue = false)]
        [ProtoMember(1)]
        public int? CreatedById
        {
            get; set;
        }

        /// <summary>
        /// Created by username. This value is optionally included.
        /// </summary>
        /// <remarks>
        /// This can point to operator or normal user depending on resource.
        /// </remarks>
        [DataMember(EmitDefaultValue = false)]
        [ProtoMember(2)]
        public string CreatedByUsername
        {
            get; set;
        }

        /// <summary>
        /// Resource creation time.
        /// </summary>
        /// <remarks>
        /// This can point to operator or normal user depending on resource.
        /// </remarks>
        [DataMember(EmitDefaultValue = false)]
        [ProtoMember(3)]
        public DateTime CreatedTime
        {
            get; set;
        }

        /// <summary>
        /// Modified by user id.
        /// </summary>
        /// <remarks>
        /// This can point to operator or normal user depending on resource.
        /// </remarks>
        [DataMember(EmitDefaultValue = false)]
        [ProtoMember(4)]
        public int? ModifiedById
        {
            get; set;
        }

        /// <summary>
        /// Modified by username. This value is optionally included.
        /// </summary>
        /// <remarks>
        /// This can point to operator or normal user depending on resource.
        /// </remarks>
        [DataMember(EmitDefaultValue = false)]
        [ProtoMember(5)]
        public string ModifiedByUsername
        {
            get; set;
        }

        /// <summary>
        /// Resource last modification time.
        /// </summary>
        /// <remarks>
        /// The value will be equal to null if not modifications was done to the resource.
        /// </remarks>
        [DataMember(EmitDefaultValue = false)]
        [ProtoMember(6)]
        public DateTime? ModifiedTime
        {
            get; set;
        }

        #endregion
    }
}
