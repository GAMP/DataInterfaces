using System;

namespace Client
{
    /// <summary>
    /// Client activity event args.
    /// </summary>
    [Serializable()]
    public class ClientActivityEventArgs : EventArgs
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="activity">Current activity.</param>
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
