using System.ComponentModel.Composition;

namespace Client
{
    [PartNotDiscoverable()]
    [InheritedExport(typeof(IClientHookPlugin))]
    public abstract class ClientHookPluginBase : ClientPluginBase, IClientHookPlugin
    {
    }
}
