namespace GizmoDALV2
{
    /// <summary>
    /// SQL byte array sizes.
    /// </summary>
    public static class SQLByteArraySize
    {
        /// <summary>
        /// Tiny 255 bytes.
        /// </summary>
        public const int TINY = 255;
        /// <summary>
        /// Normal.
        /// </summary>
        public const int NORMAL = 65535;
        /// <summary>
        /// Medium.
        /// </summary>
        public const int MEDIUM = 16777215;
        /// <summary>
        /// Max.
        /// </summary>
        public const int MAX = int.MaxValue;
    }
}
