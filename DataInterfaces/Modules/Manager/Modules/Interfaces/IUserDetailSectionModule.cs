using Manager.ViewModels;
using System.Threading.Tasks;

namespace Manager.Modules
{
    /// <summary>
    /// User detail section module interface.
    /// </summary>
    public interface IUserDetailSectionModule
    {
        #region FUNCTIONS
        
        /// <summary>
        /// Starts the module.
        /// </summary>
        /// <returns>Associated task.</returns>
        Task StartAsync();

        /// <summary>
        /// Stops the module.
        /// </summary>
        /// <returns>Associated task.</returns>
        Task StopAsync();

        /// <summary>
        /// Initializes the module.
        /// </summary>
        /// <param name="user">User view model instance.</param>
        /// <returns>Associated task.</returns>
        Task InitializeAync(IUserMemberViewModel user);

        #endregion

        #region PROPERTIES
        
        /// <summary>
        /// Gets icon resource.
        /// </summary>
        string IconResource { get; }

        /// <summary>
        /// Gets header string.
        /// </summary>
        string Header { get; }

        /// <summary>
        /// Gets or sets if module is currently active.
        /// </summary>
        bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets if module is selected.
        /// </summary>
        bool IsSelected { get; set; }

        #endregion
    }
}
