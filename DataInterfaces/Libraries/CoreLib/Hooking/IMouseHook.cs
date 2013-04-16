using System;

namespace CoreLib.Hooking
{
    #region IMouseHook
    public interface IMouseHook : IHookBase
    {
        event MouseHookEventHandler Event;
    }
    #endregion
}
