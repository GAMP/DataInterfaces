using IntegrationLib;
using System.ComponentModel;

namespace Manager
{
    /// <summary>
    /// Plugin metada view.
    /// </summary>
    public interface IPluginMetaDataView : IPluginMetadata
    {
        #region PROPERTIES

        /// <summary>
        /// Gets display order.
        /// </summary>
        [DefaultValue(0)]
        int DisplayOrder
        {
            get;
        }

        #endregion
    }
}
