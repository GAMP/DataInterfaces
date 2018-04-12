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
        private int itemLimit = 0;
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets or sets maximum amount of view items.
        /// </summary>
        public int MaxItems
        {
            get { return this.itemLimit; }
            set
            {
                this.itemLimit = value;
                this.OnPropertyChanged(new ComponentModel.PropertyChangedEventArgs(nameof(this.MaxItems)));
                this.RefreshOrDefer();
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
                if (this.MaxItems <= 0)
                    return base.Count;

                var baseCount = base.Count;

                if (this.MaxItems > baseCount)
                    return baseCount;

                return this.MaxItems;
            }
        }

        #endregion
    }
}
