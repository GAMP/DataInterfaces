using Client.ViewModels;
using SharedLib.Views;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Client
{
    public interface IShellWindow :  IView
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

        Task ShowOverlayAsync(object content, bool allowClosing);

        Task ShowOverlayAsync(object content, bool allowClosing, CancellationToken ct);

        /// <summary>
        /// Hides current overlay.
        /// </summary>
        /// <param name="cancel">
        /// Indicats if overlay closing should be handled as cancel.
        /// </param>
        void HideCurrentOverlay(bool cancel);

        void HideCurrentOverlay();

        event EventHandler<OverlayEventArgs> OverlayEvent;

        Task ShowOverlayAsync(IMediaViewModel mediaModel);
        Task ShowOverlayAsync(IMediaViewModel mediaModel, bool allowClosing);
        Task ShowOverlayAsync(IMediaViewModel mediaModel, CancellationToken ct);
        Task ShowOverlayAsync(IMediaViewModel mediaModel, bool allowClosing, CancellationToken ct);

        #endregion
    }

}
