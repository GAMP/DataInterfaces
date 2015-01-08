using System;

namespace CoreLib.Hooking
{
    #region IMouseHook
    public interface IMouseHook : IHookBase
    {
        event EventHandler<MouseHookEventArgs> Event;
    }
    #endregion
}
