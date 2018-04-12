using SharedLib.Views;

namespace Client
{
    public interface IClientSkinModule : IClientPlugin
    {
    }

    /// <summary>
    /// Client module providing a view.
    /// </summary>
    public interface IClientViewModule : IClientSkinModule
    {
        #region PROPERTIES
        /// <summary>
        /// Gets module view.
        /// </summary>
        IView View { get; } 
        #endregion
    }

    public interface IClientSectionModule : IClientViewModule , IClientSwitchInModule
    {       
    }

    public interface IClientUserSettingsModule : IClientViewModule , IClientSwitchInModule
    {
    }
}