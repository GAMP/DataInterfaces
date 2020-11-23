using System;
using System.Runtime.Serialization;

namespace ServerService.Web.Api.v2.Filters
{
    [Serializable()]
    [DataContract()]
    public class UserFilter : PaginationFilter
    {
        [DataMember(EmitDefaultValue = false)]
        public int? UserGroupId
        {
            get; set;
        }

        [DataMember(EmitDefaultValue = false)]
        public bool? IsDeleted
        {
            get; set;
        }

        [DataMember(EmitDefaultValue = false)]
        public bool? IsDisabled
        {
            get; set;
        }
    }
}
