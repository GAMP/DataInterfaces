using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace SharedLib
{
    /// <summary>
    /// Base class for item classes.
    /// <remarks>
    /// This class provides an data and view model functionality.
    /// </remarks>
    /// </summary>
    [Serializable()]
    [DataContract()]
    public class ItemBase : PropertyChangedNotificator, IItemBase
    {
        #region Constructor
        public ItemBase()
        {
        }
        #endregion

        #region Fields
        private int id;
        #endregion

        #region Properties
        [DataMember(Name = "Id")]
        public virtual int ID
        {
            get { return this.id; }
            set
            {
                this.id = value;
                this.RaisePropertyChanged("ID");
            }
        }
        #endregion

        #region ViewModel Code

        #region Fields
        [NonSerialized()]
        protected bool isSelected = false;
        [NonSerialized()]
        private bool isInitializing = false;
        [NonSerialized()]
        private bool isInitialized = false;
        [NonSerialized()]
        private IItemBase container = null;
        [NonSerialized()]
        private bool isEnabled = true;
        [NonSerialized()]
        private bool isExpanded = false;
        [NonSerialized()]
        private bool isChecked = false;
        [NonSerialized()]
        private bool isFocused = false;
        [NonSerialized()]
        private bool isVirtual;
        #endregion

        #region Properties

        /// <summary>
        /// Checks if element initialization was previously completed.
        /// </summary>
        public bool IsInitialized
        {
            get { return this.isInitialized; }
            set
            {
                this.isInitialized = value;
                this.RaisePropertyChanged("IsInitialized");
            }
        }

        /// <summary>
        /// Gets or sest if object is initializing.
        /// </summary>
        public bool IsInitializing
        {
            get { return this.isInitializing; }
            set
            {
                this.isInitializing = value;
                this.isInitialized = !this.isInitializing;
                this.RaisePropertyChanged("IsInitialized");
                this.RaisePropertyChanged("IsInitializing");

            }
        }

        /// <summary>
        /// Gets or sets if object represents an virtual item.
        /// </summary>
        public virtual bool IsVirtual
        {
            get { return this.isVirtual; }
            set
            {
                this.isVirtual = value;
                this.RaisePropertyChanged("IsVirtual");
            }
        }

        /// <summary>
        /// Gets or sets item container.
        /// </summary>
        [XmlIgnore()]
        public virtual IItemBase Container
        {
            get { return this.container; }
            set
            {
                this.container = value;
                this.RaisePropertyChanged("Container");
            }
        }

        /// <summary>
        /// Gets or sets if item is enabled.
        /// </summary>
        public virtual bool IsEnabled
        {
            get { return this.isEnabled; }
            set
            {
                this.isEnabled = value;
                this.RaisePropertyChanged("IsEnabled");
            }
        }

        /// <summary>
        /// Gets or sets if item is selected.
        /// </summary>
        public virtual bool IsSelected
        {
            get { return this.isSelected; }
            set
            {
                this.isSelected = value;
                this.RaisePropertyChanged("IsSelected");
            }
        }

        /// <summary>
        /// Gets or sets if item is expanded.
        /// </summary>
        public virtual bool IsExpanded
        {
            get { return this.isExpanded; }
            set
            {
                this.isExpanded = value;
                this.RaisePropertyChanged("IsExpanded");
            }
        }

        /// <summary>
        /// Gets or sets if item is checked.
        /// </summary>
        public virtual bool IsChecked
        {
            get { return this.isChecked; }
            set
            {
                this.isChecked = value;
                this.RaisePropertyChanged("IsChecked");
            }
        }

        /// <summary>
        /// Gets or sets if item is focused.
        /// </summary>
        public virtual bool IsFocused
        {
            get { return this.isFocused; }
            set
            {
                this.isFocused = value;
                this.RaisePropertyChanged("IsFocused");
            }
        }       

        #endregion

        #endregion
    }
}
