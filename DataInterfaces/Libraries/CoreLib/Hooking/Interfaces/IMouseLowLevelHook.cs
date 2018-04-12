using System;

namespace CoreLib.Hooking
{
    public interface IMouseLowLevelHook : IHookBase
    {
        /// <summary>
        /// Raised on mouse event.
        /// </summary>
        event EventHandler<MouseLowLevelHookEventArgs> Event;
    }
}
