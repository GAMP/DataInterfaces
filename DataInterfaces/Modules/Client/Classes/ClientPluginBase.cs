using System.ComponentModel.Composition;

namespace Client
{
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
}
