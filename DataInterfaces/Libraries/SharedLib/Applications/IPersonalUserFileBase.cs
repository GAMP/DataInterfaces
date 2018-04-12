using System.Collections.ObjectModel;

namespace SharedLib.Applications
{
    public interface IPersonalUserFile : IHasVisualOptions
    {
        #region PROPERTIES

        /// <summary>
        /// Gets or sets id.
        /// </summary>
        int ID { get; set; }

        /// <summary>
        /// Gets or sets activation type.
        /// </summary>
        ActivationType ActivationType { get; set; }

        /// <summary>
        /// Gets or sets deactivation type.
        /// </summary>
        ActivationType DeactivationType { get; set; }

        /// <summary>
        /// Gets or sets allowed groups.
        /// </summary>
        ObservableCollection<int> AllowedGroups { get; set; }

        /// <summary>
        /// Gets or sets if clean up enabled.
        /// </summary>
        bool CleanUp { get; set; }

        /// <summary>
        /// Gets or sets compression level.
        /// </summary>
        int CompressionLevel { get; set; }

        /// <summary>
        /// Gets or sets include directories.
        /// </summary>
        bool IncludeSubDirectories { get; set; }

        /// <summary>
        /// Gets or sets if storable.
        /// </summary>
        bool IsStorable { get; set; }

        /// <summary>
        /// Gets or sets max quouta.
        /// </summary>
        long MaxQuota { get; set; }

        /// <summary>
        /// Gets or sets name.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets source path.
        /// </summary>
        string SourcePath { get; set; } 

        #endregion
    }
}
