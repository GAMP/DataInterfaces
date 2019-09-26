using System;
using System.Windows.Data;

namespace SkinInterfaces
{
    /// <summary>
    /// CollectionView extension class.
    /// </summary>
    public static class CollectionViewExtension
    {
        #region FUNCTIONS
        
        /// <summary>
        /// Gets if current item is last.
        /// </summary>
        /// <param name="collectionView">
        /// Collection view source.
        /// </param>
        /// <returns>
        /// True or false.
        /// </returns>
        public static bool IsCurrentLast(this ListCollectionView collectionView)
        {
            if (collectionView == null)
                throw new ArgumentNullException(nameof(collectionView));

            return collectionView.CurrentPosition == collectionView.Count - 1;
        }

        /// <summary>
        /// Gets if current item is first.
        /// </summary>
        /// <param name="collectionView">
        /// Collection view source.
        /// </param>
        /// <returns>
        /// True or false.
        /// </returns>
        public static bool IsCurrentFirst(this ListCollectionView collectionView)
        {
            if (collectionView == null)
                throw new ArgumentNullException(nameof(collectionView));

            return collectionView.CurrentPosition == 0;
        } 

        #endregion
    }
}
