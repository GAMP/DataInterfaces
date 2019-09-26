using IntegrationLib;

namespace Manager.Modules
{
    /// <summary>
    /// Manager main module interface.
    /// </summary>
    public interface IManagerMainModule : IPluginModule
    {
        /// <summary>
        /// Gets current manager plugable module.
        /// </summary>
        IManagerPlugableModule CurrentModule { get; }

        /// <summary>
        /// Gets current manager side module.
        /// </summary>
        IManagerSideModule CurrentSideModule { get; }
    }
}
