namespace Client.ViewModels
{
    public interface IMessageDialogViewModel
    {
        #region PROPERTIES
        
        /// <summary>
        /// Gets or sets dialog message.
        /// </summary>
        string Message { get; set; }

        /// <summary>
        /// Gets or sets dialog buttons.
        /// </summary>
        MessageDialogButtons Buttons { get; set; } 

        #endregion
    }
}