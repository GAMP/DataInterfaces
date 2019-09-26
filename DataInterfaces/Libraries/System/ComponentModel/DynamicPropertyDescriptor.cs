namespace System.ComponentModel
{
    /// <summary>
    /// Dynamic property descriptor.
    /// </summary>
    /// <typeparam name="T">Property type.</typeparam>
    public class DynamicPropertyDescriptor<T> : PropertyDescriptor
    {
        #region CONSTRUCTOR
        public DynamicPropertyDescriptor(string propertyName, Type componentType)
            : base(propertyName, new Attribute[] { })
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentNullException(nameof(propertyName));

            if (componentType == null)
                throw new ArgumentNullException(nameof(componentType));

            this.propertyType = typeof(T);
            this.componentType = componentType;
        }
        #endregion

        #region FIELDS
        private Type propertyType;
        private Type componentType;
        private T propertyValue;
        #endregion

        #region OVERRIDES

        public override bool CanResetValue(object component)
        {
            return true;
        }

        public override Type ComponentType
        {
            get { return componentType; }
        }

        public override bool IsReadOnly
        {
            get { return false; }
        }

        public override object GetValue(object component)
        {
            return propertyValue;
        }    

        public override Type PropertyType
        {
            get { return propertyType; }
        }

        public override void ResetValue(object component)
        {
            SetValue(component, default(T));
        }

        public override void SetValue(object component, object value)
        {
            //check if we can assign from specified value
            if (!value.GetType().IsAssignableFrom(propertyType))
                throw new ArgumentException("Invalid value type",nameof(propertyType));        

            //set value
            propertyValue = (T)value;

            //raise value changed
            OnValueChanged(component, new EventArgs());
        }

        public override bool ShouldSerializeValue(object component) { return true; }

        #endregion
    }
}
