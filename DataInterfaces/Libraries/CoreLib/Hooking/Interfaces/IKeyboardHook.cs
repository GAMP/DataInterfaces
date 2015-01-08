using System;
using System.Windows.Forms;
using System.Windows.Input;

namespace CoreLib.Hooking
{
    #region IKeyboardHook
    public interface IKeyboardHook : IHookBase
    {
        event EventHandler<KeyboardHookEventArgs> HookEvent;
        KeyHook AddHandler(Keys key, ModifierKeys modifiers, EventHandler<KeyboardHookEventArgs> handler);
        KeyHook AddHandler(Keys key, ModifierKeys modifiers, KeyState state, EventHandler<KeyboardHookEventArgs> handler);        
        void RemoveHandler(KeyHook hook);
    }
    #endregion
}
