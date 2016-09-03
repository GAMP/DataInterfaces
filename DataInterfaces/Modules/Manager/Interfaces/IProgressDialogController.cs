using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    }
}
