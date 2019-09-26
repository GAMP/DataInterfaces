using System;

namespace CoreLib.Hooking
{
    public interface IMouseLowLevelHook : IHookBase
    {
        #region EVENTS

        /// <summary>
        /// Raised on mouse event.
        /// </summary>
        event EventHandler<MouseLowLevelHookEventArgs> Event;

        #endregion
    }
}
