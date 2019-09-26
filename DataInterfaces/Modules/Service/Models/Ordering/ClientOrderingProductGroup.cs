using ProtoBuf;
using System;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// Client ordering product group model.
    /// </summary>
    [DataContract()]
    [Serializable()]
    [ProtoContract()]
    public class ClientOrderingProductGroup
    {
        #region PROPERTIES

        /// <summary>
        /// Product group id.
        /// </summary>
        [DataMember()]
        [ProtoMember(1)]
        public int ProductGroupId
        {
            get; set;
        }

        /// <summary>
        /// Product group name.
        /// </summary>
        [DataMember()]
        [ProtoMember(2)]
        public string Name
        {
            get; set;
        } 

        #endregion
    }
}
