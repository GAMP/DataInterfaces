using System;

namespace CyClone
{
    /// <summary>
    /// Mapping flags.
    /// </summary>
    [Flags()]
    public enum MappingFlags
    {
        /// <summary>
        /// None.
        /// </summary>
        None = 0,
        /// <summary>
        /// Expose mapping as read only.
        /// </summary>
        IsReadOnly = 1,
        /// <summary>
        /// Use direct access for mapping.
        /// </summary>
        DirectAccess = 2,
        /// <summary>
        /// Use provieded credentials for mapping.
        /// </summary>
        UseCredentials = 4,
    }
}
