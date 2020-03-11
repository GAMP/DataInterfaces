using ProtoBuf;
using System;
using System.Runtime.Serialization;

namespace ServerService.Web.Api.Controllers.Models
{
    /// <summary>
    /// Product user disallowed enttiy.
    /// </summary>
    [DataContract()]
    [Serializable()]
    [ProtoContract()]
    public class ProductUserDisallowed : ModifiableByUserBase
    {
        #region ProductUserDisallowed

        /// <summary>
        /// Gets or sets user group.
        /// </summary>
        [DataMember()]
        [ProtoMember(1)]
        public int UserGroupId
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets product.
        /// </summary>
        [DataMember()]
        [ProtoMember(2)]
        public int ProductId
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets disallowed value.
        /// </summary>
        [DataMember()]
        [ProtoMember(3)]
        public bool IsDisallowed
        {
            get; set;
        }

        #endregion
        
    }
}
