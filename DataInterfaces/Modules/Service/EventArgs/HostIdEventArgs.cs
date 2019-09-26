using SharedLib;
using System;

namespace ServerService
{
    #region HOSTIDEVENTARGS
    [Serializable()]
    public class HostIdEventArgs : HostIdArgsBase
    {
        #region CONSTRUCTOR
        public HostIdEventArgs(int hostId, HostEventType type, object parameters)
            : base(hostId)
        {
            Type = type;
            Parameters = parameters;
        }

        public HostIdEventArgs(int hostId, HostEventType type)
            : this(hostId, type, null)
        { }
        #endregion

        #region PROPERTIES
        /// <summary>
        /// Gets type.
        /// </summary>
        public HostEventType Type
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets parameters.
        /// </summary>
        public object Parameters
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets parameters as array.
        /// </summary>
        public object[] ParametersArray
        {
            get
            {
                return this.Parameters as object[];
            }
        }
        #endregion
    }
    #endregion
}
