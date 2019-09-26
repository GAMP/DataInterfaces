using System;

namespace Client
{
    /// <summary>
    /// Overlay event args.
    /// </summary>
    public class OverlayEventArgs : EventArgs
    {
        #region CONSTRUCTOR
        public OverlayEventArgs(bool isOpen)
        {
            IsOpen = isOpen;
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets if overlay is currently open.
        /// </summary>
        public bool IsOpen
        {
            get; protected set;
        }

        #endregion
    }
}
