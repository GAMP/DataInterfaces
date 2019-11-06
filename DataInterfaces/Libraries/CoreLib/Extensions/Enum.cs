using Localization;
using SharedLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace CoreLib
{
    /// <summary>
    /// Enumerator extensions.
    /// </summary>
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

        /// <summary>
        /// Gets special folder attribute value from an enumeration.
        /// </summary>
        /// <param name="value">Enum value.</param>
        /// <returns></returns>
        public static Environment.SpecialFolder GetSpecialFolderValue(this Enum value)
        {
            // Get the type
            Type type = value.GetType();

            // Get fieldinfo for this type
            FieldInfo fieldInfo = type.GetField(value.ToString());

            // Get the stringvalue attributes
            SpecialFolderAttribute[] attribs = fieldInfo.GetCustomAttributes(
                typeof(SpecialFolderAttribute), false) as SpecialFolderAttribute[];

            // Return the first if there was a match.
            return attribs.Length > 0 ? attribs[0].SpecialFolder : (Environment.SpecialFolder)65535;
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

        /// <summary>
        /// Gets flags.
        /// </summary>
        /// <param name="value">Enum value.</param>
        public static IEnumerable<Enum> GetFlags(this Enum value)
        {
            return GetFlags(value, Enum.GetValues(value.GetType()).Cast<Enum>().ToArray());
        }

        /// <summary>
        /// Gets individual flags.
        /// </summary>
        /// <param name="value">Enum value.</param>
        /// <returns></returns>
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
        public static T GetAttributeOfType<T>(this Enum enumVal) where T : Attribute
        {
            var type = enumVal.GetType();
            var memInfo = type.GetMember(enumVal.ToString());
            if (memInfo.Count() == 0)
                return default;

            var attributes = memInfo[0].GetCustomAttributes(typeof(T), false);
            if (attributes.Length > 0)
            {
                return (T)attributes[0];
            }
            else
            {
                return default;
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
        public static object[] GetAttributes<T>(this Enum @enum)
        {
            if (@enum != null)
            {
                FieldInfo fi = @enum.GetType().GetField(@enum.ToString());
                if (fi != null)
                {
                    object[] attributes = fi.GetCustomAttributes(typeof(T), false);
                    if (attributes != null)
                        return (attributes);
                }
            }
            return null;
        }

        /// <summary>
        /// Checks if the value contains the provided type.
        /// </summary>
        public static bool Has<T>(this Enum type, T value)
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
        public static bool Is<T>(this Enum type, T value)
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
        public static T Add<T>(this Enum type, T value)
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
        public static T Remove<T>(this Enum type, T value)
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
}
