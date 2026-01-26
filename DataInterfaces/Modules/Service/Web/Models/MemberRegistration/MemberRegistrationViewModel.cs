using ServerService.Web.Api.Controllers.Models;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerService.Web.MemberRegistration.Models
{
    [DataContract()]
    public class MemberRegistrationViewModel : RegistrationCompleteModel
    {
        [DataMember]
        public string Token { get; set; }

        [DataMember]
        public bool IsClientRegistrationEnabled { get; set; }

        [DataMember]
        public bool IsWebRegistrationEnabled { get; set; }

        [DataMember]
        public Gizmo.Server.RegistrationVerificationMethod VerificationMethod { get; set; }

        [DataMember]
        public Gizmo.Web.Api.Models.UserInfoTypes RequiredUserInfo { get; set; }

        [DataMember]
        public IEnumerable<CountryInfo> Countries { get; set; }

        [DataMember]
        public string CurrentCountryCode { get; set; }

        [DataMember]
        public string CurrentCallingCode { get; set; }

        [DataMember]
        public Dictionary<int, System.Tuple<bool, bool, string>> Agreements { get; set; }
        
        [DataMember]
        public string ProcessedUserAgreements { get; set; }

        [DataMember]
        public string BusinessName { get; set; }
    }
}
