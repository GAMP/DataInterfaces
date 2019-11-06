using System;

namespace Client
{
    /// <summary>
    /// Out of order state change event args.
    /// </summary>
    [Serializable()]
    public class OutOfOrderStateEventArgs : EventArgs
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="newState">New state.</param>
        public OutOfOrderStateEventArgs(bool newState)
        {
            IsOutOfOrder = newState;
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets if out of order.
        /// </summary>
        public bool IsOutOfOrder
        {
            get;
            private set;
        }

        #endregion
    }
}
