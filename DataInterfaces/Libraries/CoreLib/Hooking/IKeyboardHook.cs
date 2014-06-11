using System;
using System.Windows.Forms;
using System.Windows.Input;

namespace CoreLib.Hooking
{
    #region IKeyboardHook
    public interface IKeyboardHook : IHookBase
    {
        event KeyboardHookEventHandler HookEvent;
        KeyHook AddHandler(Keys key,ModifierKeys modifiers, KeyboardHookEventHandler handler);
        KeyHook AddHandler(Keys key, ModifierKeys modifiers, KeyState state, KeyboardHookEventHandler handler);        
        void RemoveHandler(KeyHook hook);
    }
    #endregion
}
