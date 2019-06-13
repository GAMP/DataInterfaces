using System.Collections;

namespace System.Windows.Data
{
    /// <summary>
    /// Collection view that limits it view items.
    /// </summary>
    public class LimitCollectionView : ListCollectionView
    {
        #region CONSTRUCTOR
        public LimitCollectionView(IList source) : base(source)
        {          
        }
        #endregion

        #region FIELDS
        private int MAX_ITEMS = 0;
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets or sets maximum amount of view items.
        /// </summary>
        public int MaxItems
        {
            get { return MAX_ITEMS; }
            set
            {
                MAX_ITEMS = value;
                OnPropertyChanged(new ComponentModel.PropertyChangedEventArgs(nameof(MaxItems)));
                RefreshOrDefer();
            }
        }

        #endregion

        #region OVERRIDES

        /// <summary>
        /// Gets the estimated number of records.
        /// </summary>
        public override int Count
        {
            get
            {
                if (IsRefreshDeferred)
                    return base.Count;

                if (MaxItems <= 0)
                    return base.Count;        

                var baseCount = base.Count;

                if (MaxItems > baseCount)
                    return baseCount;

                return Math.Min(MaxItems,baseCount);
            }
        }

        public override bool PassesFilter(object item)
        {
            if (!base.PassesFilter(item))
                return false;

            if (MaxItems > 0)
            {
                if (item != null)
                {
                    return IndexOf(item) + 1 < MaxItems;
                }
            }

            return true;
        }

        #endregion
    }

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
