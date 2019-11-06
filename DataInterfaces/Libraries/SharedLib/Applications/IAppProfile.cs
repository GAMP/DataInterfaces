using System.Collections.Generic;

namespace SharedLib.Applications
{
    /// <summary>
    /// App profile interface.
    /// </summary>
    public interface IAppProfile
    {
        #region PROPERTIES

        /// <summary>
        /// Gets profile id.
        /// </summary>
        int Id { get; }

        /// <summary>
        /// Gets or sets profile name.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets present apps.
        /// </summary>
        HashSet<int> Profiles { get; set; }

        #endregion
    }
}
