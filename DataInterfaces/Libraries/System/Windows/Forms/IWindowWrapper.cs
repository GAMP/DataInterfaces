namespace System.Windows.Forms
{
    /// <summary>
    /// Wraps a window handle.
    /// </summary>
    /// <remarks>
    /// Main use of the class is for compatibility with some apis.
    /// </remarks>
    public class IWindowWrapper : IWin32Window
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="handle">Window handle.</param>
        public IWindowWrapper(IntPtr handle)
        {
            Handle = handle;
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
