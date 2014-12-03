﻿using System.Runtime.ConstrainedExecution;
using System;
using System.Collections.Generic;
using System.Reflection;
using SharedLib;
using System.Linq;
using System.ComponentModel;
using System.Linq.Expressions;

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
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        public static unsafe bool UnSafeEquals(this byte[] strA, byte[] strB)
        {
            int length = strA.Length;
            if (length != strB.Length)
            {
                return false;
            }
            fixed (byte* str = strA)
            {
                byte* chPtr = str;
                fixed (byte* str2 = strB)
                {
                    byte* chPtr2 = str2;
                    byte* chPtr3 = chPtr;
                    byte* chPtr4 = chPtr2;
                    while (length >= 10)
                    {
                        if ((((*(((int*)chPtr3)) != *(((int*)chPtr4))) ||
                            (*(((int*)(chPtr3 + 2))) != *(((int*)(chPtr4 + 2)))))
                            || ((*(((int*)(chPtr3 + 4))) != *(((int*)(chPtr4 + 4))))
                            || (*(((int*)(chPtr3 + 6))) != *(((int*)(chPtr4 + 6))))))
                            || (*(((int*)(chPtr3 + 8))) != *(((int*)(chPtr4 + 8)))))
                        {
                            break;
                        }
                        chPtr3 += 10;
                        chPtr4 += 10;
                        length -= 10;
                    }
                    while (length > 0)
                    {
                        if (*(((int*)chPtr3)) != *(((int*)chPtr4)))
                        {
                            break;
                        }
                        chPtr3 += 2;
                        chPtr4 += 2;
                        length -= 2;
                    }
                    return (length <= 0);
                }
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
            DescriptionAttribute[] attributes =
              (DescriptionAttribute[])fi.GetCustomAttributes
              (typeof(DescriptionAttribute), false);
            return (attributes.Length > 0) ? attributes[0].Description : value.ToString();
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
            } if (bits != 0L)
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
}