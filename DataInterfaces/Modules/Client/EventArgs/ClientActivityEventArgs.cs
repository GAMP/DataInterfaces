using System;

namespace Client
{
    [Serializable()]
    public class ClientActivityEventArgs : EventArgs
    {
        #region CONSTRUCTOR
        public ClientActivityEventArgs(ClientStartupActivity activity)
        {
            Activity = activity;
        }
        #endregion

        #region PROPERTIES
        /// <summary>
        /// Gets current client activity.
        /// </summary>
        public ClientStartupActivity Activity
        {
            get;
            protected set;
        }
        #endregion
    }
}
