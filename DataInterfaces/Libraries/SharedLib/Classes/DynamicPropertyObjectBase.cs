using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace SharedLib
{
    #region DynamicPropertyObjectBase
    /// <summary>
    /// Base classs for objects supporting dynamic properties.
    /// </summary>
    public abstract class DynamicPropertyObjectBase : PropertyChangedBase,
        IDynamicPropertyObject, 
        ICustomTypeDescriptor
    {
        #region CONSTRUCTOR
        public DynamicPropertyObjectBase() : base()
        { }
        #endregion

        #region FIELDS
        private Dictionary<string, PropertyDescriptor> propertyStore = new Dictionary<string, PropertyDescriptor>();
        #endregion

        #region FUNCTIONS

        public void SetPropertyValue<T>(string propertyName, T propertyValue)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentNullException(nameof(propertyName));

            var properties = this.GetProperties()
                                    .Cast<PropertyDescriptor>()
                                    .Where(prop => prop.Name.Equals(propertyName));

            if (properties == null || properties.Count() != 1)
                throw new ArgumentNullException(nameof(propertyName));

            var property = properties.First();
            property.SetValue(this, propertyValue);

            RaisePropertyChanged(propertyName);
        }

        public T GetPropertyValue<T>(string propertyName)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentNullException(nameof(propertyName));

            var properties = this.GetProperties()
                                .Cast<PropertyDescriptor>()
                                .Where(prop => prop.Name.Equals(propertyName));

            if (properties == null || properties.Count() != 1)
                throw new ArgumentNullException(nameof(propertyName));

            var property = properties.First();
            return (T)property.GetValue(this);
        }

        public PropertyDescriptor AddProperty<T, U>(string propertyName) where U : PropertyChangedBase
        {
            return this.AddProperty(propertyName, new DynamicPropertyDescriptor<T>(propertyName, typeof(U)));
        }

        public PropertyDescriptor AddProperty<T>(string propertyName)
        {
            return this.AddProperty(propertyName, new DynamicPropertyDescriptor<T>(propertyName, this.GetType()));
        }

        private PropertyDescriptor AddProperty(string propertyName, PropertyDescriptor customProperty)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentNullException(nameof(propertyName));

            if (customProperty == null)
                throw new ArgumentNullException(nameof(customProperty));

            //will throw if other entry with same name already exist
            propertyStore.Add(propertyName, customProperty);

            //add value change handler
            customProperty.AddValueChanged(this, (o, e) => { RaisePropertyChanged(propertyName); });

            //return back to caller
            return customProperty;
        }

        #endregion

        #region OVERRIDES

        public virtual PropertyDescriptorCollection GetProperties()
        {
            var properties = new PropertyDescriptorCollection(TypeDescriptor.GetProperties(this, true)
                .Cast<PropertyDescriptor>()
                .Union(propertyStore.Values)
                .ToArray());

            return properties;
        }

        public virtual PropertyDescriptorCollection GetProperties(Attribute[] attributes)
        {
            var properties = new PropertyDescriptorCollection(TypeDescriptor.GetProperties(this, attributes, true)
               .Cast<PropertyDescriptor>()
               .Union(propertyStore.Values)
               .ToArray());

            return properties;
        }        

        public virtual AttributeCollection GetAttributes()
        {
            return TypeDescriptor.GetAttributes(this, true);
        }

        public virtual object GetEditor(Type editorBaseType)
        {
            return TypeDescriptor.GetEditor(this, editorBaseType, true);
        }

        public virtual string GetClassName()
        {
            return TypeDescriptor.GetClassName(this, true);
        }

        public virtual string GetComponentName()
        {
            return TypeDescriptor.GetComponentName(this, true);
        }

        public virtual TypeConverter GetConverter()
        {
            return TypeDescriptor.GetConverter(this, true);
        }

        public virtual PropertyDescriptor GetDefaultProperty()
        {
            return TypeDescriptor.GetDefaultProperty(this, true);
        }

        public virtual EventDescriptor GetDefaultEvent()
        {
            return TypeDescriptor.GetDefaultEvent(this, true);
        }

        public virtual EventDescriptorCollection GetEvents()
        {
            return TypeDescriptor.GetEvents(this, true);
        }

        public virtual EventDescriptorCollection GetEvents(Attribute[] attributes)
        {
            return TypeDescriptor.GetEvents(this, attributes, true);
        }

        public virtual object GetPropertyOwner(PropertyDescriptor pd)
        {
            return this;
        }

        #endregion
    } 
    #endregion
}
