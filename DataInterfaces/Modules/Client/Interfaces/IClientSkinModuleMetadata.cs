using System.ComponentModel;

namespace Client
{
    #region IClientSkinModuleMetadata
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
        int DiaplayOrder { get; }

        /// <summary>
        /// Gets module icon resource.
        /// </summary>
        string IconResource { get; }

        #endregion
    }
    #endregion
}
