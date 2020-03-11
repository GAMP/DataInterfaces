using ProtoBuf;
using System.Runtime.Serialization;

namespace ServerService.Web.Api.Controllers.Models
{
    public class BundleProductUserPrice : ModifiableByUserBase
    {
        #region BundleProductUserPrice

        /// <summary>
        /// Gets or sets product bundle id.
        /// </summary>
        [DataMember()]
        [ProtoMember(1)]
        public int BundleProductId
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets user group id.
        /// </summary>
        [DataMember()]
        [ProtoMember(2)]
        public int UserGroupId
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets price.
        /// </summary>
        [DataMember()]
        [ProtoMember(3)]
        public decimal? Price
        {
            get; set;
        }

        #endregion
    }
}
