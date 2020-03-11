using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ServerService.Web.Api.Controllers.Models
{
    [DataContract()]
    [Serializable()]
    [ProtoContract()]
    public class ModifiableByWithRequiredUserMemberBase : ModifiableByUserBase
    {
        /// <summary>
        /// Gets or sets user id.
        /// </summary>
        [DataMember()]
        [ProtoMember(1)]
        public int UserId
        {
            get;
            set;
        }
    }
}
