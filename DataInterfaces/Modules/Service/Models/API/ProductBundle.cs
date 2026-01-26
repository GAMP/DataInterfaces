using ProtoBuf;
using System;
using System.Runtime.Serialization;

namespace ServerService.Web.Api.Controllers.Models
{
    /// <summary>
    /// Product bundle entity.
    /// </summary>
    [Serializable()]
    [DataContract()]
    [ProtoContract()]
    public class ProductBundle : ProductBase
    {
        #region ProductBundle

        /// <summary>
        /// Gets or sets bundle stock options.
        /// </summary>
        [DataMember()]
        [ProtoMember(1)]
        public Gizmo.Web.Api.Models.BundleStockOptionType BundleStockOptions
        {
            get; set;
        }

        #endregion
    }
}
