using System;

namespace CoreLib.Hooking
{
    #region IKeyboardHook
    public interface IKeyboardHook : IHookBase
    {
        global::CoreLib.Hooking.KeyHook AddHandler(global::System.Windows.Forms.Keys key,
            global::System.Windows.Input.ModifierKeys modifiers, global::CoreLib.Hooking.KeyboardHookEventHandler handler);
        global::CoreLib.Hooking.KeyHook AddHandler(global::System.Windows.Forms.Keys key, 
            global::System.Windows.Input.ModifierKeys modifiers, global::CoreLib.Hooking.KeyState state, global::CoreLib.Hooking.KeyboardHookEventHandler handler);
        event global::CoreLib.Hooking.KeyboardHookEventHandler HookEvent;
        void RemoveHandler(global::CoreLib.Hooking.KeyHook hook);
    }
    #endregion
}
