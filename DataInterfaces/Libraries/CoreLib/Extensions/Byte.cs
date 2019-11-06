using System;
using System.Text;

namespace CoreLib
{
    /// <summary>
    /// Byte extension class.
    /// </summary>
    public static class ByteExtensions
    {
        #region FUNCTIONS

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
                    if (*x1 != *x2)
                        return false;

                return true;
            }
        }

        /// <summary>
        /// Checks if sequence equals.
        /// </summary>
        /// <param name="source">Source.</param>
        /// <param name="sourceIndex">Source index.</param>
        /// <param name="destination">Destination.</param>
        /// <param name="destinationIndex">Destination index.</param>
        /// <param name="count">Count.</param>
        /// <returns>True if equals, otherwise false.</returns>
        public static bool SequenceEquals(this byte[] source, int sourceIndex, byte[] destination, int destinationIndex, int count)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (destination == null)
                throw new ArgumentNullException(nameof(destination));

            if (source.Length < sourceIndex)
                throw new ArgumentException(nameof(sourceIndex));

            if (destination.Length < destinationIndex)
                throw new ArgumentException(nameof(destinationIndex));

            if (count <= 0)
                throw new ArgumentException(nameof(count));

            if (source.Length < sourceIndex + count)
                throw new ArgumentOutOfRangeException(nameof(source.Length), "Source start index and count exceed array length.");

            if (destination.Length < destinationIndex + count)
                throw new ArgumentOutOfRangeException(nameof(destination.Length), "Destination start index and count exceed array length.");


            int effectiveCount = count - 1;
            for (int currentIndex = 0; currentIndex <= effectiveCount; currentIndex++)
            {
                var effectiveSourceIndex = currentIndex + sourceIndex;
                var effectiveDestinationIndex = currentIndex + destinationIndex;

                if (source[effectiveSourceIndex] != destination[effectiveDestinationIndex])
                    return false;
            }
            return true;
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

        /// <summary>
        /// Validates buffer and throws appropriate argument exception.
        /// </summary>
        /// <param name="buffer">Buffer instance.</param>
        /// <param name="offset">Offset.</param>
        /// <param name="count">Count.</param>
        public static void ThrowIfInvalid(this byte[] buffer, int offset, int count)
        {
            if (buffer == null)
                throw new ArgumentNullException(nameof(buffer));

            if (offset < 0)
                throw new ArgumentException(nameof(offset));

            if (buffer.Length < count)
                throw new ArgumentException("Buffer is smaller than count.", nameof(count));

            if (buffer.Length < (offset + count))
                throw new ArgumentException("Buffer is smaller than offset and count combined.", nameof(offset));
        }

        #endregion
    }
}
