using IntegrationLib;

namespace Manager.Modules
{
    /// <summary>
    /// Side module plugin interface.
    /// </summary>
    public interface IManagerSideModule : IPluginModule,
        ISwitchinModule<IManagerSideModule>
    {
        #region PROPERTIES
        
        /// <summary>
        /// Gets module view.
        /// </summary>
        object View
        {
            get;
        }

        /// <summary>
        /// Gets header template resource name.
        /// The resource should be added to main application resource dictionary upon plugin initialization.
        /// If no datatemplate found with specified resource name then default one is used.
        /// </summary>
        string HeaderTemplate { get; } 

        #endregion
    }
}
