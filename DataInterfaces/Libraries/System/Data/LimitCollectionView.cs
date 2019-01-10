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
                    return 0;

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

            if(item!=null)
            {
                return IndexOf(item) < MaxItems;
            }

            return true;
        }

        #endregion
    }
}
