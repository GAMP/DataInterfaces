using System;

namespace CoreLib.Hooking
{
    /// <summary>
    /// Mouse hook implementation inteface.
    /// </summary>
    public interface IMouseHook : IHookBase
    {
        #region EVENTS
        /// <summary>
        /// Raised on mouse event.
        /// </summary>
        event EventHandler<MouseHookEventArgs> Event;
        #endregion
    }
}
