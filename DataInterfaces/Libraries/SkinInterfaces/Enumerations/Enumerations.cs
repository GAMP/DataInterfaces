using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkinInterfaces
{
    #region ComponentTypes
    /// <summary>
    /// Custom Control type numeration.
    /// </summary>
    [Flags()]
    public enum ComponentTypes 
    {
        BaseControl = 0,
        Gadget = 1,
    } 
    #endregion
   
    #region ElementVisualState
    /// <summary>
    /// Represent visual state of our custom control or window.
    /// When changing this states the skin engine can react and perform the action needed to respond to the change.
    /// </summary>
    public enum ElementVisualState
    {
        /// <summary>
        /// This value is set when control is in normal state.
        /// </summary>
        Normal = 1,
        /// <summary>
        /// This value is set when control is maximized.
        /// </summary>
        Maximized = 2,
        /// <summary>
        /// This value is set when control is minimized.
        /// </summary>
        Minimized = 3,
        /// <summary>
        /// Same as minimized.
        /// </summary>
        Closed=4,
    } 
    #endregion

    #region RestoreType
    /// <summary>
    /// Restore visuals type enumeration.
    /// </summary>
    public enum RestoreType
    {
        None = 0,
        Width = 1,
        Height = 2,
        Margins = 4,
        Opacity = 8,
    } 
    #endregion    
}
