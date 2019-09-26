using System;

namespace GizmoShell
{
    #region IShellItemBase
    public interface IShellItemBase
    {
        /// <summary>
        /// Occours when item is updated.
        /// </summary>
        event EventHandler Update;
    } 
    #endregion
}
