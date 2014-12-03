using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreLib.Hooking
{
    #region Delegates
    public delegate void KeyboardHookEventHandler(object sender, KeyboardHookEventArgs e);
    public delegate void MouseHookEventHandler(object sender, MouseHookEventArgs e);
    #endregion
}
