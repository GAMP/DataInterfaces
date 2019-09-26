using System;
using System.Collections.Generic;
using System.Collections;

namespace CoreLib
{
    /// <summary>
    /// IList extension class.
    /// </summary>
    public static class ListExtensions
    {
        #region FUNCTIONS
        
        /// <summary>
        /// Moves item up in specified list.
        /// </summary>
        /// <typeparam name="T">Item type.</typeparam>
        /// <param name="list">Source list.</param>
        /// <param name="item">Item instance.</param>
        public static void MoveUp<T>(this IList list, T item)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));

            if (item == null)
                throw new ArgumentNullException(nameof(item));

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
        public static void MoveDown<T>(this IList list, T item)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));

            if (item == null)
                throw new ArgumentNullException(nameof(item));

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
        public static void Move(this IList list, int oldIndex, int newIndex)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));

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
        public static void Replace<T>(this IList list, T oldItem, T newItem)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));

            if (oldItem == null)
                throw new ArgumentNullException(nameof(oldItem));

            if (newItem == null)
                throw new ArgumentNullException(nameof(newItem));

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
                throw new ArgumentNullException(nameof(list));

            if (items == null)
                throw new ArgumentNullException(nameof(items));

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
                throw new ArgumentNullException(nameof(list));

            if (items == null)
                throw new ArgumentNullException(nameof(items));

            foreach (T item in items)
                list.Remove(item);
        } 

        #endregion
    }
}