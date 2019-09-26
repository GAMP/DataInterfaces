using SharedLib.Views;
using System.ComponentModel.Composition;

namespace Client
{
    /// <summary>
    /// User settings module.
    /// </summary>
    [PartNotDiscoverable()]
    public abstract class ClientUserSettingsModuleBase : ClientSwitchInModule, IClientUserSettingsModule
    {
        #region FIELDS
        private IView view;
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets view.
        /// </summary>
        public virtual IView View
        {
            get { return view; }
            protected set { SetProperty(ref this.view, value); }
        }

        #endregion
    } 
}
