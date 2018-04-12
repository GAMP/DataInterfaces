using System;

namespace CoreLib
{
    public class IWindowWrapper : System.Windows.Forms.IWin32Window
    {
        #region CONSTRUCTOR
        public IWindowWrapper(IntPtr handle)
        {
            this.Handle = handle;
        }
        #endregion

        #region PROPERTIES
        /// <summary>
        /// Gets window handle.
        /// </summary>
        public IntPtr Handle
        {
            get;
            protected set;
        }
        #endregion
    }
}
