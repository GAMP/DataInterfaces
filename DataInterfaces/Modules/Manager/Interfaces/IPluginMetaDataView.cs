using IntegrationLib;
using System.ComponentModel;

namespace Manager
{
    public interface IPluginMetaDataView : IPluginMetadata
    {
        [DefaultValue(0)]
        int DisplayOrder
        {
            get;
        }
    }
}
