using System;

namespace Client
{
    /// <summary>
    /// Message dialog buttons.
    /// </summary>
    [Flags()]
    public enum MessageDialogButtons
    {
        /// <summary>
        /// None.
        /// </summary>
        None = 0,
        /// <summary>
        /// Accept.
        /// </summary>
        Accept = 1,
        /// <summary>
        /// Cancel.
        /// </summary>
        Cancel = 2,
        /// <summary>
        /// Accept or cancel.
        /// </summary>
        AcceptCancel = Accept | Cancel,
    }
}
