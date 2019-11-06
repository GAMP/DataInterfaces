using SharedLib;
using System;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// Host event args with host id.
    /// </summary>
    [Serializable()]
    public class HostIdEventArgs : HostIdArgsBase
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="hostId">Host id.</param>
        /// <param name="type">Event type.</param>
        /// <param name="parameters">Parameters.</param>
        public HostIdEventArgs(int hostId, HostEventType type, object parameters)
            : base(hostId)
        {
            Type = type;
            Parameters = parameters;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hostId">Host id.</param>
        /// <param name="type">Event type.</param>
        public HostIdEventArgs(int hostId, HostEventType type)
            : this(hostId, type, null)
        { }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets type.
        /// </summary>
        [DataMember()]
        public HostEventType Type
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets parameters.
        /// </summary>
        [DataMember()]
        public object Parameters
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets parameters as array.
        /// </summary>
        [DataMember()]
        public object[] ParametersArray
        {
            get
            {
                return Parameters as object[];
            }
        }

        #endregion
    }
}
