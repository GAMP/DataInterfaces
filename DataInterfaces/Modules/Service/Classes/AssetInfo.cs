using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ServerService
{
    [ProtoContract()]
    [DataContract()]
    public class AssetInfo
    {
        [ProtoMember(1)]
        [DataMember()]
        public int AssetTypeId
        {
            get;set;
        }

        [ProtoMember(2)]
        [DataMember()]
        public int AssetId
        {
            get;set;
        }

        [ProtoMember(3)]
        [DataMember()]
        public int? UsedById
        {
            get;set;
        }

        [ProtoMember(4)]
        [DataMember()]
        public int Number
        {
            get;set;
        }

        [ProtoMember(5)]
        [DataMember()]
        public string Tag
        {
            get;set;
        }

        [ProtoMember(6)]
        [DataMember()]
        public bool IsEnabled
        {
            get;set;
        }
    }
}
