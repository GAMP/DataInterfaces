using System;

namespace IntegrationLib
{
    /// <summary>
    /// Claim type info interface.
    /// </summary>
    public interface IClaimTypeInfo : IClaimType
    {
        #region PROPERTIES
        
        /// <summary>
        /// Gets group name.
        /// </summary>
        string Group
        {
            get;
        }

        /// <summary>
        /// Gets permission name.
        /// </summary>
        string Name
        {
            get;
        }

        /// <summary>
        /// Gets description.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Gets type.
        /// </summary>
        Enum Type { get; }

        /// <summary>
        /// Gets dependent claim.
        /// </summary>
        Enum[] DependsOn { get; }

        #endregion
    }
}
