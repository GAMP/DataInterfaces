namespace System.ComponentModel
{
    /// <summary>
    /// Dynamic property descriptor.
    /// </summary>
    /// <typeparam name="T">Property type.</typeparam>
    public class DynamicPropertyDescriptor<T> : PropertyDescriptor
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="propertyName">Property name.</param>
        /// <param name="componentType">Component type.</param>
        /// <exception cref="ArgumentNullException"> thrown in case of <paramref name="propertyName"/> being null or empty string.</exception>
        public DynamicPropertyDescriptor(string propertyName, Type componentType)
            : base(propertyName, new Attribute[] { })
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentNullException(nameof(propertyName));

            propertyType = typeof(T);
            this.componentType = componentType ?? throw new ArgumentNullException(nameof(componentType));
        }
        #endregion

        #region FIELDS
        private Type propertyType;
        private Type componentType;
        private T propertyValue;
        #endregion

        #region OVERRIDES

        /// <summary>
        /// Gets if value can be reset.
        /// </summary>
        /// <param name="component">Component.</param>
        /// <returns>True or false.</returns>
        public override bool CanResetValue(object component)
        {
            return true;
        }

        /// <summary>
        /// Gets component type.
        /// </summary>
        public override Type ComponentType
        {
            get { return componentType; }
        }

        /// <summary>
        /// Gets if read only.
        /// </summary>
        public override bool IsReadOnly
        {
            get { return false; }
        }

        /// <summary>
        /// Gets property value.
        /// </summary>
        /// <param name="component"></param>
        /// <returns>Property value.</returns>
        public override object GetValue(object component)
        {
            return propertyValue;
        }

        /// <summary>
        /// Gets property type.
        /// </summary>
        public override Type PropertyType
        {
            get { return propertyType; }
        }

        /// <summary>
        /// Resets value.
        /// </summary>
        /// <param name="component">Component.</param>
        public override void ResetValue(object component)
        {
            SetValue(component, default(T));
        }

        /// <summary>
        /// Sets value.
        /// </summary>
        /// <param name="component">Component.</param>
        /// <param name="value">Value.</param>
        public override void SetValue(object component, object value)
        {
            //check if we can assign from specified value
            if (!value.GetType().IsAssignableFrom(propertyType))
                throw new ArgumentException("Invalid value type", nameof(propertyType));

            //set value
            propertyValue = (T)value;

            //raise value changed
            OnValueChanged(component, new EventArgs());
        }

        /// <summary>
        /// Gets if serialization should occur.
        /// </summary>
        /// <param name="component">Component.</param>
        /// <returns>True or false.</returns>
        public override bool ShouldSerializeValue(object component) { return true; }

        #endregion
    }
}
