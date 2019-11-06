using SharedLib;

namespace CoreLib
{
    /// <summary>
    /// Restriction type enumeration.
    /// </summary>
    public enum RestrictionType
    {
        /// <summary>
        /// Unset.
        /// </summary>
        [CanUserAssign(false)]
        Unset = 0,
        /// <summary>
        /// File name.
        /// </summary>
        [CanUserAssign(true)]
        FileName = 1,
        /// <summary>
        /// Window class name.
        /// </summary>
        [CanUserAssign(true)]
        ClassName = 2,
        /// <summary>
        /// Window name.
        /// </summary>
        [CanUserAssign(true)]
        WindowName = 3,
        /// <summary>
        /// Tray icon.
        /// </summary>
        [CanUserAssign(true)]
        TrayIcon = 4
    }
}
