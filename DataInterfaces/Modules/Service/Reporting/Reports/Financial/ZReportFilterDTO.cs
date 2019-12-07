using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Financial
{
    /// <summary>
    /// Z Report Filter.
    /// </summary>
    [Serializable]
    [DataContract]
    public class ZReportFilterDTO
    {
        /// <summary>
        /// Filter Date.
        /// </summary>
        [DataMember]
        [Required]
        public DateTime Date { get; set; }

    }
}