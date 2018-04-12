namespace System.ComponentModel
{
    /// <summary>
    /// Dynamic object interface.
    /// Used for adding dynamic properties to implementing classes.
    /// </summary>
    public interface IDynamicPropertyObject
    {
        #region FUNCTIONS
        
        /// <summary>
        /// Adds a new property to the class.
        /// </summary>
        /// <typeparam name="T">Property type.</typeparam>
        /// <param name="propertyName">Property name.</param>
        /// <returns>Added property descriptor.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if specified <paramref name="propertyName"/> equals to null or empty string.
        /// </exception>
        PropertyDescriptor AddProperty<T>(string propertyName);

        /// <summary>
        /// Gets value of existing property.
        /// </summary>
        /// <typeparam name="T">Property value type.</typeparam>
        /// <param name="propertyName">Property name.</param>
        /// <returns>Property value.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when no property found with specified <paramref name="propertyName"/>.
        /// </exception>
        T GetPropertyValue<T>(string propertyName);

        /// <summary>
        /// Sets value of existing property.
        /// </summary>
        /// <typeparam name="T">Property value type.</typeparam>
        /// <param name="propertyName"></param>
        /// <param name="propertyValue">Property value.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if specified <paramref name="propertyName"/> equals to null or empty string.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown when no property found with specified <paramref name="propertyName"/>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// When property value type and specified value types dont match.
        /// </exception>
        void SetPropertyValue<T>(string propertyName, T propertyValue); 

        #endregion
    }
}
