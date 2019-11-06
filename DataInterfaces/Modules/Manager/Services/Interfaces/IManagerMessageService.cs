using System;
using System.Threading.Tasks;

namespace Manager.Services
{
    /// <summary>
    /// Manager message service.
    /// </summary>
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

        /// <summary>
        /// Shows getting configuration message.
        /// </summary>
        /// <returns>Associated task.</returns>
        Task<IProgressDialogController> ShowGettingConfigurationAsync();

        /// <summary>
        /// Shows setting configuration message.
        /// </summary>
        /// <returns>Associated task.</returns>
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

        /// <summary>
        /// Shows message.
        /// </summary>
        /// <param name="title">Message title.</param>
        /// <param name="message">Message.</param>
        /// <returns>Dialog result.</returns>
        Task<ManagerMessageDialogResult> ShowMessageAsync(string title, string message);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="title"></param>
        /// <param name="message"></param>
        /// <param name="style"></param>
        /// <returns>Dialog result.</returns>
        Task<ManagerMessageDialogResult> ShowMessageAsync(string title, string message, ManagerMessageDialogStyle style);

        /// <summary>
        /// Shows modification detected message.
        /// </summary>
        /// <returns>Dialog result.</returns>
        Task<ManagerMessageDialogResult> ShowModificationsDetectedAsync();

        /// <summary>
        /// Shows warning message.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="style">Dialog style.</param>
        /// <returns>Dialog result.</returns>
        Task<ManagerMessageDialogResult> ShowWarningMessageAsync(string message, ManagerMessageDialogStyle style = ManagerMessageDialogStyle.Affirmative);

        /// <summary>
        /// Shows progress message.
        /// </summary>
        /// <param name="title">Title.</param>
        /// <param name="message">Message.</param>
        /// <param name="isCancelable">Indicates if cancelable.</param>
        /// <returns>Dialog result.</returns>
        Task<IProgressDialogController> ShowProgressAsync(string title, string message, bool isCancelable);

        #endregion
    }
}