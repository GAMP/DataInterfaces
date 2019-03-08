using ProtoBuf;
using System;
using System.Runtime.Serialization;

namespace ServerService
{
    [DataContract()]
    [Serializable()]
    [ProtoContract()]
    public class UserProductGroupDTO
    {
        #region PROPERTIES

        [DataMember()]
        [ProtoMember(1)]
        public int Id
        {
            get; set;
        }

        [DataMember()]
        [ProtoMember(2)]
        public string Name
        {
            get; set;
        } 

        #endregion
    }
}
