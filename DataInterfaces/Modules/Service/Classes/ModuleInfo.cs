using ProtoBuf;
using System;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// Executable module information.
    /// </summary>
    [Serializable()]
    [DataContract()]
    [ProtoContract()]
    public class ModuleInfo
    {
        #region PROPERTIES

        /// <summary>
        /// Full path.
        /// </summary>
        [ProtoMember(1)]
        [DataMember()]
        public string FullPath
        {
            get; set;
        }

        /// <summary>
        /// Version.
        /// </summary>
        [ProtoMember(2)]
        [DataMember()]
        public Version Version
        {
            get; set;
        } 

        #endregion
    }
}
