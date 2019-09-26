using IntegrationLib;
using System.ComponentModel;

namespace Manager
{
    public interface IPluginMetaDataView : IPluginMetadata
    {
        #region PROPERTIES

        [DefaultValue(0)]
        int DisplayOrder
        {
            get;
        } 

        #endregion
    }
}
