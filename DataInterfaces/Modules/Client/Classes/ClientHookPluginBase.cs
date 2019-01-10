using System.ComponentModel.Composition;

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
