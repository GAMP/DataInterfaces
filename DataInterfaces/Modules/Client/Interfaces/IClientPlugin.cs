using IntegrationLib;

namespace Client
{
    /// <summary>
    /// Client plugin interface.
    /// </summary>
    public interface IClientPlugin : IPlugin
    {
        /// <summary>
        /// Gets client instance.
        /// </summary>
        IClient Client
        {
            get;
        }
    }
}
