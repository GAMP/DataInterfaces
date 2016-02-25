using System.Runtime.ConstrainedExecution;
using System;
using System.Collections.Generic;
using System.Reflection;
using SharedLib;
using System.Linq;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Collections;
using System.Windows.Data;
using System.Text;
using System.Runtime.InteropServices;
using System.Security;
using Localization;
using System.Runtime.Serialization;

namespace CoreLib
{
    #region ByteExtensions
    /// <summary>
    /// Byte extension class.
    /// </summary>
    public static class ByteExtensions
    {
        /// <summary>
        /// Checks if two byte array match.
        /// </summary>
        /// <returns>True or false.</returns>
        // Copyright (c) 2008-2013 Hafthor Stefansson
        // Distributed under the MIT/X11 software license
        // Ref: http://www.opensource.org/licenses/mit-license.php.
        public static unsafe bool UnSafeEquals(this byte[] a1, byte[] a2)
        {
            if (a1 == null || a2 == null || a1.Length != a2.Length)
                return false;

            fixed (byte* p1 = a1, p2 = a2)
            {
                byte* x1 = p1, x2 = p2;
                int l = a1.Length;
                for (int i = 0; i < l / 8; i++, x1 += 8, x2 += 8)
                    if (*((long*)x1) != *((long*)x2))
                        return false;

                if ((l & 4) != 0)
                {
                    if (*((int*)x1) != *((int*)x2))
                        return false;
                    x1 += 4;
                    x2 += 4;
                }

                if ((l & 2) != 0)
                {
                    if (*((short*)x1) != *((short*)x2))
                        return false;
                    x1 += 2;
                    x2 += 2;
                }

                if ((l & 1) != 0)
                    if (*((byte*)x1) != *((byte*)x2))
                        return false;

                return true;
            }
        }

        /// <summary>
        /// Gets index of specified byte sequence.
        /// </summary>
        /// <param name="array">Byte array.</param>
        /// <param name="pattern">Required pattern.</param>
        /// <param name="startIndex">Start index.</param>
        /// <param name="count">Count.</param>
        /// <returns>Found index, -1 case not found.</returns>
        public static int IndexOfBytes(this byte[] array, byte[] pattern, int startIndex, int count)
        {
            int fidx = 0;
            int result = Array.FindIndex(array, startIndex, count, (byte b) =>
            {
                fidx = (b == pattern[fidx]) ? fidx + 1 : 0;
                return (fidx == pattern.Length);
            });
            return (result < 0) ? -1 : result - fidx + 1;
        }

        /// <summary>
        /// Converts byte array to hexademical string.
        /// </summary>
        /// <param name="bytes">Byte array.</param>
        /// <param name="upperCase">Indicates uppercase conversion.</param>
        /// <returns>Byte array hexademical string.</returns>
        public static string ToHex(this byte[] bytes, bool upperCase)
        {
            StringBuilder result = new StringBuilder(bytes.Length * 2);

            for (int i = 0; i < bytes.Length; i++)
                result.Append(bytes[i].ToString(upperCase ? "X2" : "x2"));

            return result.ToString();
        }

    }
    #endregion

    #region EnumeratorExtension
    public static class EnumeratorExtension
    {
        /// <summary>
        /// Gets the guid atrributes guid value. If none set empty guid returned.
        /// </summary>
        public static Guid GetGuidValue(this Enum value)
        {
            // Get the type
            Type type = value.GetType();

            // Get fieldinfo for this type
            FieldInfo fieldInfo = type.GetField(value.ToString());

            // Get the stringvalue attributes
            GUIDAttribute[] attribs = fieldInfo.GetCustomAttributes(
                typeof(GUIDAttribute), false) as GUIDAttribute[];

            // Return the first if there was a match.
            return attribs.Length > 0 ? attribs[0].Guid : Guid.Empty;
        }

        public static System.Environment.SpecialFolder GetSpecialFolderValue(this Enum value)
        {
            // Get the type
            Type type = value.GetType();

            // Get fieldinfo for this type
            FieldInfo fieldInfo = type.GetField(value.ToString());

            // Get the stringvalue attributes
            SpecialFolderAttribute[] attribs = fieldInfo.GetCustomAttributes(
                typeof(SpecialFolderAttribute), false) as SpecialFolderAttribute[];

            // Return the first if there was a match.
            return attribs.Length > 0 ? attribs[0].SpecialFolder : (System.Environment.SpecialFolder)65535;
        }

        /// <summary>
        /// Gets the description of passed enumerator value.
        /// </summary>
        public static string GetEnumDescription(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return (attributes.Length > 0) ? attributes[0].Description : value.ToString();
        }

        /// <summary>
        /// Gets the description of passed enumerator value.
        /// </summary>
        public static string GetLocalizationKey(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            var attributes = (LocalizedAttribute[])fi.GetCustomAttributes
              (typeof(LocalizedAttribute), false);
            return (attributes.Length > 0) ? attributes[0].ResourceKey : value.ToString();
        }

        public static IEnumerable<Enum> GetFlags(this Enum value)
        {
            return GetFlags(value, Enum.GetValues(value.GetType()).Cast<Enum>().ToArray());
        }

        public static IEnumerable<Enum> GetIndividualFlags(this Enum value)
        {
            return GetFlags(value, GetFlagValues(value.GetType()).ToArray());
        }

        private static IEnumerable<Enum> GetFlags(this Enum value, Enum[] values)
        {
            ulong bits = Convert.ToUInt64(value);
            List<Enum> results = new List<Enum>();
            for (int i = values.Length - 1; i >= 0; i--)
            {
                ulong mask = Convert.ToUInt64(values[i]);
                if (i == 0 && mask == 0L)
                    break;
                if ((bits & mask) == mask)
                {
                    results.Add(values[i]);
                    bits -= mask;
                }
            }
            if (bits != 0L)
                return Enumerable.Empty<Enum>();
            if (Convert.ToUInt64(value) != 0L)
                return results.Reverse<Enum>();
            if (bits == Convert.ToUInt64(value) && values.Length > 0 && Convert.ToUInt64(values[0]) == 0L)
                return values.Take(1); return Enumerable.Empty<Enum>();
        }

        private static IEnumerable<Enum> GetFlagValues(Type enumType)
        {
            ulong flag = 0x1; foreach (var value in Enum.GetValues(enumType).Cast<Enum>())
            {
                ulong bits = Convert.ToUInt64(value); if (bits == 0L)
                    //yield return value;               
                    continue; // skip the zero value     
                while (flag < bits) flag <<= 1;
                if (flag == bits)
                    yield return value;
            }
        }

        /// <summary> 
        /// Gets an attribute on an enum field value 
        /// </summary> 
        /// <typeparam name="T">The type of the attribute you want to retrieve</typeparam> 
        /// <param name="enumVal">The enum value</param> 
        /// <returns>The attribute of type T that exists on the enum value</returns> 
        public static T GetAttributeOfType<T>(this Enum enumVal) where T : System.Attribute
        {
            var type = enumVal.GetType();
            var memInfo = type.GetMember(enumVal.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(T), false);
            if (attributes.Length > 0)
            {
                return (T)attributes[0];
            }
            else
            {
                return default(T);
            }
        }

        /// <summary>
        /// Gets if enum value has specified attribute applied.
        /// </summary>
        /// <typeparam name="T">Attribute type.</typeparam>
        /// <param name="enumVal">Enumerator value.</param>
        /// <returns>True or false.</returns>
        public static bool HasCustomAttribute<T>(this Enum enumVal) where T : System.Attribute
        {
            var type = enumVal.GetType();
            var memInfo = type.GetMember(enumVal.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(T), false);
            return attributes.Length > 0;
        }

        /// <summary>
        /// Gets all arttibutes.
        /// </summary>
        public static Object[] GetAttributes<T>(this Enum @enum)
        {
            if (@enum != null)
            {
                FieldInfo fi = @enum.GetType().GetField(@enum.ToString());
                if (fi != null)
                {
                    Object[] attributes = fi.GetCustomAttributes(typeof(T), false);
                    if (attributes != null)
                        return (attributes);
                }
            }
            return null;
        }

        /// <summary>
        /// Checks if the value contains the provided type.
        /// </summary>
        public static bool Has<T>(this System.Enum type, T value)
        {
            try
            {
                return (((int)(object)type & (int)(object)value) == (int)(object)value);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Checks if the value is only the provided type.
        /// </summary>
        public static bool Is<T>(this System.Enum type, T value)
        {
            try
            {
                return (int)(object)type == (int)(object)value;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Appends a value.
        /// </summary>
        public static T Add<T>(this System.Enum type, T value)
        {
            try
            {
                return (T)(object)(((int)(object)type | (int)(object)value));
            }
            catch (Exception ex)
            {
                throw new ArgumentException(
                    string.Format(
                        "Could not append value from enumerated type '{0}'.",
                        typeof(T).Name
                        ), ex);
            }
        }

        /// <summary>
        /// Completely removes the value.
        /// </summary>
        public static T Remove<T>(this System.Enum type, T value)
        {
            try
            {
                return (T)(object)(((int)(object)type & ~(int)(object)value));
            }
            catch (Exception ex)
            {
                throw new ArgumentException(
                    string.Format(
                        "Could not remove value from enumerated type '{0}'.",
                        typeof(T).Name
                        ), ex);
            }
        }

        /// <summary>
        /// Gets EnumMemberAttribute value from specified enumeration.
        /// </summary>
        /// <param name="value">EnumMemberAttribute value.</param>
        /// <returns>EnumMemberAttribute value, enum string value if no EnumMemberAttribute attribute defined.</returns>
        public static string ToEnumString(this Enum value)
        {
            if (value == null)
                return null;

            FieldInfo fi = value.GetType().GetField(value.ToString());
            var attributes = (EnumMemberAttribute[])fi.GetCustomAttributes(typeof(EnumMemberAttribute), false);
            if (attributes.Length > 0)
                return attributes[0].Value;
            else
                return value.ToString();
        }
    }
    #endregion

    #region StringExtensions
    public static class StringExtensions
    {
        public static string Replace(this string originalString, string oldValue, string newValue, StringComparison comparisonType)
        {
            int startIndex = 0;
            while (true)
            {
                startIndex = originalString.IndexOf(oldValue, startIndex, comparisonType);
                if (startIndex == -1)
                    break;

                originalString = originalString.Substring(0, startIndex) + newValue + originalString.Substring(startIndex + oldValue.Length);

                startIndex += newValue.Length;
            }
            return originalString;
        }
    }
    #endregion

    #region DateTimeExtensions
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Calculates the age in years of the current System.DateTime object today.
        /// </summary>
        /// <param name="birthDate">The date of birth</param>
        /// <returns>Age in years today. 0 is returned for a future date of birth.</returns>
        public static int Age(this DateTime birthDate)
        {
            var yearsOld = DateTime.Today.Year - birthDate.Year;
            if (DateTime.Today < birthDate.AddYears(yearsOld)) yearsOld--;
            return yearsOld;
        }
    }
    #endregion

    #region ListExtensions
    public static class ListExtensions
    {
        /// <summary>
        /// Moves item up in specified list.
        /// </summary>
        /// <typeparam name="T">Item type.</typeparam>
        /// <param name="list">Source list.</param>
        /// <param name="item">Item instance.</param>
        public static void MoveUp<T>(this IList list, T item)
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
        public static void MoveDown<T>(this IList list, T item)
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
        public static void Move(this IList list, int oldIndex, int newIndex)
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
        public static void Replace<T>(this IList list, T oldItem, T newItem)
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

    #region CollectionViewExtension
    public static class CollectionViewExtension
    {
        public static bool IsCurrentLast(this ListCollectionView view)
        {
            if (view == null)
                throw new ArgumentNullException("view");

            return view.CurrentPosition == view.Count - 1;
        }

        public static bool IsCurrentFirst(this ListCollectionView view)
        {
            if (view == null)
                throw new ArgumentNullException("view");

            return view.CurrentPosition == 0;
        }
    }
    #endregion

    #region EnumerableExtensions
    public static partial class EnumerableExtensions
    {
        #region IsNullOrEmpty

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

        #endregion
    } 
    #endregion
}