using SharedLib;
using System.Collections.Generic;

namespace ServerService
{
    /// <summary>
    /// Host properties changed event args.
    /// </summary>
    public sealed class HostPropertiesChangedEventArgs : HostIdArgsBase
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
        private IDictionary<HostPropertyType, object> _properties;
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets affected properties.
        /// </summary>
        public IDictionary<HostPropertyType, object> Properties
        {
            get
            {
                _properties ??= new Dictionary<HostPropertyType, object>();
                return _properties;
            }
            private set
            {
                _properties = value;
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
        /// Gets the specified property.
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
