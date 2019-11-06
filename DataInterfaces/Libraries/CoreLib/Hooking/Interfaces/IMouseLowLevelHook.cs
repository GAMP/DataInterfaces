using System;

namespace CoreLib.Hooking
{
    /// <summary>
    /// Low level mouse hook implementation.
    /// </summary>
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
