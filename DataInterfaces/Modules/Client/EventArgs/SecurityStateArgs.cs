using System;

namespace Client
{
    [Serializable()]
    public class SecurityStateArgs : EventArgs
    {
        #region CONSTRUCTOR

        public SecurityStateArgs(bool isEnabled, bool wasEnabled)
        {
            IsEnabled = isEnabled;
            WasEnabled = wasEnabled;
        }

        public SecurityStateArgs(bool isEnabled, bool wasEnabled, bool activePolicy = false) : this(isEnabled, wasEnabled)
        {
            ActiveProfileChanged = activePolicy;
        }

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets if security is currently enabled.
        /// </summary>
        public bool IsEnabled
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets if security was previously enabled.
        /// </summary>
        public bool WasEnabled
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets if active security profile change caused this event.
        /// </summary>
        public bool ActiveProfileChanged
        {
            get;
            protected set;
        }

        #endregion
    }
}
