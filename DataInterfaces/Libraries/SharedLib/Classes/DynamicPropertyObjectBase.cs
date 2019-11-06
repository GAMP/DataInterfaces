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
        /// <summary>
        /// Creates new instance.
        /// </summary>
        public DynamicPropertyObjectBase() : base()
        { }
        #endregion

        #region FIELDS
        private readonly Dictionary<string, PropertyDescriptor> propertyStore = new Dictionary<string, PropertyDescriptor>();
        #endregion

        #region FUNCTIONS

        /// <summary>
        /// Sets property value.
        /// </summary>
        /// <typeparam name="T">Value type.</typeparam>
        /// <param name="propertyName">Property name.</param>
        /// <param name="propertyValue">Property value.</param>
        public void SetPropertyValue<T>(string propertyName, T propertyValue)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentNullException(nameof(propertyName));

            var properties = GetProperties()
                                    .Cast<PropertyDescriptor>()
                                    .Where(prop => prop.Name.Equals(propertyName));

            if (properties == null || properties.Count() != 1)
                throw new ArgumentNullException(nameof(propertyName));

            var property = properties.First();

            property.SetValue(this, propertyValue);

            RaisePropertyChanged(propertyName);
        }

        /// <summary>
        /// Gets property value.
        /// </summary>
        /// <typeparam name="T">Property type.</typeparam>
        /// <param name="propertyName">Property name.</param>
        /// <returns>Property value.</returns>
        public T GetPropertyValue<T>(string propertyName)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentNullException(nameof(propertyName));

            var properties = GetProperties()
                                .Cast<PropertyDescriptor>()
                                .Where(prop => prop.Name.Equals(propertyName));

            if (properties == null || properties.Count() != 1)
                throw new ArgumentNullException(nameof(propertyName));

            var property = properties.First();
            return (T)property.GetValue(this);
        }

        /// <summary>
        /// Adds a property to object.
        /// </summary>
        /// <typeparam name="T">Property type.</typeparam>
        /// <typeparam name="U">Component type.</typeparam>
        /// <param name="propertyName">Property name.</param>
        /// <returns>Property descriptor.</returns>
        public PropertyDescriptor AddProperty<T, U>(string propertyName) where U : PropertyChangedBase
        {
            return AddProperty(propertyName, new DynamicPropertyDescriptor<T>(propertyName, typeof(U)));
        }

        /// <summary>
        /// Adds a property to object.
        /// </summary>
        /// <typeparam name="T">Property type.</typeparam>
        /// <param name="propertyName">Property name.</param>
        /// <returns>Property descriptor.</returns>
        public PropertyDescriptor AddProperty<T>(string propertyName)
        {
            return AddProperty(propertyName, new DynamicPropertyDescriptor<T>(propertyName, GetType()));
        }

        /// <summary>
        /// Adds a property to object.
        /// </summary>
        /// <param name="propertyName">Property name.</param>
        /// <param name="customProperty">Custom property descriptor.</param>
        /// <returns>Property descriptor.</returns>
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

        /// <summary>
        /// Gets all properties.
        /// </summary>
        /// <returns>Property description collection.</returns>
        public virtual PropertyDescriptorCollection GetProperties()
        {
            var properties = new PropertyDescriptorCollection(TypeDescriptor.GetProperties(this, true)
                .Cast<PropertyDescriptor>()
                .Union(propertyStore.Values)
                .ToArray());

            return properties;
        }

        /// <summary>
        /// Gets all properties with specified attributes.
        /// </summary>
        /// <param name="attributes">Desired attributes.</param>
        /// <returns>Property description collection.</returns>
        public virtual PropertyDescriptorCollection GetProperties(Attribute[] attributes)
        {
            var properties = new PropertyDescriptorCollection(TypeDescriptor.GetProperties(this, attributes, true)
               .Cast<PropertyDescriptor>()
               .Union(propertyStore.Values)
               .ToArray());

            return properties;
        }

        /// <summary>
        /// Gets attributes.
        /// </summary>
        /// <returns>Attribute collection.</returns>
        public virtual AttributeCollection GetAttributes()
        {
            return TypeDescriptor.GetAttributes(this, true);
        }

        /// <summary>
        /// Gets editor.
        /// </summary>
        /// <param name="editorBaseType">Editor base type.</param>
        /// <returns>Editor object.</returns>
        public virtual object GetEditor(Type editorBaseType)
        {
            return TypeDescriptor.GetEditor(this, editorBaseType, true);
        }

        /// <summary>
        /// Gets class name.
        /// </summary>
        /// <returns>Class name.</returns>
        public virtual string GetClassName()
        {
            return TypeDescriptor.GetClassName(this, true);
        }

        /// <summary>
        /// Gets component name.
        /// </summary>
        /// <returns>Component name.</returns>
        public virtual string GetComponentName()
        {
            return TypeDescriptor.GetComponentName(this, true);
        }

        /// <summary>
        /// Gets converter.
        /// </summary>
        /// <returns>Type converter.</returns>
        public virtual TypeConverter GetConverter()
        {
            return TypeDescriptor.GetConverter(this, true);
        }

        /// <summary>
        /// Gets default property.
        /// </summary>
        /// <returns>Property descriptor.</returns>
        public virtual PropertyDescriptor GetDefaultProperty()
        {
            return TypeDescriptor.GetDefaultProperty(this, true);
        }

        /// <summary>
        /// Gets default event.
        /// </summary>
        /// <returns>Event descriptor.</returns>
        public virtual EventDescriptor GetDefaultEvent()
        {
            return TypeDescriptor.GetDefaultEvent(this, true);
        }

        /// <summary>
        /// Gets events.
        /// </summary>
        /// <returns>Event description collection.</returns>
        public virtual EventDescriptorCollection GetEvents()
        {
            return TypeDescriptor.GetEvents(this, true);
        }

        /// <summary>
        /// Gets events filtered by attributes.
        /// </summary>
        /// <param name="attributes">Attributes.</param>
        /// <returns>Event description collection.</returns>
        public virtual EventDescriptorCollection GetEvents(Attribute[] attributes)
        {
            return TypeDescriptor.GetEvents(this, attributes, true);
        }

        /// <summary>
        /// Gets property owner.
        /// </summary>
        /// <param name="pd">Property descriptor.</param>
        /// <returns>Owner object.</returns>
        public virtual object GetPropertyOwner(PropertyDescriptor pd)
        {
            return this;
        }

        #endregion
    }
    #endregion
}
