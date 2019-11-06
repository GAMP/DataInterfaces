using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace SharedLib
{
    /// <summary>
    /// Extended PropertyChangedEventArgs class.
    /// </summary>
    [Serializable()]
    [DataContract]
    public class PropertyChangedEventArgsEx : PropertyChangedEventArgs
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Creates new instance.
        /// </summary>
        public PropertyChangedEventArgsEx()
            : base(null)
        { }

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="propertyName">Property name.</param>
        public PropertyChangedEventArgsEx(string propertyName)
            : base(propertyName)
        { }

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="propertyName">Property name.</param>
        /// <param name="newValue">New value.</param>
        public PropertyChangedEventArgsEx(string propertyName, object newValue)
            : base(propertyName)
        {
            NewValue = newValue;
        }

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="propertyName">Property name.</param>
        /// <param name="newValue">New value.</param>
        /// <param name="oldValue">Old value.</param>
        public PropertyChangedEventArgsEx(string propertyName, object newValue, object oldValue)
            : base(propertyName)
        {
            NewValue = newValue;
            OldValue = oldValue;
        }

        #endregion

        #region PROPERTIES

        /// <summary>
        ///Gets the new value of the object.
        /// </summary>
        [DataMember()]
        public object NewValue
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets the old value of the object.
        /// </summary>
        [DataMember()]
        public object OldValue
        {
            get;
            protected set;
        }

        #endregion
    }
}
