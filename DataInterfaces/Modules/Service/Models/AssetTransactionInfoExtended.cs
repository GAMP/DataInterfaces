using ProtoBuf;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// Extended asset transaction info model.
    /// </summary>
    [ProtoContract()]
    [DataContract()]
    public class AssetTransactionInfoExtended
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

        #endregion
    }
}
