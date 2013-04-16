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
    /// </summary>
    [Serializable()]
    public class UIComponent : PropertyChangedNotificator, IUIComponent
    {
        #region Constructor

        public UIComponent()
        {
        }
        public UIComponent(Type Type)
        {
            this.AssemblyName = Type.Assembly.FullName;
            this.Type = Type.FullName;
            this.GUID = System.Guid.NewGuid().ToString();
        }
        #endregion

        #region Fields
        private string mGuid,
            mAssemblyname,
            mType,
            mTitle,
            mDescription;
        [NonSerialized()]
        private FrameworkElement mElement;
        #endregion
      
        #region Properties
        /// <summary>
        /// Gets or sets components GUID.
        /// </summary>
        public string GUID
        {
            get { return this.mGuid; }
            set
            {
                this.mGuid = value;
                this.RaisePropertyChanged("GUID");
            }
        }
        /// <summary>
        /// Gets or sets components assembly.
        /// </summary>
        public string AssemblyName
        {
            get { return this.mAssemblyname; }
            set
            {
                this.mAssemblyname = value;
                this.RaisePropertyChanged("AssemblyName");
            }
        }
        /// <summary>
        /// Gets or sets components type.
        /// </summary>
        public string Type
        {
            get { return this.mType; }
            set { this.mType = value; }
        }
        /// <summary>
        /// Gets the elements instance assigned to this component.
        /// </summary>
        public FrameworkElement Element
        {
            get { return this.mElement; }
            set
            {
                this.mElement = value;
                this.RaisePropertyChanged("Element");
            }
        }
        /// <summary>
        /// Gets or sets components title.
        /// </summary>
        public string Title
        {
            get { return this.mTitle; }
            set
            {
                this.mTitle = value;
                this.RaisePropertyChanged("Title");
            }
        }
        /// <summary>
        /// Gets or sets components description.
        /// </summary>
        public string Description
        {
            get { return this.mDescription; }
            set
            {
                this.mDescription = value;
                this.RaisePropertyChanged("Description");
            }
        }
        #endregion

        #region Ovverides
        public override string ToString()
        {
            return this.Type;
        }
        #endregion
    }
}
