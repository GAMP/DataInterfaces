using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLib.Queue
{
    #region QueueEventArgs
    public class QueueEventArgs<T> : EventArgs
    {
        public QueueEventArgs(T item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            this.Stamp = DateTime.Now;
            this.Item = item;
        }

        public DateTime Stamp
        {
            get;
            protected set;
        }

        public T Item
        {
            get;
            protected set;
        }
    }
    #endregion
}
