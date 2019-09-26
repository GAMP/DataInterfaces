using SharedLib;

namespace CoreLib
{
    /// <summary>
    /// Restriction type enumeration.
    /// </summary>
    public enum RestrictionType
    {
        [CanUserAssign(false)]
        Unset = 0,
        [CanUserAssign(true)]
        FileName = 1,
        [CanUserAssign(true)]
        ClassName = 2,
        [CanUserAssign(true)]
        WindowName = 3,
        [CanUserAssign(true)]
        TrayIcon = 4
    }
}
