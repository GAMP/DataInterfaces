using System;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Assets
{
    /// <summary>
    /// Asset List Item.
    /// </summary>
    [Serializable]
    [DataContract]
    public class AssetDTO : ListItemDTO
    {
        /// <summary>
        /// Asset Type Id.
        /// </summary>
        [DataMember]
        public int AssetTypeId { get; set; }

        /// <summary>
        /// Asset Type Id.
        /// </summary>
        [DataMember]
        public int Number { get; set; }
    }
}