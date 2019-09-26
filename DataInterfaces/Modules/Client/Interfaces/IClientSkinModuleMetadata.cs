using System;
using System.ComponentModel;

namespace Client
{
    /// <summary>
    /// Client module meta data interface.
    /// </summary>
    /// <remarks>
    /// Used to map exported module meta data attributes.
    /// </remarks>
    public interface IClientSkinModuleMetadata
    {
        #region PROPERTIES

        /// <summary>
        /// Gets module title.
        /// </summary>
        string Title { get; }

        /// <summary>
        /// Gets module description.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Gets if module is localized.
        /// </summary>
        bool IsLocalized { get; }

        /// <summary>
        /// Gets module guid.
        /// </summary>
        string Guid { get; }

        /// <summary>
        /// Gets module display order.
        /// </summary>
        [DefaultValue(0)]
        int DisplayOrder { get; }

        /// <summary>
        /// Gets module icon resource.
        /// </summary>
        string IconResource { get; }

        /// <summary>
        /// Gets exported type.
        /// </summary>
        Type Type { get; }

        #endregion
    }
}
