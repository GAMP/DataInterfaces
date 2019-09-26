using System;

namespace Client
{
    [Serializable()]
    public class OutOfOrderStateEventArgs : EventArgs
    {
        #region CONSTRUCTOR
        public OutOfOrderStateEventArgs(bool newState)
        {
            IsOutOfOrder = newState;
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets if out of order is currently set.
        /// </summary>
        public bool IsOutOfOrder
        {
            get;
            private set;
        }

        #endregion
    }
}
