using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharedLib;
using System.Windows;

namespace SkinLib
{
    /// <summary>
    /// UI Component class.
    /// This class represents UI Component configuration.
    /// </summary>
    [Serializable()]
    public class UIComponent :
        UIConfigurationChild, 
        IUIComponent
    {
        #region Constructor

        public UIComponent(UIConfiguration config):base(config)
        {
        }

        #endregion

        #region Fields
        private string 
            guid,
            assemblyName,
            type,
            title,
            description;
        [NonSerialized()]
        private FrameworkElement element;
        #endregion
      
        #region Properties

        /// <summary>
        /// Gets or sets component GUID.
        /// </summary>
        public string GUID
        {
            get { return this.guid; }
            set
            {
                this.guid = value;
                this.RaisePropertyChanged("GUID");
            }
        }

        /// <summary>
        /// Gets or sets component assembly name.
        /// </summary>
        public string AssemblyName
        {
            get { return this.assemblyName; }
            set
            {
                this.assemblyName = value;
                this.RaisePropertyChanged("AssemblyName");
            }
        }

        /// <summary>
        /// Gets or sets component type.
        /// </summary>
        public string Type
        {
            get { return this.type; }
            set { this.type = value; }
        }

        /// <summary>
        /// Gets or sets component title.
        /// </summary>
        public string Title
        {
            get { return this.title; }
            set
            {
                this.title = value;
                this.RaisePropertyChanged("Title");
            }
        }

        /// <summary>
        /// Gets or sets component description.
        /// </summary>
        public string Description
        {
            get { return this.description; }
            set
            {
                this.description = value;
                this.RaisePropertyChanged("Description");
            }
        }

        /// <summary>
        /// Gets the elements instance assigned to this component.
        /// </summary>
        public FrameworkElement Instance
        {
            get { return this.element; }
            set
            {
                this.element = value;
                this.RaisePropertyChanged("Instance");
            }
        }

        /// <summary>
        /// Gets if this component instance has been created.
        /// </summary>
        public bool HasInstance
        {
            get { return this.Instance != null; }
        }

        #endregion

        #region OVERRIDES

        public override string ToString()
        {
            return this.Type;
        }
        
        #endregion
    }
}
