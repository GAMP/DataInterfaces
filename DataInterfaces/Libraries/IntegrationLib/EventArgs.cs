using System;

namespace IntegrationLib
{
    #region AvailabilityEventArgs
    [Obsolete()]
    [Serializable()]
    public class AvailabilityEventArgs : EventArgs
    {
        #region Constructor
        public AvailabilityEventArgs(bool isAvailiable)
        {
            this.IsAvailable = isAvailiable;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets availability state.
        /// </summary>
        public bool IsAvailable
        {
            get;
            protected set;
        }
        #endregion
    } 
    #endregion
}
