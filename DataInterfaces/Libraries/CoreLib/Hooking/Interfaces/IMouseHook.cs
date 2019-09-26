using System;

namespace CoreLib.Hooking
{
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
