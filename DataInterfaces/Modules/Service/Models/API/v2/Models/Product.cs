using ServerService.Web.Api.v2.Enums;
using System;
using System.Runtime.Serialization;

namespace ServerService.Web.Api.v2.Models
{
    /// <summary>
    /// Product.
    /// </summary>
    [Serializable()]
    [DataContract()]
    public class Product : ServerService.Web.Api.Controllers.Models.ProductBase
    {
        /// <summary>
        /// Gets or sets product type.
        /// </summary>
        [DataMember()]
        public ProductTypes ProductType
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets ProductTime.
        /// </summary>
        [DataMember()]
        public TimeProduct TimeProduct
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets ProductBundle.
        /// </summary>
        [DataMember()]
        public Bundle Bundle
        {
            get;
            set;
        }
    }
}