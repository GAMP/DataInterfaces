using System;
using System.Threading.Tasks;

namespace Manager.Services
{
    /// <summary>
    /// Manager message service dialog controller.
    /// </summary>
    public interface IProgressDialogController
    {
        /// <summary>
        /// Occurs on dialog cancelation.
        /// </summary>
        event EventHandler Canceled;

        /// <summary>
        /// Gets if cancelation occured.
        /// </summary>
        bool IsCanceled { get; }

        /// <summary>
        /// Begins an operation to close the ProgressDialog.
        /// </summary>
        /// <returns>A task representing the operation.</returns>
        Task CloseAsync();

        /// <summary>
        /// Sets dialog to indeterminate progress.
        /// </summary>
        void SetIndeterminate();

        /// <summary>
        /// Sets dialog message.
        /// </summary>
        /// <param name="message">Message.</param>
        void SetMessage(string message);

        /// <summary>
        /// Sets dialog title.
        /// </summary>
        /// <param name="title">Title.</param>
        void SetTitle(string title);
    }
}
