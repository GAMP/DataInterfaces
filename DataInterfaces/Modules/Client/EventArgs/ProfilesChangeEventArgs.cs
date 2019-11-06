using System;

namespace Client
{
    /// <summary>
    /// Profiles change event args.
    /// </summary>
    public class ProfilesChangeEventArgs : EventArgs
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="isInitial">Indicates if change is initial.</param>
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
