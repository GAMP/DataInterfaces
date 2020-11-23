using SharedLib;
using System.Runtime.Serialization;

namespace ServerService.Web.Api.v2.Models
{
    /// <summary>
    /// Product group.
    /// </summary>
    [DataContract]
    public class ProductGroup
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int? ParentId { get; set; }

        [DataMember]
        public int DisplayOrder { get; set; }

        [DataMember]
        public ProductSortOptionType SortOption { get; set; }
    }
}
