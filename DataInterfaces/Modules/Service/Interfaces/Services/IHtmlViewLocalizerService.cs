namespace ServerService.Services
{
    /// <summary>
    /// HTML View localizer service.
    /// </summary>
    public interface IHtmlViewLocalizerService
    {
        #region FUNCTIONS
        /// <summary>
        /// Gets localized html string value.
        /// </summary>
        /// <param name="key">Localization key.</param>
        /// <returns>Localized html string value.</returns>
        string GetLocalizedStringValue(string key);
        #endregion
    }
}
