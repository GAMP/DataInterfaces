using SharedLib.Views;
using System.ComponentModel.Composition;

namespace Client
{
    /// <summary>
    /// Section module.
    /// </summary>
    [PartNotDiscoverable()]
    public abstract class ClientSectionModuleBase : ClientSwitchInModule, IClientSectionModule
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
