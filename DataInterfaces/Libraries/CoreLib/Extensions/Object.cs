using System;

namespace CoreLib
{
    /// <summary>
    /// Object extension class.
    /// </summary>
    public static class ObjectExtensions
    {
        #region FUNCTIONS

        /// <summary>
        /// Gets if object represents a numeric type.
        /// </summary>
        /// <param name="obj">Object instance.</param>
        /// <returns>True or false.</returns>
        public static bool IsNumericType(this object obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            return IsNumericType(obj.GetType());
        }

        /// <summary>
        /// Gets if type is numeric.
        /// </summary>
        /// <param name="type">Type instance.</param>
        /// <returns>True or false.</returns>
        public static bool IsNumericType(this Type type)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Byte:
                case TypeCode.SByte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Single:
                    return true;
                default:
                    return false;
            }
        }

        #endregion
    }
}
