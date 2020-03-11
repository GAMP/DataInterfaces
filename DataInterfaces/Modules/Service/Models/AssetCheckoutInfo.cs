using ProtoBuf;
using System;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// Asset checkout info model.
    /// </summary>
    [ProtoContract()]
    [DataContract()]
    public class AssetCheckoutInfo
    {
        #region PROPERTIES

        /// <summary>
        /// Asset type id.
        /// </summary>
        [ProtoMember(1)]
        [DataMember()]
        public int AssetTypeId
        {
            get; set;
        }

        /// <summary>
        /// Asset id.
        /// </summary>
        [ProtoMember(2)]
        [DataMember()]
        public int AssetId
        {
            get; set;
        }

        /// <summary>
        /// Used by id.
        /// </summary>
        [ProtoMember(3)]
        [DataMember()]
        public int? UsedById
        {
            get; set;
        }

        /// <summary>
        /// Asset number.
        /// </summary>
        [ProtoMember(4)]
        [DataMember()]
        public int Number
        {
            get; set;
        }

        /// <summary>
        /// Asset tag.
        /// </summary>
        [ProtoMember(5)]
        [DataMember()]
        public string Tag
        {
            get; set;
        }

        /// <summary>
        /// Indicates if asset is enabled.
        /// </summary>
        [ProtoMember(6)]
        [DataMember()]
        public bool IsEnabled
        {
            get; set;
        }

        /// <summary>
        /// Asset checkout operator.
        /// </summary>
        [ProtoMember(7)]
        [DataMember()]
        public int? CheckOutOperatorId
        {
            get; set;
        }

        /// <summary>
        /// Asset checkout time.
        /// </summary>
        [ProtoMember(8)]
        [DataMember()]
        public DateTime CheckOutTime
        {
            get; set;
        }     
        
        /// <summary>
        /// Used by host id.
        /// </summary>
        [ProtoMember(9)]
        [DataMember()]
        public int? UsedByHostId
        {
            get; set;
        }

        #endregion
    }
}
