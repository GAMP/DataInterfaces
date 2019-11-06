using System.IO;

namespace ServerService.Services
{
    /// <summary>
    /// HTML To PDF Converter service.
    /// </summary>
    public interface IHtmlToPdfConverterService
    {
        /// <summary>
        /// Converts an html string to pdf using default converter settings.
        /// </summary>
        /// <param name="html">Html string.</param>
        /// <returns></returns>
        MemoryStream ConvertToPdfFromHtmlString(string html);

        /// <summary>
        /// Converts an html string to pdf.
        /// </summary>
        /// <param name="html">Html string.</param>
        /// <param name="converterSettings">Converter settings.</param>
        /// <returns></returns>
        MemoryStream ConvertToPdfFromHtmlString(string html, HtmlToPdfConverterSettings converterSettings);

        /// <summary>
        /// Converts an html web page to pdf using default converter settings.
        /// </summary>
        /// <param name="url">Url of the page.</param>
        /// <returns></returns>
        MemoryStream ConvertToPdfFromUrl(string url);

        /// <summary>
        /// Converts an html web page to pdf.
        /// </summary>
        /// <param name="url">Url of the page.</param>
        /// <param name="converterSettings">Converter settings.</param>
        /// <returns></returns>
        MemoryStream ConvertToPdfFromUrl(string url, HtmlToPdfConverterSettings converterSettings);
    }
}
