using System;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Assets
{
    /// <summary>
    /// Asset transaction information.
    /// </summary>
    [Serializable]
    [DataContract]
    public class AssetTransactionDTO
    {
        /// <summary>
        /// Asset type.
        /// </summary>
        [DataMember]
        public string AssetType { get; set; }

        /// <summary>
        /// Asset number.
        /// </summary>
        [DataMember]
        public int AssetNumber { get; set; }

        /// <summary>
        /// Asset name.
        /// </summary>
        [DataMember]
        public string AssetName { get; set; }

        /// <summary>
        /// Customer name.
        /// </summary>
        [DataMember]
        public string Customer { get; set; }

        /// <summary>
        /// The time the asset was checked out.
        /// </summary>
        [DataMember]
        public DateTime CheckOutTime { get; set; }

        /// <summary>
        /// Name of the operator that checked out the asset.
        /// </summary>
        [DataMember]
        public string CheckOutOperator { get; set; }

        /// <summary>
        /// The time the asset was checked in or null if is still checked out.
        /// </summary>
        [DataMember]
        public DateTime? CheckInTime { get; set; }

        /// <summary>
        /// Name of the operator that checked in the asset.
        /// </summary>
        [DataMember]
        public string CheckInOperator { get; set; }

        /// <summary>
        /// Duration of the lease as text.
        /// </summary>
        [DataMember]
        public string LeaseDuration { get; set; }
        
    }
}