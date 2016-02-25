using Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;

namespace Client
{
    #region ClientPluginBase
    [PartNotDiscoverable()]
    [InheritedExport(typeof(IClientPlugin))]
    public abstract class ClientPluginBase : 
        IClientPlugin, 
        IPartImportsSatisfiedNotification
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

        #region IPARTIMPORTSSATISFIEDNOTIFICATION
        /// <summary>
        /// This method is called once all imports are satisfied.
        /// </summary>
        public virtual void OnImportsSatisfied()
        {
        } 
        #endregion
    } 
    #endregion    
}
