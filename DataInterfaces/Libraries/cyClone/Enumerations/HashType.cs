namespace CyClone
{
    /// <summary>
    /// Hash type enumeration.
    /// </summary>
    public enum HashType
    {
        /// <summary>
        /// MD 5.
        /// </summary>
        MD5 = 0,
        /// <summary>
        /// Adler 32.
        /// </summary>
        Adler32 = 1,
        /// <summary>
        /// CRC 32.
        /// </summary>
        CRC32 = 2,
        /// <summary>
        /// SHA 1.
        /// </summary>
        SHA1 = 4,
        /// <summary>
        /// Fletcher.
        /// </summary>
        Fletcher = 8
    }
}
