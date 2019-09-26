using System;

namespace Client
{
    public class ProfilesChangeEventArgs : EventArgs
    {
        #region CONSTRUCTOR
        public ProfilesChangeEventArgs(bool isInitial)
        {
            IsInitial = isInitial;
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets if event was created by initial change of profiles.
        /// </summary>
        public bool IsInitial
        {
            get;
            protected set;
        }

        #endregion
    }
}
