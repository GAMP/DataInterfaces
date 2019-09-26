using System.Collections;

namespace System.Windows.Data
{
    /// <summary>
    /// Collection view that limits it view items.
    /// </summary>
    public class LimitedListCollectionView : ListCollectionView, IEnumerable
    {
        #region CONSTRUCTOR
        public LimitedListCollectionView(IList list)
            : base(list)
        {
            MaxItems = int.MaxValue;
        }
        #endregion

        #region PROPERTIES
        public int MaxItems { get; set; }
        #endregion

        #region OVERRIDES

        public override int Count { get { return Math.Min(base.Count, MaxItems); } }

        public override bool MoveCurrentToLast()
        {
            return base.MoveCurrentToPosition(Count - 1);
        }

        public override bool MoveCurrentToNext()
        {
            if (base.CurrentPosition == Count - 1)
                return base.MoveCurrentToPosition(base.Count);
            else
                return base.MoveCurrentToNext();
        }

        public override bool MoveCurrentToPrevious()
        {
            if (base.IsCurrentAfterLast)
                return base.MoveCurrentToPosition(Count - 1);
            else
                return base.MoveCurrentToPrevious();
        }

        public override bool MoveCurrentToPosition(int position)
        {
            if (position < Count)
                return base.MoveCurrentToPosition(position);
            else
                return base.MoveCurrentToPosition(base.Count);
        }

        #endregion

        #region IEnumerable Members

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
