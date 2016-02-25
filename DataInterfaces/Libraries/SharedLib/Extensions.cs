using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SharedLib.Extensions
{
    #region ListExtensions
    public static class ListExtensions
    {
        /// <summary>
        /// Moves item up in specified list.
        /// </summary>
        /// <typeparam name="T">Item type.</typeparam>
        /// <param name="list">Source list.</param>
        /// <param name="item">Item instance.</param>
        public static void MoveUp<T>(this IList<T> list, T item)
        {
            if (item == null)
                throw new ArgumentNullException("item");

            int currentindex = list.IndexOf(item);
            int nextindex = currentindex - 1;
            int maxindex = -1;
            if (nextindex > maxindex)
                list.Move(currentindex, nextindex);
        }

        /// <summary>
        /// Moves item down in specified list.
        /// </summary>
        /// <typeparam name="T">Item type.</typeparam>
        /// <param name="list">Source list.</param>
        /// <param name="item">Item instance.</param>
        public static void MoveDown<T>(this IList<T> list, T item)
        {
            if (item == null)
                throw new ArgumentNullException("item");

            int currentindex = list.IndexOf(item);
            int nextindex = currentindex + 1;
            int maxindex = list.Count;
            if (nextindex < maxindex)
                list.Move(currentindex, nextindex);
        }

        /// <summary>
        /// Moves item in specified list.
        /// </summary>
        /// <param name="list">Source list.</param>
        /// <param name="oldIndex">Old item index.</param>
        /// <param name="newIndex">New item index.</param>
        public static void Move<T>(this IList<T> list, int oldIndex, int newIndex)
        {
            var method = list.GetType().GetMethod("Move");
            method.Invoke(list, new object[] { oldIndex, newIndex });
        }

        /// <summary>
        /// Replaces specified item in list.
        /// </summary>
        /// <typeparam name="T">Item type.</typeparam>
        /// <param name="list">Source list.</param>
        /// <param name="oldItem">Old item instance.</param>
        /// <param name="newItem">New item instance.</param>
        /// <remarks>
        /// If old item not found new item will be still added to the source list.
        /// </remarks>
        public static void Replace<T>(this IList<T> list, T oldItem, T newItem)
        {
            if (oldItem == null)
                throw new ArgumentNullException("oldItem");

            if (newItem == null)
                throw new ArgumentNullException("newItem");

            int index = list.IndexOf(oldItem);
            if (index != -1)
            {
                list.Insert(index, newItem);
                list.Remove(oldItem);
            }
            else
            {
                list.Add(newItem);
            }
        }

        /// <summary>
        /// Adds range of items into specified list.
        /// </summary>
        /// <typeparam name="T">Item type.</typeparam>
        /// <param name="list">Source list.</param>
        /// <param name="items">Items collection.</param>
        public static void AddRange<T>(this IList<T> list, IEnumerable items)
        {
            if (list == null)
                throw new ArgumentNullException("list");

            if (items == null)
                throw new ArgumentNullException("items");

            foreach (T item in items)
                list.Add(item);
        }

        /// <summary>
        /// Removes range of items from specified list.
        /// </summary>
        /// <typeparam name="T">Item type.</typeparam>
        /// <param name="list"></param>
        /// <param name="items"></param>
        public static void RemoveRange<T>(this IList<T> list, IEnumerable items)
        {
            if (list == null)
                throw new ArgumentNullException("list");

            if (items == null)
                throw new ArgumentNullException("items");

            foreach (T item in items)
                list.Remove(item);
        }

        /// <summary>
        /// Returns the index of an item in a sequence.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence containing elements.</param>
        /// <param name="item">The item to locate.</param>        
        /// <returns>The index of the entry if it was found in the sequence; otherwise, -1.</returns>
        public static int IndexOf<TSource>(this IEnumerable<TSource> source, TSource item)
        {
            return IndexOf<TSource>(source, item, null);
        }

        /// <summary>
        /// Returns the index of an item in a sequence.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence containing elements.</param>
        /// <param name="item">The item to locate.</param>
        /// <param name="itemComparer">The item equality comparer to use.  Pass null to use the default comparer.</param>
        /// <returns>The index of the entry if it was found in the sequence; otherwise, -1.</returns></returns>
        public static int IndexOf<TSource>(this IEnumerable<TSource> source, TSource item, IEqualityComparer<TSource> itemComparer)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            IList<TSource> listOfT = source as IList<TSource>;
            if (listOfT != null)
                return listOfT.IndexOf(item);

            IList list = source as IList;
            if (list != null)
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
    }
    #endregion

    public static class ObjectExtensions
    {
        public static void SyncEntity(object source, object destination ,string[] propertySet)
        {
            #region VALIDATION
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (destination == null)
                throw new ArgumentNullException(nameof(destination));

            var sourceType = source.GetType();
            var destinationType = destination.GetType();

            if (sourceType != destinationType)
                throw new ArgumentException(nameof(destinationType));
            #endregion

            #region PROPERTIES
            var properties = propertySet.Select(propertyName => sourceType.GetProperty(propertyName))
                .Where(property=> property!=null)
                .ToList();

            foreach (var property in properties)
            {
                var sourceValue = property.GetValue(source);
                property.SetValue(destination, sourceValue);
            }
            #endregion

            #region REFERENCE PROPERTIES
            #endregion

            #region IENUMERABLE

            var iEnumerableType = typeof(IEnumerable);

            var enumerableProperties = sourceType.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(x => x.PropertyType.GetInterface(iEnumerableType.FullName) != null &&
                x.PropertyType != typeof(string));

            foreach (var enumerableProperty in enumerableProperties)
            {
                var sourceEnumerable = (IEnumerable)enumerableProperty.GetValue(source);
                var destinationEnumerable = (IEnumerable)enumerableProperty.GetValue(destination);

                var sourceList = sourceEnumerable.OfType<object>().ToList();
                var destinationList = destinationEnumerable.OfType<object>().ToList();

                foreach (var sourceEntry in sourceList)
                {
                    var sourceIndex = sourceList.IndexOf(sourceEntry);
                    if (sourceIndex == -1)
                        throw new ArgumentException(nameof(sourceIndex));
                    if (destinationList.Count < sourceIndex)
                        throw new ArgumentException(nameof(sourceIndex));
                    var destinationEntry = destinationList.ElementAt(sourceIndex);
                    SyncEntity(sourceEntry, destinationEntry,propertySet);
                }
            }

            #endregion
        }        
    }

    #region EnumerableExtensions
    public static class EnumerableExtensions
    {
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
    } 
    #endregion

    #region DayOfWeekExtensions
    public static class DayOfWeekExtensions
    {
        #region STATIC FIELDS
        private static readonly IList<DayOfWeek> daysOfWeek = Enum.GetValues(typeof(DayOfWeek))
              .Cast<DayOfWeek>()
              .ToList();
        #endregion

        #region FUNCTIONS

        /// <summary>
        /// Gets next day of week.
        /// </summary>
        /// <param name="day">From day.</param>
        /// <returns>Next day of week.</returns>
        public static DayOfWeek Next(this DayOfWeek day)
        {
            var currentIndex = daysOfWeek.IndexOf(day);

            int nextIndex = currentIndex + 1;
            if (currentIndex >= 6)
                nextIndex = 0;

            return daysOfWeek[nextIndex];
        }

        /// <summary>
        /// Gets previous day of week.
        /// </summary>
        /// <param name="day">From day.</param>
        /// <returns>Previous day of week.</returns>
        public static DayOfWeek Previous(this DayOfWeek day)
        {
            var currentIndex = daysOfWeek.IndexOf(day);

            int nextIndex = currentIndex - 1;
            if (currentIndex <= 0)
                nextIndex = 6;

            return daysOfWeek[nextIndex];
        }

        #endregion
    } 
    #endregion
}
