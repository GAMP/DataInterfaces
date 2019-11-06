namespace ServerService.Services
{
    /// <summary>
    /// View localization service.
    /// </summary>
    public interface IViewLocalizerService
    {
        #region FUNCTIONS

        /// <summary>
        /// Gets localized string value.
        /// </summary>
        /// <param name="key">Localization key.</param>
        /// <returns>Localized string value.</returns>
        string GetLocalizedStringValue(string key); 

        #endregion
    }
}
