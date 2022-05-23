using System;
using System.ComponentModel;

namespace SharedLib
{
    [Serializable()]
    public class PropertyChangedNotificator : INotifyPropertyChanged
    {
        #region FIELDS
        [field: NonSerialized()]
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region FUNCTIONS

        protected void RaisePropertyChanged(string propertyName)
        {
            //Null or empty  string propertyName should be allowed http://msdn.microsoft.com/en-us/library/system.componentmodel.inotifypropertychanged.propertychanged.aspx

            //get handler instance
            var handler = this.PropertyChanged;

            //check if handler exists
            if (handler != null)
            {
                var args = new PropertyChangedEventArgs(propertyName);

                handler(this, args);
            }

            this.OnPropertyChanged(propertyName);
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
        }

        #endregion
    }
}
