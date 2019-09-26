namespace CyClone.Core
{
    public interface IMappingsConfiguration
    {
        #region PROPERTIES

        /// <summary>
        /// Gets or sets if the map point will be accessible in read only mode.
        /// </summary>
        bool ReadOnly { get; set; }

        /// <summary>
        /// Gets or sets if the source folder will be accessed directly.
        /// </summary>
        bool DirectAccess { get; set; }

        /// <summary>
        /// Gets if the configuration is valid.
        /// </summary>
        /// <returns>True if configuration is valid, otherwise false.</returns>
        bool IsValid();

        /// <summary>
        /// Gets or sets the destination path.
        /// </summary>
        string MountPoint { get; set; }

        /// <summary>
        /// Gets or sets the source path.
        /// </summary>
        string SourcePath { get; set; }

        /// <summary>
        /// Gets or sets if the credentials should be used for accessing the source.
        /// </summary>
        bool UseCredentials { get; set; }

        /// <summary>
        /// Username for accessing the source;
        /// </summary>
        string Username { get; set; }

        /// <summary>
        /// Password for accessing the source.
        /// </summary>
        string Password { get; set; }

        /// <summary>
        /// Gets or sets the drive type of the configuration.
        /// </summary>
        MountPointType Type { get; set; }

        /// <summary>
        /// Gets or sets stroage type.
        /// </summary>
        StorageType StorageType { get; set; }

        /// <summary>
        /// Gets if the configuration is for mapping is drive.
        /// </summary>
        bool MapAsDrive { get; }

        /// <summary>
        /// Gets or sets the label name for the drive.
        /// </summary>
        string Label { get; set; }

        /// <summary>
        /// Gets or sets the volume size in bytes.
        /// </summary>
        long VolumeSize { get; set; }

        /// <summary>
        /// Gets or sets share id assigned to this mappings.
        /// <remarks>This is used when mapping is removed so we know which share should be deleted.</remarks>
        /// </summary>
        int ShareId { get; set; } 

        #endregion
    }
}


