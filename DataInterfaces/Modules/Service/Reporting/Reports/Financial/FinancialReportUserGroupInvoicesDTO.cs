using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Financial
{
    /// <summary>
    /// Financial report information about sales or voids for a single group.
    /// </summary>
    [Serializable]
    [DataContract]
    public class FinancialReportUserGroupInvoicesDTO
    {
        /// <summary>
        /// Group name.
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// List of fixed time sold.
        /// </summary>
        [DataMember]
        public List<SoldProductDTO> FixedTimeProductsSold { get; set; } = new List<SoldProductDTO>();

        /// <summary>
        /// List of session time sold.
        /// </summary>
        [DataMember]
        public List<SoldProductDTO> SessionTimeProductsSold { get; set; } = new List<SoldProductDTO>();

        /// <summary>
        /// List of time offers sold.
        /// </summary>
        [DataMember]
        public List<SoldProductDTO> TimeOffersSold { get; set; } = new List<SoldProductDTO>();

        /// <summary>
        /// List of products sold.
        /// </summary>
        [DataMember]
        public List<SoldProductDTO> ProductsSold { get; set; } = new List<SoldProductDTO>();

        /// <summary>
        /// List of bundles sold.
        /// </summary>
        [DataMember]
        public List<SoldProductDTO> BundlesSold { get; set; } = new List<SoldProductDTO>();

    }
}