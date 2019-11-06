using System.Threading.Tasks;

namespace ServerService.Services
{
    /// <summary>
    /// Razor view renderer service interface.
    /// </summary>
    public interface IViewRenderService
    {
        #region FUNCTIONS

        /// <summary>
        /// Renders specified view to HTML string.
        /// </summary>
        /// <param name="viewName">View name.</param>
        /// <param name="model">View model.</param>
        /// <returns>Rendered view string.</returns>
        Task<string> RenderToStringAsync(string viewName, object model);

        /// <summary>
        /// Renders specified embeded view to HTML string.
        /// </summary>
        /// <param name="viewName">View name.</param>
        /// <param name="model">View model.</param>
        /// <returns>Rendered view string.</returns>
        Task<string> RenderEmbededToStringAsync(string viewName, object model);

        #endregion
    }
}
