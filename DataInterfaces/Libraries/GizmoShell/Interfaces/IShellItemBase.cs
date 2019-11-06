using System;

namespace GizmoShell
{
    /// <summary>
    /// Shell item base interface.
    /// </summary>
    public interface IShellItemBase
    {
        #region EVENTS
        
        /// <summary>
        /// Occours when item is updated.
        /// </summary>
        event EventHandler Update; 

        #endregion
    } 
}
