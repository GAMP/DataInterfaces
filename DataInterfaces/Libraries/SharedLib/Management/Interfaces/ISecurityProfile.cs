using System.Collections.Generic;

namespace SharedLib.Management
{
    /// <summary>
    /// Security profile implementation interface.
    /// </summary>
    public interface ISecurityProfile
    {
        #region PROPERTIES
        
        /// <summary>
        /// Security profile id.
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Disabled drives flag.
        /// </summary>
        int DisabledDrives { get; }

        /// <summary>
        /// Security profile name.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Policies.
        /// </summary>
        List<ISecurityPolicy> Policies { get; }

        /// <summary>
        /// Restrictions.
        /// </summary>
        List<IRestriction> Restrictions { get; }

        /// <summary>
        /// Enable sticky shell.
        /// </summary>
        bool StickyShell { get; }

        /// <summary>
        /// Disable start menu.
        /// </summary>
        bool DisableStartMenu { get; }

        /// <summary>
        /// Disable desktop switching.
        /// </summary>
        bool DisableDesktopSwitching { get; }

        #endregion
    }
}
