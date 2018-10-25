using SharedLib.Views;

namespace Client
{
    /// <summary>
    /// Client skin module inteface.
    /// </summary>
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

    /// <summary>
    /// Client section module interface.
    /// </summary>
    public interface IClientSectionModule : IClientViewModule , IClientSwitchInModule
    {       
    }

    /// <summary>
    /// Client user settings module interface.
    /// </summary>
    public interface IClientUserSettingsModule : IClientViewModule , IClientSwitchInModule
    {
    }
}