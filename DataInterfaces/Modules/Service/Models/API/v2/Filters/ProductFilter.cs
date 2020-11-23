using ServerService.Web.Api.v2.Enums;
using System;
using System.Runtime.Serialization;

namespace ServerService.Web.Api.v2.Filters
{
    [Serializable()]
    [DataContract()]
    public class ProductFilter : PaginationFilter
    {
        [DataMember]
        public ProductTypes? ProductType
        {
            get; set;
        }
    }
}
