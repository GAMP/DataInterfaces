using System;

namespace CoreLib.Hooking
{
    #region IMouseHook
    public interface IMouseHook : IHookBase
    {
        /// <summary>
        /// Raised on mouse event.
        /// </summary>
        event EventHandler<MouseHookEventArgs> Event;
    }
    #endregion
}
