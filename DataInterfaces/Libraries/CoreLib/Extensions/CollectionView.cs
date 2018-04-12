using System;
using System.Windows.Data;

namespace CoreLib
{
    /// <summary>
    /// CollectionView extension class.
    /// </summary>
    public static class CollectionViewExtension
    {
        /// <summary>
        /// Gets if current item is last.
        /// </summary>
        /// <param name="view">
        /// Collection view source.
        /// </param>
        /// <returns>
        /// True or false.
        /// </returns>
        public static bool IsCurrentLast(this ListCollectionView view)
        {
            if (view == null)
                throw new ArgumentNullException(nameof(view));

            return view.CurrentPosition == view.Count - 1;
        }

        /// <summary>
        /// Gets if current item is first.
        /// </summary>
        /// <param name="view">
        /// Collection view source.
        /// </param>
        /// <returns>
        /// True or false.
        /// </returns>
        public static bool IsCurrentFirst(this ListCollectionView view)
        {
            if (view == null)
                throw new ArgumentNullException(nameof(view));

            return view.CurrentPosition == 0;
        }
    }
}
