using SharedLib;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// Host properties changed event args.
    /// </summary>
    [Serializable()]
    [DataContract()]
    public class HostPropertiesChangedEventArgs : HostIdArgsBase
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Single property change constructor.
        /// </summary>
        /// <param name="hostId">Host id.</param>
        /// <param name="type">Property type.</param>
        /// <param name="value">Property value.</param>
        public HostPropertiesChangedEventArgs(int hostId, HostPropertyType type, object value)
            : base(hostId)
        {
            Properties = new Dictionary<HostPropertyType, object>
            {
                { type, value }
            };
        }

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="hostId">Host id.</param>
        /// <param name="properties">Properties.</param>
        public HostPropertiesChangedEventArgs(int hostId, IDictionary<HostPropertyType, object> properties)
            : base(hostId)
        {
            Properties = properties;
        }

        #endregion

        #region FIELDS
        private IDictionary<HostPropertyType, object> properties;
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets affected properties.
        /// </summary>
        [DataMember()]
        public IDictionary<HostPropertyType, object> Properties
        {
            get
            {
                if (properties == null)
                    properties = new Dictionary<HostPropertyType, object>();
                return properties;
            }
            private set
            {
                this.properties = value;
            }
        }

        #endregion

        #region FUNCTIONS

        /// <summary>
        /// Gets if specified property exists.
        /// </summary>
        /// <param name="type">Property type.</param>
        /// <returns>True if exists, otherwise false.</returns>
        public bool HasProperty(HostPropertyType type)
        {
            return Properties.ContainsKey(type);
        }

        /// <summary>
        /// Gets the spcecified property.
        /// </summary>
        /// <typeparam name="T">Object type of the property.</typeparam>
        /// <param name="type">HostPropertyType.</param>
        /// <returns>Property value.</returns>
        public T GetProperty<T>(HostPropertyType type)
        {
            return (T)Properties[type];
        }

        #endregion
    }
}
