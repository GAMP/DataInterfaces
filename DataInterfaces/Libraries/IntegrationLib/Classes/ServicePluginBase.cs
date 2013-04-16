using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using ServerService;
using SharedLib;
using System.Diagnostics;
using SharedLib.Dispatcher;

namespace IntegrationLib
{
    #region ServicePluginBase
    [PartNotDiscoverable()]
    [InheritedExport(typeof(IServicePlugin))]
    public abstract class ServicePluginBase : IServicePlugin, IPartImportsSatisfiedNotification,IDisposable
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

    #region AuthPluginBase
    /// <summary>
    /// Base class for authentication plugins. 
    /// </summary>
    [PartNotDiscoverable()]
    [InheritedExport(typeof(IAuthenticationPlugin))]
    public abstract class AuthPluginBase : ServicePluginBase, IAuthenticationPlugin
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
    [InheritedExport(typeof(IServiceHook))]
    public abstract class ServiceHookPluginBase : ServicePluginBase, IServiceHook
    {
    } 
    #endregion
}
