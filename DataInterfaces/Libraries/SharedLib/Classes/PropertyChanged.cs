using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace SharedLib
{
    /// <summary>
    /// Property change base class.
    /// </summary>
    [Serializable()]
    [DataContract()]
    public abstract class PropertyChangedBase :
        INotifyPropertyChanged
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        public PropertyChangedBase() : base()
        { }
        #endregion

        #region FIELDS
        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        [field: NonSerialized()]
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region FUNCTIONS

        /// <summary>
        /// Raises PropertyChanged event for all properties in derived class.
        /// </summary>
        protected void RaisePropertyChanged()
        {
            RaisePropertyChanged(new PropertyChangedEventArgsEx());
        }

        /// <summary>
        /// Raises PropertyChanged event for specified property. 
        /// </summary>
        /// <param name="propertyName">Property name.</param>
        protected void RaisePropertyChanged(string propertyName)
        {
            //Null or empty string propertyName should be allowed http://msdn.microsoft.com/en-us/library/system.componentmodel.inotifypropertychanged.propertychanged.aspx
            RaisePropertyChanged(this, new PropertyChangedEventArgsEx(propertyName));
        }

        /// <summary>
        /// Raises PropertyChanged event.
        /// </summary>
        /// <param name="args">PropertyChangedEvent aruments.</param>
        protected void RaisePropertyChanged(PropertyChangedEventArgsEx args)
        {
            //Null or empty string propertyName should be allowed http://msdn.microsoft.com/en-us/library/system.componentmodel.inotifypropertychanged.propertychanged.aspx
            RaisePropertyChanged(this, args);
        }

        /// <summary>
        /// Raises PropertyChanged event.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="args">Event arguments.</param>
        protected void RaisePropertyChanged(object sender, PropertyChangedEventArgsEx args)
        {
            if (sender == null)
                throw new ArgumentNullException(nameof(sender));

            if (args == null)
                throw new ArgumentNullException(nameof(args));

            //process event in derived classes
            if (OnPropertyChanging(sender, args))
                PropertyChanged?.Invoke(sender, args);
        }

        /// <summary>
        /// This method is called when property changed and we aboout to raise PropertyChanged event.
        /// </summary>
        /// <returns>
        /// True if PropertyChanged should be raised otherwise false.
        /// </returns>
        /// <param name="sender">Event sender.</param>
        /// <param name="args">Event arguments.</param>
        protected virtual bool OnPropertyChanging(object sender, PropertyChangedEventArgsEx args)
        {
            return true;
        }

        /// <summary>
        /// This method is called once property has changed and processed.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="args">Event arguments.</param>
        protected virtual void OnPropertyChanged(object sender, PropertyChangedEventArgsEx args)
        { }

        /// <summary>
        /// Set the property with the specified value. If the value is not equal with the field then the field is
        /// set, a PropertyChanged event is raised and it returns true.
        /// </summary>
        /// <typeparam name="T">Type of the property.</typeparam>
        /// <param name="field">Reference to the backing field of the property.</param>
        /// <param name="value">The new value for the property.</param>
        /// <param name="propertyName">The property name. This optional parameter can be skipped
        /// because the compiler is able to create it automatically.</param>
        /// <returns>True if the value has changed, false if the old and new value were equal.</returns>
        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            //compare to the old value
            if (object.Equals(field, value)) { return false; }

            //get fields old value
            var oldValue = field;

            //set field to new value
            field = value;

            //create new arguments
            var args = new PropertyChangedEventArgsEx(propertyName, value, oldValue);

            //raise event
            RaisePropertyChanged(args);

            //inform subclasses
            OnPropertyChanged(this, args);

            //return true since property was changed
            return true;
        }

        /// <summary>
        /// Gets if specified property is ignored.
        /// </summary>
        /// <param name="owner">Propery owner.</param>
        /// <param name="propertyName">Property name.</param>
        /// <returns>True or false.</returns>
        protected bool IsIgnoredProperty(object owner, string propertyName)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentNullException(nameof(propertyName));

            if (owner == null)
                throw new ArgumentNullException(nameof(owner));

            var property = owner.GetType().GetProperty(propertyName);
            return property.GetCustomAttribute<IgnorePropertyModificationAttribute>() != null;
        }

        /// <summary>
        /// Gets if specified property is ignored.
        /// </summary>
        /// <param name="propertyName">Property name.</param>
        /// <returns>True or false.</returns>
        protected bool IsIgnoredProperty(string propertyName)
        {
            return IsIgnoredProperty(this, propertyName);
        }

        #endregion
    }
}
