using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CoreLib
{
    /// <summary>
    /// IEnumerable extension class.
    /// </summary>
    public static partial class EnumerableExtensions
    {
        #region FUNCTIONS

        /// <summary>
        /// Gets if collection is equal to null or empty.
        /// </summary>
        /// <typeparam name="TSource">Collection item type.</typeparam>
        /// <param name="collection">Source collection.</param>
        /// <returns>True or false.</returns>
        public static bool IsNullOrEmpty<TSource>(this IEnumerable<TSource> collection)
        {
            if (collection == null)
                return true;
            return !collection.Any();
        }

        /// <summary>
        /// Selects a chunk.
        /// </summary>
        public static IEnumerable<IEnumerable<T>> Chunks<T>(this IEnumerable<T> enumerable,
                                            int chunkSize)
        {
            if (chunkSize < 1) throw new ArgumentException("chunkSize must be positive");

            using (var e = enumerable.GetEnumerator())
                while (e.MoveNext())
                {
                    var remaining = chunkSize;    // elements remaining in the current chunk
                    var innerMoveNext = new Func<bool>(() => --remaining > 0 && e.MoveNext());

                    yield return e.GetChunk(innerMoveNext);
                    while (innerMoveNext()) {/* discard elements skipped by inner iterator */}
                }
        }

        private static IEnumerable<T> GetChunk<T>(this IEnumerator<T> e,
                                                  Func<bool> innerMoveNext)
        {
            do yield return e.Current;
            while (innerMoveNext());
        }

        /// <summary>
        /// Returns the index of an item in a sequence.
        /// </summary>
        /// <typeparam name="TSource">Item source type.</typeparam>
        /// <param name="source">A sequence containing elements.</param>
        /// <param name="item">The item to locate.</param>       
        /// <returns>The index of the entry if it was found in the sequence; otherwise, -1.</returns>
        public static int IndexOf<TSource>(this IEnumerable<TSource> source, TSource item)
        {
            return IndexOf(source, item, null);
        }

        /// <summary>
        /// Returns the index of an item in a sequence.
        /// </summary>
        /// <typeparam name="TSource">Item source type.</typeparam>
        /// <param name="source">A sequence containing elements.</param>
        /// <param name="item">The item to locate.</param>
        /// <param name="itemComparer">The item equality comparer to use.  Pass null to use the default comparer.</param>   
        /// <returns>The index of the entry if it was found in the sequence; otherwise, -1.</returns>
        public static int IndexOf<TSource>(this IEnumerable<TSource> source, TSource item, IEqualityComparer<TSource> itemComparer)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (source is IList<TSource> listOfT)
                return listOfT.IndexOf(item);

            if (source is IList list)
                return list.IndexOf(item);

            int i = 0;
            foreach (TSource possibleItem in source)
            {
                if (itemComparer.Equals(item, possibleItem))
                    return i;
                i++;
            }
            return -1;
        }

        /// <summary>
        /// Recursively selects items.
        /// </summary>
        public static IEnumerable<T> SelectRecursive<T>(this IEnumerable<T> source, Func<T, IEnumerable<T>> selector)
        {
            foreach (var parent in source)
            {
                yield return parent;

                var children = selector(parent);
                foreach (var child in SelectRecursive(children, selector))
                    yield return child;
            }
        }

        #endregion
    }
}
