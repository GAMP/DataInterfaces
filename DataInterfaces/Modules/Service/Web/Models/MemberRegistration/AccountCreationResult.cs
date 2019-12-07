using SharedLib;
using System.Runtime.Serialization;

namespace ServerService.Web.MemberRegistration.Models
{
    [DataContract()]
    public class AccountCreationResult
    {
        [DataMember]
        public AccountCreationCompleteResultCode Result
        {
            get; set;
        }

        [DataMember]
        public int? UserId
        {
            get; set;
        }

        [DataMember]
        public string Message { get; set; }
    }
}
