using System.Collections;
using System.Collections.Specialized;

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
            get { return this.MAX_ITEMS; }
            set
            {
                MAX_ITEMS = value;
                OnPropertyChanged(new ComponentModel.PropertyChangedEventArgs(nameof(this.MaxItems)));
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
                if (MaxItems <= 0)
                    return base.Count;

                var baseCount = base.Count;

                if (MaxItems > baseCount)
                    return baseCount;

                return MaxItems;
            }
        }

        protected override void ProcessCollectionChanged(NotifyCollectionChangedEventArgs args)
        {
            base.ProcessCollectionChanged(args);
            try
            {
                if (args.Action == NotifyCollectionChangedAction.Add || args.Action == NotifyCollectionChangedAction.Remove)
                {
                    RefreshOverride();
                }
            }
            catch
            {

            }
        }

        #endregion
    }
}
