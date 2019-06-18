using System.Threading.Tasks;

namespace Client
{
    /// <summary>
    /// Skin initialization bootstrapper.
    /// </summary>
    public interface ISkinBootStrapper
    {
        #region FUNCTIONS
        
        /// <summary>
        /// Initializes the Skin.
        /// </summary>
        /// <param name="configFileName">Fulle path to the configuration file.</param>
        /// <returns>Associated task.</returns>
        Task InitializeAsync(string configFileName); 

        #endregion
    }
}