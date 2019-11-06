using Client.ViewModels;
using SharedLib.Views;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Client
{
    /// <summary>
    /// Shell view interface.
    /// </summary>
    public interface IShellWindow : IView
    {
        #region FUNCTIONS

        /// <summary>
        /// Tries to show overlay.
        /// </summary>
        /// <param name="content">Overlay content.</param>
        /// <returns>True if overlay was shown, false if overlay is already showing.</returns>
        Task<bool> TryShowOverlayAsync(object content);

        /// <summary>
        /// Shows overlay.
        /// </summary>
        /// <param name="content">Overlay content.</param>
        /// <returns>Associated task.</returns>
        /// <remarks>
        /// If overlay is already showing the function will block untill overlay is shown.
        /// </remarks>
        Task ShowOverlayAsync(object content);

        /// <summary>
        /// Shows overlay.
        /// </summary>
        /// <param name="content">Overlay content.</param>
        /// <param name="ct">Cancelation token.</param>
        /// <returns>Associated task.</returns>
        /// <remarks>
        /// True if overlay was shown, false if overlay is already showing.
        /// </remarks>
        Task<bool> TryShowOverlayAsync(object content, CancellationToken ct);

        /// <summary>
        /// Shows overlay.
        /// </summary>
        /// <param name="content">Overlay content.</param>
        /// <param name="ct">Cancelation token.</param>
        /// <returns>Associated task.</returns>
        /// <remarks>
        /// If overlay is already showing the function will block untill overlay is shown.
        /// </remarks>
        Task ShowOverlayAsync(object content, CancellationToken ct);

        /// <summary>
        /// Shows overlay.
        /// </summary>
        /// <param name="content">Overlay content.</param>
        /// <param name="allowClosing">Specifies if automatic closing should occur.</param>
        /// <returns>>Associated task.</returns>
        Task ShowOverlayAsync(object content, bool allowClosing);

        /// <summary>
        /// Shows overlay.
        /// </summary>
        /// <param name="content">Overlay content.</param>
        /// <param name="allowClosing">Specifies if automatic closing should occur.</param>
        /// <param name="ct">Cancelation token.</param>
        /// <returns>Associated task.</returns>
        Task ShowOverlayAsync(object content, bool allowClosing, CancellationToken ct);

        /// <summary>
        /// Hides current overlay.
        /// </summary>
        /// <param name="cancel">
        /// Indicats if overlay closing should be handled as cancel.
        /// </param>
        void HideCurrentOverlay(bool cancel);

        /// <summary>
        /// Hides current overlay.
        /// </summary>
        void HideCurrentOverlay();

        /// <summary>
        /// Occurs on overlay change.
        /// </summary>
        event EventHandler<OverlayEventArgs> OverlayEvent;

        /// <summary>
        /// Shows overlay.
        /// </summary>
        /// <param name="mediaModel">Media model.</param>
        /// <returns>Associated task.</returns>
        Task ShowOverlayAsync(IMediaViewModel mediaModel);

        /// <summary>
        /// Shows overlay.
        /// </summary>
        /// <param name="mediaModel">Media model.</param>
        /// <param name="allowClosing">Indicates if closing is allowed.</param>
        /// <returns>Associated task.</returns>
        Task ShowOverlayAsync(IMediaViewModel mediaModel, bool allowClosing);

        /// <summary>
        /// Shows overlay.
        /// </summary>
        /// <param name="mediaModel">Media model.</param>
        /// <param name="ct">Cancellation token.</param>
        /// <returns>Associated task.</returns>
        Task ShowOverlayAsync(IMediaViewModel mediaModel, CancellationToken ct);

        /// <summary>
        /// Shows overlay.
        /// </summary>
        /// <param name="mediaModel">Media model.</param>
        /// <param name="allowClosing">Indicates if closing is allowed.</param>
        /// <param name="ct">Cancellation token.</param>
        /// <returns>Associated task.</returns>
        Task ShowOverlayAsync(IMediaViewModel mediaModel, bool allowClosing, CancellationToken ct);

        #endregion
    }
}
