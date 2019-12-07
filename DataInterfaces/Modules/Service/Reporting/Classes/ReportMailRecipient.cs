using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ServerService.Reporting
{
    /// <summary>
    /// Report Mail Recipient.
    /// </summary>
    [Serializable]
    [DataContract]
    public class ReportMailRecipient
    {
        /// <summary>
        /// Email address of the recipient.
        /// </summary>
        [DataMember]
        [Required()]
        [EmailAddress()]
        public string Email { get; set; }

        /// <summary>
        /// The recipient is active.
        /// </summary>
        [DefaultValue(true)]
        [DataMember]
        public bool IsActive { get; set; }
    }
}