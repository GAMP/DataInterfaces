using System;
using System.Runtime.Serialization;

namespace ServerService
{
    #region HOSTIDARGSBASE
    [Serializable()]
    [DataContract()]
    public abstract class HostIdArgsBase : EventArgs
    {
        #region CONSTRUCTOR
        public HostIdArgsBase(int hostId)
            : base()
        {
            HostId = hostId;
        }
        #endregion

        #region PROPERTIES
        /// <summary>
        /// Gets host id.
        /// </summary>
        [DataMember()]
        public int HostId
        {
            get;
            protected set;
        }
        #endregion
    }
    #endregion
}
