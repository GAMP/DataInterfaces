using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IntegrationLib
{
    #region AvailabilityEventArgs
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
