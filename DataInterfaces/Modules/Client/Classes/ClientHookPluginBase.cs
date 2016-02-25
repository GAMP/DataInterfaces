using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    #region ClientHookPluginBase
    [PartNotDiscoverable()]
    [InheritedExport(typeof(IClientHookPlugin))]
    public abstract class ClientHookPluginBase : ClientPluginBase, IClientHookPlugin
    {
    }
    #endregion
}
