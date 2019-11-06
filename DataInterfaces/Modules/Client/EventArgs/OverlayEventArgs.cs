using System;

namespace Client
{
    /// <summary>
    /// Overlay event args.
    /// </summary>
    public class OverlayEventArgs : EventArgs
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="isOpen">Indicates if overlay is open.</param>
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
