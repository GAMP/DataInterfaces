using System;
using System.Runtime.Serialization;

namespace ServerService
{
    [Serializable()]
    [DataContract()]
    public class UserFilter
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
