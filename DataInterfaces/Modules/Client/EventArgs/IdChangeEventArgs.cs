using System;

namespace Client
{
    /// <summary>
    /// Client id changed event args.
    /// </summary>
    [Serializable()]
    public class IdChangeEventArgs : EventArgs
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="newId">New id.</param>
        /// <param name="oldId">Old id.</param>
        public IdChangeEventArgs(int newId, int oldId)
        {
            NewId = newId;
            OldId = oldId;
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets new id.
        /// </summary>
        public int NewId
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets old id.
        /// </summary>
        public int OldId
        {
            get;
            protected set;
        }

        #endregion
    }
}
