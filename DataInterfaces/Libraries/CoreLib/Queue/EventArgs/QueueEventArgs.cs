using System;

namespace CoreLib.Queue
{
    /// <summary>
    /// Queue event args.
    /// </summary>
    /// <typeparam name="T">Item type.</typeparam>
    public class QueueEventArgs<T> : EventArgs
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="item">Item.</param>
        public QueueEventArgs(T item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            Stamp = DateTime.Now;
            Item = item;
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets event time stamp.
        /// </summary>
        public DateTime Stamp
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets event args.
        /// </summary>
        public T Item
        {
            get;
            protected set;
        }

        #endregion
    }
}
