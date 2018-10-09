using ProtoBuf;
using System.Runtime.Serialization;

namespace ServerService
{
    [ProtoContract()]
    [DataContract()]
    public class AssetInfo
    {
        #region PROPERTIES

        [ProtoMember(1)]
        [DataMember()]
        public int AssetTypeId
        {
            get; set;
        }

        [ProtoMember(2)]
        [DataMember()]
        public int AssetId
        {
            get; set;
        }

        [ProtoMember(3)]
        [DataMember()]
        public int? UsedById
        {
            get; set;
        }

        [ProtoMember(4)]
        [DataMember()]
        public int Number
        {
            get; set;
        }

        [ProtoMember(5)]
        [DataMember()]
        public string Tag
        {
            get; set;
        }

        [ProtoMember(6)]
        [DataMember()]
        public bool IsEnabled
        {
            get; set;
        } 

        #endregion
    }
}
