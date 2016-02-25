using System;
using System.Windows.Forms;
using System.Windows.Input;

namespace CoreLib.Hooking
{
    #region IKeyboardHook
    public interface IKeyboardHook : IHookBase
    {
        /// <summary>
        /// Raised on key event.
        /// </summary>
        event EventHandler<KeyboardHookEventArgs> HookEvent;

        /// <summary>
        /// Creates a new key hook.
        /// </summary>
        /// <param name="key">Key.</param>
        /// <param name="modifiers">Modifiers.</param>
        /// <param name="handler">Hook event handler.</param>
        /// <returns>Key hook configuration isntance.</returns>
        KeyHook AddHandler(Keys key, ModifierKeys modifiers, EventHandler<KeyboardHookEventArgs> handler);

        /// <summary>
        /// Creates a new key hook.
        /// </summary>
        /// <param name="key">Key.</param>
        /// <param name="modifiers">Modifiers.</param>
        /// <param name="state">Key state.</param>
        /// <param name="handler">Hook event handler.</param>
        /// <returns>Key hook configuration isntance.</returns>
        KeyHook AddHandler(Keys key, ModifierKeys modifiers, KeyState state, EventHandler<KeyboardHookEventArgs> handler);        

        /// <summary>
        /// Removes existing key hook configuration.
        /// </summary>
        /// <param name="hook">Key hook configuration.</param>
        void RemoveHandler(KeyHook hook);
    }
    #endregion
}
