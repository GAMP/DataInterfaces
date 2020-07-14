using SharedLib;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ServerService.Web.Api.Controllers.Models
{
    /// <summary>
    /// Registration completion.
    /// Used to complete registration process.
    /// </summary>
    [DataContract()]
    public class RegistrationCompleteWithTokenModel : RegistrationCompleteModel
    {
        #region PROPERTIES

        /// <summary>
        /// Verification token.
        /// </summary>
        [DataMember(Order = 0)]
        [Required()]
        public string Token
        {
            get; set;
        }

        #endregion
    }
}