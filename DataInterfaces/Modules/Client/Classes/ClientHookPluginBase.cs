using System.ComponentModel.Composition;

namespace Client
{
    /// <summary>
    /// Client hook plugin base.
    /// </summary>
    [PartNotDiscoverable()]
    [InheritedExport(typeof(IClientHookPlugin))]
    public abstract class ClientHookPluginBase : ClientPluginBase, IClientHookPlugin
    {
    }
}
