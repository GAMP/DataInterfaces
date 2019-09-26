using System;

namespace Client
{
    [Serializable()]
    public class IdChangeEventArgs : EventArgs
    {
        #region CONSTRUCTOR
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
