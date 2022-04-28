using System;
using System.Runtime.Serialization;

namespace SharedLib
{
    /// <summary>
    /// Base class for item objects.
    /// </summary>
    [Serializable()]
    [DataContract()]
    public abstract class ItemObject : PropertyChangedNotificator
    {
        #region Fields
        private int id;
        #endregion

        #region Properties
        [DataMember()]
        public int Id
        {
            get { return this.id; }
            set
            {
                this.id = value;
                this.RaisePropertyChanged("Id");
            }
        }
        #endregion
    }
}
