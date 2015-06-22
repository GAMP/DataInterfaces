using SkinInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace SkinLib
{
    #region UIModuleVisualStateChangeArgs
    public class UIModuleVisualStateChangeArgs : EventArgs
    {
        #region CONSTRUCTOR
        public UIModuleVisualStateChangeArgs(FrameworkElement module, ElementVisualState newState, ElementVisualState oldState)
        {
            if (module == null)
                throw new ArgumentNullException(nameof(module));

            this.Module = module;
            this.NewState = newState;
            this.OldState = oldState;
        }
        #endregion

        #region PROPERTIES
        
        /// <summary>
        /// Gets new state.
        /// </summary>
        public ElementVisualState NewState
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets old state.
        /// </summary>
        public ElementVisualState OldState
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets or sets if event is handled.
        /// </summary>
        public bool Handled
        {
            get;
            set;
        } 

        /// <summary>
        /// Gets ui module caused this event.
        /// </summary>
        public FrameworkElement Module
        {
            get; protected set;
        }

        #endregion
    }
    #endregion

}
