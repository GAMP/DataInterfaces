using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreLib
{
    #region IWindowWrapper
    public class IWindowWrapper : System.Windows.Forms.IWin32Window
    {
        public IWindowWrapper(IntPtr handle)
        {
            this.Handle = handle;
        }

        public IntPtr Handle
        {
            get;
            protected set;
        }
    }
    #endregion
}
