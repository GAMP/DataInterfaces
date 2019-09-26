using SharedLib.Views;

namespace Client
{
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
}
