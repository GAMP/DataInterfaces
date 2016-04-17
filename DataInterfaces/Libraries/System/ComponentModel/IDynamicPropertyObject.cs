using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.ComponentModel
{
    /// <summary>
    /// Dynamic object interface.
    /// Used for adding dynamic properties to implementing classes.
    /// </summary>
    public interface IDynamicPropertyObject
    {
        /// <summary>
        /// Adds a new property to the class.
        /// </summary>
        /// <typeparam name="T">Property type.</typeparam>
        /// <param name="propertyName">Property name.</param>
        /// <returns>Added property descriptor.</returns>
        PropertyDescriptor AddProperty<T>(string propertyName);

        /// <summary>
        /// Gets value of existing property.
        /// </summary>
        /// <typeparam name="T">Property value type.</typeparam>
        /// <param name="propertyName">Property name.</param>
        /// <returns>Property value.</returns>
        /// <exception cref="System.ArgumentNullException">Thrown when no property found with specified property name.</exception>
        T GetPropertyValue<T>(string propertyName);

        /// <summary>
        /// Sets value of existing property.
        /// </summary>
        /// <typeparam name="T">Property value type.</typeparam>
        /// <param name="propertyName"></param>
        /// <param name="propertyValue">Property value.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when no property found with specified property name.</exception>
        /// <exception cref="System.ArgumentException">When property value type and specified value types dont match.</exception>
        void SetPropertyValue<T>(string propertyName, T propertyValue);
    }
}
