using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using SharedLib.Dispatcher;
using IntegrationLib;

namespace ServerService
{
    #region ServicePluginBase
    [PartNotDiscoverable()]
    [InheritedExport(typeof(IServicePlugin))]
    public abstract class ServicePluginBase :
        IServicePlugin, 
        IPartImportsSatisfiedNotification,
        IDisposable
    {
        #region IServicePlugin

        public virtual void OnInitialize()
        {
        }

        public virtual void OnDeinitialize()
        { }

        /// <summary>
        /// When ovveriden should take care of releasing any resources used by plugin.
        /// </summary>
        /// <param name="disposing">Indicate disposing.</param>
        public virtual void OnDisposing(bool disposing)
        {
        }

        #endregion

        #region Properties
        
        /// <summary>
        /// Gets the service instance.
        /// </summary>
        [Import(typeof(IService))]
        protected IService Service
        {
            get;
            set;
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

        #region IDisposable
        /// <summary>
        /// Called once object is being disposed.
        /// </summary>
        public void Dispose()
        {
            this.OnDisposing(true);
        } 
        #endregion        
    }
    #endregion

    #region ServiceAuthPluginBase
    /// <summary>
    /// Base class for authentication plugins. 
    /// </summary>
    [PartNotDiscoverable()]
    [InheritedExport(typeof(IServiceAuthenticationPlugin))]
    public abstract class ServiceAuthPluginBase : ServicePluginBase, IServiceAuthenticationPlugin
    {
        #region IAuthenticationPlugin
        public virtual AuthResult Authenticate(IDictionary<string, object> authHeaders,IMessageDispatcher dispatcher)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Post authenticate procedure.
        /// </summary>
        /// <param name="result">Authentication result.</param>
        /// <remarks>Here you can modify the final result that will be returned to authenticated party.</remarks>
        public virtual void PostAuthenticate(AuthResult result, IMessageDispatcher dispatcher)
        {
            throw new NotImplementedException();
        } 
        #endregion
    } 
    #endregion

    #region ServiceHookPluginBase
    [PartNotDiscoverable()]
    [InheritedExport(typeof(IServiceHookPlugin))]
    public abstract class ServiceHookPluginBase : ServicePluginBase, IServiceHookPlugin
    {
    } 
    #endregion
}
