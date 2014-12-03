using Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;

namespace IntegrationLib
{
    #region ClientPluginBase
    [PartNotDiscoverable()]
    [InheritedExport(typeof(IClientPlugin))]
    public abstract class ClientPluginBase : IClientPlugin, IPartImportsSatisfiedNotification
    {
        #region PROPERTIES
        
        /// <summary>
        /// Gets client instance.
        /// </summary>
        [Import(typeof(IClient))]
        public IClient Client
        {
            get;
            protected set;
        } 
        
        #endregion

        #region IPartImportsSatisfiedNotification
        /// <summary>
        /// This method is called once all imports are satisfied.
        /// </summary>
        public virtual void OnImportsSatisfied()
        {
        } 
        #endregion
    } 
    #endregion

    #region ClientHookPluginBase
    [PartNotDiscoverable()]
    [InheritedExport(typeof(IClientHook))]
    public abstract class ClientHookPluginBase : ClientPluginBase, IClientHook
    {
    }
    #endregion
}
