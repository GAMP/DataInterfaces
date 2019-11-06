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
        /// Gets profile id.
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Gets disabled drives flag.
        /// </summary>
        int DisabledDrives { get; }

        /// <summary>
        /// Gets profile name.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets policies.
        /// </summary>
        List<ISecurityPolicy> Policies { get; }

        /// <summary>
        /// Gets restrictions.
        /// </summary>
        List<IRestriction> Restrictions { get; } 

        #endregion
    }
}
