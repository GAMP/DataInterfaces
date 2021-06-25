using System;
using CoreLib;
using SharedLib;
using IntegrationLib;
using System.Windows;
using SharedLib.ViewModels;
using CoreLib.Hooking;
using SharedLib.User;
using System.ComponentModel;
using System.Threading.Tasks;
using ServerService;
using System.Collections.Generic;

namespace Client
{
    /// <summary>
    /// Client module interface.
    /// </summary>
    public interface IClient
    {
        #region EVENTS

        /// <summary>
        /// Occurs on client shutdown.
        /// </summary>
        event EventHandler<ShutDownEventArgs> ShutDown;

        /// <summary>
        /// Occurs on client startup.
        /// </summary>
        event EventHandler<StartUpEventArgs> StartUp;

        /// <summary>
        /// Occurs once user updates his profile.
        /// </summary>
        event EventHandler<UserProfileChangeArgs> UserProfileChange;

        /// <summary>
        /// Occurs once user updates his password.
        /// </summary>
        event EventHandler<UserPasswordChangeEventArgs> UserPasswordChange;

        /// <summary>
        /// Occurs on user login state change.
        /// </summary>
        event EventHandler<UserEventArgs> LoginStateChange;

        /// <summary>
        /// Occurs on input lock state change.
        /// </summary>
        event EventHandler<LockStateEventArgs> LockStateChange;

        /// <summary>
        /// Occurs on client id change.
        /// </summary>
        event EventHandler<IdChangeEventArgs> IdChange;

        /// <summary>
        /// Occurs on securtiy change.
        /// </summary>
        event EventHandler<SecurityStateArgs> SecurityStateChange;

        /// <summary>
        /// Occurs on execution context collection change.
        /// </summary>
        event EventHandler<CollectionChangeEventArgs> ExecutionContextCollectionChange;

        /// <summary>
        /// Occurs on execution context state change.
        /// </summary>
        event EventHandler<ExecutionContextStateArgs> ExecutionContextStateChage;

        /// <summary>
        /// Occurs on current activity change.
        /// </summary>
        event EventHandler<ClientActivityEventArgs> ActivityChange;

        /// <summary>
        /// Occurs on out of order state change.
        /// </summary>
        event EventHandler<OutOfOrderStateEventArgs> OutOfOrderStateChange;

        /// <summary>
        /// Occurs once application was rated by user.
        /// </summary>
        event EventHandler<ApplicationRateEventArgs> ApplicationRated;

        /// <summary>
        /// Occurs on app profile configuration change.
        /// </summary>
        event EventHandler<ProfilesChangeEventArgs> AppProfilesChange;

        /// <summary>
        /// Occurs on security profiles configuration change.
        /// </summary>
        event EventHandler<ProfilesChangeEventArgs> SecurityProfilesChange;

        /// <summary>
        /// Occurs on group configuration change.
        /// </summary>
        event EventHandler<EventArgs> GroupConfigurationChange;

        /// <summary>
        /// Occurs on maintenace mode change.
        /// </summary>
        event EventHandler<MaintenanceEventArgs> MaintenanceModeChange;

        /// <summary>
        /// Occurs on order status change.
        /// </summary>
        event EventHandler<OrderStatusChangeEventArgs> OrderStatusChange;

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets the client id.
        /// </summary>
        /// <remarks>
        /// This property is used to represent the client number.
        /// </remarks>
        int Id
        {
            get;
        }

        /// <summary>
        /// Gets client version ifnormation.
        /// </summary>
        string VersionInfo { get; }

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
        IntPtr ShellWindowHandle { get; }

        /// <summary>
        /// Gets client module keyboard hook instance.
        /// </summary>
        [Obsolete("Will be replaced or updated in new releases. Do not use.")]
        IKeyboardHook KeyBoardHook { get; }

        /// <summary>
        /// Gets client module mouse hook instance.
        /// </summary>
        [Obsolete("Will be replaced or updated in new releases. Do not use.")]
        IMouseLowLevelHook MouseHook { get; }

        /// <summary>
        /// Gets client module shell hook instance.
        /// </summary>
        [Obsolete("Will be replaced or updated in new releases. Do not use.")]
        IShellHook ShellHook { get; }

        /// <summary>
        /// Gets or sets if security is enabled.
        /// </summary>
        bool IsSecurityEnabled { get; set; }

        /// <summary>
        /// Gets if maintenance mode is enabled.
        /// </summary>
        bool IsInMaintenance { get; }

        /// <summary>
        /// Gets or sets if input is locked.
        /// </summary>
        bool IsInputLocked { get; set; }

        /// <summary>
        /// Gets or set client langauge.
        /// </summary>
        string Language { get; set; }

        /// <summary>
        /// Gets current user profile.
        /// </summary>
        IUserProfile CurrentUser { get; }

        /// <summary>
        /// Gets current user identity.
        /// </summary>
        /// <remarks>
        /// The identity will be set once user is logged in.
        /// </remarks>
        IUserIdentity CurrentUserIdentity { get; }

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

        #region FUNCTIONS

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
        MessageBoxResult NotifyUser(string message, WindowShowParams parameters, out INotifyWindowViewModel splashModel);

        /// <summary>
        /// Creates notification model.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="parameters">Parameters.</param>
        /// <returns>Notification model instance.</returns>
        INotifyWindowViewModel CreateNotificationModel(string message, WindowShowParams parameters);

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

        /// <summary>
        /// Logins user asynchronously.
        /// </summary>
        /// <param name="username">Username.</param>
        /// <param name="password">Password.</param>
        /// <returns>Login result.</returns>
        /// <remarks>
        /// By default null or empty passwords are allowed.
        /// </remarks>
        Task<LoginResult> LoginAsync(string username, string password);

        /// <summary>
        /// Logins user.
        /// </summary>
        /// <param name="username">Username.</param>
        /// <param name="password">Password.</param>
        /// <returns>Login result.</returns>
        /// <remarks>
        /// By default null or empty passwords are allowed.
        /// </remarks>
        LoginResult Login(string username, string password);

        /// <summary>
        /// Logins user.
        /// </summary>
        /// <param name="authHeaders">Authentication headers.</param>
        /// <param name="allowEmptyPasswords">Indicates if empty passwords should be allowed.</param>
        /// <returns>>Login result.</returns>
        LoginResult Login(Dictionary<string, object> authHeaders, bool allowEmptyPasswords);

        /// <summary>
        /// Logs out current user asynchronously.
        /// </summary>
        /// <returns>Logout task.</returns>
        Task LogoutAsync();

        /// <summary>
        /// Logs out current user.
        /// </summary>
        void Logout();

        /// <summary>
        /// Deserialize skin json configuration file to specified type.
        /// </summary>
        /// <typeparam name="T">Type.</typeparam>
        /// <param name="fileName">File name.</param>
        /// <returns>Type instance.</returns>
        T JsonDeserializeConfig<T>(string fileName) where T : SharedLib.Configuration.SkinConfig;

        /// <summary>
        /// Adds a message to log.
        /// </summary>
        /// <param name="message">Message.</param>
        void LogAdd(string message);

        /// <summary>
        /// Adds a message to log.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="category">Message category.</param>
        void LogAdd(string message, LogCategories category);

        /// <summary>
        /// Adds a error message to log.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="ex">Exception.</param>
        /// <param name="category">Message category.</param>
        void LogAddError(string message, Exception ex, LogCategories category);

        #endregion
    }
}
