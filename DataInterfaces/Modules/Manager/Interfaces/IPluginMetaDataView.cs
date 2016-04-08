using IntegrationLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
