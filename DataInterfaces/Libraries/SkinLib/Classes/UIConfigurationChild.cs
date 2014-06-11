using SharedLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkinLib
{
    #region UIConfigurationChild
    public abstract class UIConfigurationChild : PropertyChangedNotificator
    {
        #region Constructor
        public UIConfigurationChild(UIConfiguration config)
        {
            if (config == null)
                throw new ArgumentNullException("Config", "Configuration instance may not be null");

            this.Configuration = config;
        }
        #endregion

        #region Fields
        private UIConfiguration configuration;
        #endregion

        #region Properties

        /// <summary>
        /// Gets the parent configuration of this layout.
        /// </summary>
        public UIConfiguration Configuration
        {
            get { return this.configuration; }
            protected set
            {
                this.configuration = value;
                this.RaisePropertyChanged("Configuration");
            }
        }

        #endregion
    }
    #endregion
}
