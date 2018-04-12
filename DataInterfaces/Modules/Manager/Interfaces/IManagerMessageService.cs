using System;
using System.Threading.Tasks;

namespace Manager.Services
{
    public interface IManagerMessageService
    {
        #region FUNCTIONS

        /// <summary>
        /// Shows error message.
        /// </summary>
        /// <param name="message">Message.</param>
        void ShowError(string message);

        /// <summary>
        /// Shows error message for specified exception.
        /// </summary>
        /// <param name="ex">Exception instance.</param>
        void ShowError(Exception ex);

        /// <summary>
        /// Shows message.
        /// </summary>
        /// <param name="message">Message.</param>
        void ShowMessage(string message);

        /// <summary>
        /// Shows exception message dialog.
        /// </summary>
        /// <param name="ex">Exception instance.</param>
        /// <returns>Associated task.</returns>
        Task ShowExceptionMessageAsync(Exception ex);

        Task<IProgressDialogController> ShowGettingConfigurationAsync();

        Task<IProgressDialogController> ShowSettingConfigurationAsync();

        /// <summary>
        /// Shows item deletion confirmation message.
        /// </summary>
        /// <param name="itemsCount">Items count.</param>
        /// <returns>Dialog result.</returns>
        Task<ManagerMessageDialogResult> ShowDeleteMultipleMessageAsync(int itemsCount);

        /// <summary>
        /// Show single item deletion message.
        /// </summary>
        /// <param name="itemName">Item name.</param>
        /// <returns>Dialog result.</returns>
        Task<ManagerMessageDialogResult> ShowDeleteSingleMessageAsync(string itemName);

        Task<ManagerMessageDialogResult> ShowMessageAsync(string title, string message);

        Task<ManagerMessageDialogResult> ShowMessageAsync(string title, string message, ManagerMessageDialogStyle style);

        Task<ManagerMessageDialogResult> ShowModificationsDetectedAsync();

        Task<ManagerMessageDialogResult> ShowWarningMessageAsync(string message, ManagerMessageDialogStyle style = ManagerMessageDialogStyle.Affirmative);

        Task<IProgressDialogController> ShowProgressAsync(string title, string message, bool isCancelable); 

        #endregion
    }
}