using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerService.Web.MemberRegistration.Models
{
    [DataContract]
    public class CountryInfo
    {

        [DataMember(Name = "name")]
        public string Name { get; set; }
        
        [DataMember(Name = "alpha2Code")]
        public string Alpha2Code { get; set; }

        [DataMember(Name = "callingCodes")]
        public IList<string> CallingCodes { get; set; }

        [DataMember(Name = "capital")]
        public string Capital { get; set; }

        [DataMember(Name = "altSpellings")]
        public IList<string> AltSpellings { get; set; }
                
        [DataMember(Name = "timezones")]
        public IList<string> Timezones { get; set; }

        [DataMember(Name = "nativeName")]
        public string NativeName { get; set; }

        [DataMember(Name = "callingCode")]
        public string CallingCode { get; set; }
    }
}