using System.Threading;
using System.Threading.Tasks;

namespace Client
{
    /// <summary>
    /// Client dialog service.
    /// </summary>
    public interface IDialogService
    {
        #region FUNCTIONS
        
        /// <summary>
        /// Shows dialog.
        /// </summary>
        /// <param name="content">Dialog content.</param>
        /// <returns>Associated task.</returns>
        Task<bool> TryShowDialogAsync(object content);

        /// <summary>
        /// Shows dialog.
        /// </summary>
        /// <param name="content">Dialog content.</param>
        /// <param name="ct">Cancellation token.</param>
        /// <returns>Associated task.</returns>
        /// <remarks>The function will block untill dialog is shown or operation canceled.</remarks>
        Task ShowDialogAsync(object content, CancellationToken ct);

        /// <summary>
        /// Shows dialog.
        /// </summary>
        /// <param name="content">Dialog content.</param>
        /// <returns></returns>
        Task ShowDialogAsync(object content);

        /// <summary>
        /// Shows accept dialog.
        /// </summary>
        /// <param name="message">Dialog message.</param>
        /// <param name="ct">Cancellation token.</param>
        /// <returns>True if dialog was accepted, otherwise false.</returns>
        Task<bool> ShowAcceptDialogAsync(string message, CancellationToken ct);

        /// <summary>
        /// Shows accept dialog.
        /// </summary>
        /// <param name="message">Dialog message.</param>
        /// <returns>True if dialog was accepted, otherwise false.</returns>
        Task<bool> ShowAcceptDialogAsync(string message);

        /// <summary>
        /// Shows accept dialog.
        /// </summary>
        /// <param name="message">Dialog message.</param>
        /// <param name="buttons">Dialog buttons.</param>
        /// <returns>True if dialog was accepted, otherwise false.</returns>
        Task<bool> ShowAcceptDialogAsync(string message, MessageDialogButtons buttons);

        /// <summary>
        /// Shows accept dialog.
        /// </summary>
        /// <param name="message">Dialog message.</param>
        /// <param name="buttons">Dialog buttons.</param>
        /// <param name="ct">Cancellation token.</param>
        /// <returns></returns>
        Task<bool> ShowAcceptDialogAsync(string message, MessageDialogButtons buttons, CancellationToken ct);

        /// <summary>
        /// Hides current dialog.
        /// </summary>
        void HideCurrentDialog();

        #endregion
    }
}
