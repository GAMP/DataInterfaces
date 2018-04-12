using SharedLib.Views;
using System.Threading.Tasks;

namespace Manager.Modules
{
    /// <summary>
    /// Report module interface.
    /// </summary>
    public interface IReportModule
    {
        #region PROPERTIES

        /// <summary>
        /// Gets module view.
        /// </summary>
        IView View { get; }

        /// <summary>
        /// Gets or sets if module is selected.
        /// </summary>
        bool IsSelected { get; set; }

        #endregion

        #region FUNCTIONS

        /// <summary>
        /// Generate report.
        /// </summary>
        /// <returns>Assoicated task.</returns>
        Task GenerateAsync();

        /// <summary>
        /// Ensures any pending operation is canceled.
        /// </summary>
        void EnsureCanceled();

        #endregion
    }
}
