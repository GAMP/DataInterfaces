using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreLib;
using SharedLib;
using SharedLib.Applications;
using SkinLib;
using SharedLib.Logging;
using IntegrationLib;
using SharedLib.Commands;
using System.Windows;
using SharedLib.ViewModels;
using CoreLib.Hooking;
using SharedLib.Management;
using SharedLib.Dispatcher;
using SharedLib.User;

namespace Client
{
    /// <summary>
    /// Client module interface.
    /// </summary>
    public interface IClient
    {
        #region Events
       
        /// <summary>
        /// Occours when client shutting down.
        /// </summary>
        event ShutDownDelegate ShutDown;
        
        /// <summary>
        /// Occours when client started up.
        /// </summary>
        event StartUpDelegate StartUp;
        
        /// <summary>
        /// Occours when login state of user changes.
        /// </summary>
        event LoginStateChanagedDelegate LoginStateChange;
        
        /// <summary>
        /// Occours when input lock state changes.
        /// </summary>
        event LockStateChangedDelegate LockStateChange;
        
        /// <summary>
        /// Occours when integration availability changes.
        /// </summary>
        event AvailabilityChangedDelegate IntegrationAvailabilityChange;
        
        /// <summary>
        /// Occours when client id changes.
        /// </summary>
        event ClientIdChangedDelegate IdChange;
        
        /// <summary>
        /// Occours when a securtiy change occour.
        /// </summary>
        event SecurtyStateChangeDelegate SecurityStateChange;
        
        /// <summary>
        /// Occours when execution context collection changes.
        /// </summary>
        event ExecutionContextCollectionEvent ExecutionContextCollectionChange;
        
        /// <summary>
        /// Occours when execution context state changes.
        /// </summary>
        event ExecutionContextStateChangedDelegate ExecutionContextStateChage;
        
        /// <summary>
        /// Occours on current initialization activity changes.
        /// </summary>
        event CurrentActivityDelegate ActivityChange;
        
        /// <summary>
        /// Occours when Application container changes.
        /// </summary>
        event ContainerChangedDelegate ContainerChange;
        
        /// <summary>
        /// Occours when out of order state changes.
        /// </summary>
        event OutOfOrderStateChangeDelegate OutOfOrderStateChange;
        
        #endregion

        #region Properties

        /// <summary>
        /// Gets the client id.
        /// </summary>
        int Id
        {
            get;
        }

        /// <summary>
        /// Gets client version ifnormation.
        /// </summary>
        string VersionInfo { get; }

        /// <summary>
        /// Gets the application container instance.
        /// </summary>
        IApplicationContainer ApplicationContainer
        {
            get;
        }

        /// <summary>
        /// Gets the skin handler instance.
        /// </summary>
        IUIHandler SkinHandler
        {
            get;
        }

        /// <summary>
        /// Gest the client log provider.
        /// </summary>
        ILog Log
        {
            get;
        }

        /// <summary>
        /// Gets or sets the integration provider.
        /// </summary>
        IClientSideIntegrationProvider IntegrationProvider
        {
            get;
        }

        /// <summary>
        /// Gets or sets if client is currently in out of order state.
        /// </summary>
        bool IsOutOfOrder
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the handle of current main window.
        /// </summary>
        IntPtr MainWindowHandle { get; }

        /// <summary>
        /// Gets client module keyboard hook instance.
        /// </summary>
        IKeyboardHook KeyBoardHook { get; }

        /// <summary>
        /// Gets client module mouse hook instance.
        /// </summary>
        IMouseHook MouseHook { get; }

        /// <summary>
        /// Gets client module shell hook instance.
        /// </summary>
        IShellHook ShellHook { get; }

        /// <summary>
        /// Enables or disables client secuirty configuration.
        /// </summary>
        bool IsSecurityEnabled { get; set; }

        /// <summary>
        /// Gets if Maintenance mode is enabled.
        /// </summary>
        bool IsInMaintenance { get; }

        /// <summary>
        /// Gets or set client langauge.
        /// </summary>
        string Language { get; set; }

        /// <summary>
        /// Gets if there is a user logged in.
        /// </summary>
        bool IsUserLoggedIn { get; }

        /// <summary>
        /// Gets if user is currently logging in.
        /// </summary>
        bool IsUserLoggingIn { get; }

        /// <summary>
        /// Gets if user login can be initiated.
        /// </summary>
        bool CanLogin { get; }

        /// <summary>
        /// Gets if user logout can be initiated.
        /// </summary>
        bool CanLogout { get; }

        /// <summary>
        /// Gets the current user login state.
        /// </summary>
        LoginState LoginState { get; }

        /// <summary>
        /// Gets if module shutdowon or restart is initiated.
        /// </summary>
        bool IsShuttingDown { get; }

        #endregion

        #region Functions

        /// <summary>
        /// Sets settings value by name.
        /// </summary>
        /// <param name="name">Value name.</param>
        /// <param name="value">Value string.</param>
        void SetSettingsValue(string name, string value);

        /// <summary>
        /// Sets settings value by name.
        /// </summary>
        /// <param name="name">Value name.</param>
        /// <param name="value">Value object.</param>
        void SetSettingsValue(string name, object value);

        /// <summary>
        /// Gets settings value.
        /// </summary>
        /// <typeparam name="T">Value type.</typeparam>
        /// <param name="name">Value name.</param>
        /// <returns>Value of <typeparamref name="T"/></returns>
        T GetSettingsValue<T>(string name);

        /// <summary>
        /// Sets the system power state.
        /// </summary>
        /// <param name="state">Requested power satate.</param>
        /// <param name="force">Bool enable forcing.</param>
        /// <returns>True or false.</returns>
        /// <remarks>If user logged in no user data will be saved.</remarks>
        bool SetPowerState(PowerStates state, bool force);

        /// <summary>
        /// Stops (terminates) client module.
        /// <remarks>If user logged in no user data will be saved.</remarks>
        /// </summary>
        void Stop();

        /// <summary>
        /// Restarts the client.
        /// <remarks>If user logged in no user data will be saved.</remarks>
        /// </summary>
        void Restart();

        /// <summary>
        /// Shows notification window.
        /// </summary>
        MessageBoxResult NotifyUser(string message, string title, MessageBoxButton buttons, MessageBoxImage icon, bool dialog);

        /// <summary>
        /// Shows notification window.
        /// </summary>
        MessageBoxResult NotifyUser(string message, string title, bool dialog);

        /// <summary>
        /// Shows notification window.
        /// </summary>
        MessageBoxResult NotifyUser(string message, WindowShowParams parameters, out ISplashWindowModelBase splashModel);

        /// <summary>
        /// Creates notification model.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="parameters">Parameters.</param>
        /// <returns>Notification model instance.</returns>
        ISplashWindowModelBase CreateNotificationModel(string message, WindowShowParams parameters);

        /// <summary>
        /// Gets localized resource from current language dictionary.
        /// </summary>
        /// <typeparam name="T">Resource type.</typeparam>
        /// <param name="resourceId">Resource key.</param>
        /// <returns>Found resource.</returns>
        T GetLocalizedObject<T>(string resourceId) where T : class;

        /// <summary>
        /// Gets localized resource from current language dictionary.
        /// </summary>
        /// <typeparam name="T">Resource type.</typeparam>
        /// <param name="enumValue">Enum Value.</param>
        /// <returns>Found resource.</returns>
        T GetLocalizedObject<T>(Enum enumValue) where T : class;

        /// <summary>
        /// Sets new password for current user.
        /// </summary>
        /// <param name="newPassword">New password.</param>
        void SetUserPassword(string newPassword);

        /// <summary>
        /// Sets current user info.
        /// </summary>
        /// <param name="profile">User profile.</param>
        void SetUserInfo(IUserProfile profile);

        #endregion        
    }
}
