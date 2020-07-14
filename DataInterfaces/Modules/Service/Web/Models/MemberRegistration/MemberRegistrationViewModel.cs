using ServerService.Web.Api.Controllers.Models;
using SharedLib;
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
        public RegistrationVerificationMethod VerificationMethod { get; set; }

        [DataMember]
        public UserInfoTypes RequiredUserInfo { get; set; }

        [DataMember]
        public IEnumerable<CountryInfo> Countries { get; set; }

        [DataMember]
        public string CurrentCountryCode { get; set; }

        [DataMember]
        public string CurrentCallingCode { get; set; }

        [DataMember]
        public string Agreement { get; set; }

    }
}