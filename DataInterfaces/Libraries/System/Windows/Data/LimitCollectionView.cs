using System.Collections;

namespace System.Windows.Data
{
    /// <summary>
    /// Collection view that limits it view items.
    /// </summary>
    public class LimitedListCollectionView : ListCollectionView, IEnumerable
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="list">Source IList.</param>
        public LimitedListCollectionView(IList list)
            : base(list)
        {
            MaxItems = int.MaxValue;
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets or sets maximum items.
        /// </summary>
        public int MaxItems { get; set; }
        
        #endregion

        #region OVERRIDES

        /// <summary>
        /// Gets item count.
        /// </summary>
        public override int Count { get { return Math.Min(base.Count, MaxItems); } }

        /// <summary>
        /// Moves current to last.
        /// </summary>
        /// <returns>True for success, otherwise false.</returns>
        public override bool MoveCurrentToLast()
        {
            return base.MoveCurrentToPosition(Count - 1);
        }

        /// <summary>
        /// Moves current to next.
        /// </summary>
        /// <returns>True for success, otherwise false.</returns>
        public override bool MoveCurrentToNext()
        {
            if (base.CurrentPosition == Count - 1)
                return base.MoveCurrentToPosition(base.Count);
            else
                return base.MoveCurrentToNext();
        }

        /// <summary>
        /// Moves current to previous.
        /// </summary>
        /// <returns>True for success, otherwise false.</returns>
        public override bool MoveCurrentToPrevious()
        {
            if (base.IsCurrentAfterLast)
                return base.MoveCurrentToPosition(Count - 1);
            else
                return base.MoveCurrentToPrevious();
        }

        /// <summary>
        /// Moves current to specified position.
        /// </summary>
        /// <param name="position">Position index.</param>
        /// <returns>True for success, otherwise false.</returns>
        public override bool MoveCurrentToPosition(int position)
        {
            if (position < Count)
                return base.MoveCurrentToPosition(position);
            else
                return base.MoveCurrentToPosition(base.Count);
        }

        #endregion

        #region IEnumerable Members

        /// <summary>
        /// Gets enumerator.
        /// </summary>
        /// <returns>Enumerator.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            do
            {
                yield return CurrentItem;
            } while (MoveCurrentToNext());
        }

        #endregion
    }
}
