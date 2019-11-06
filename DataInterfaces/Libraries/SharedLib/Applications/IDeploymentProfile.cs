using System;
using CyClone;

namespace SharedLib.Applications
{
    /// <summary>
    /// Deployment profile implementation interface.
    /// </summary>
    public interface IDeploymentProfile
    {
        #region PROPERTIES
        
        /// <summary>
        /// Gets destination.
        /// </summary>
        string Destination { get; }

        /// <summary>
        /// Gets source.
        /// </summary>
        string Source { get; }

        /// <summary>
        /// Gets name.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets GUID.
        /// </summary>
        Guid Guid { get; }

        /// <summary>
        /// Gets comparison level.
        /// </summary>
        FileInfoLevel ComparisonLevel { get; } 

        #endregion
    }
}
