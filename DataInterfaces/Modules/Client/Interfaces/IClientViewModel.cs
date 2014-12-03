using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using SharedLib.ViewModels;
using SharedLib.Applications;
using System.Collections;
using SkinLib;
using SharedLib;

namespace Client
{
    #region IClientViewModel
    /// <summary>
    /// Client View Model Interface. 
    /// <remarks>
    /// This interface exposes the class with the required functionality and data to the skin and plugins/component.
    /// </remarks>
    /// </summary>
    public interface IClientViewModel
    {
        /// <summary>
        /// Gets the Clients current category representation model.
        /// </summary>
        ICategoryView StartPageView
        {
            get;
        }

        /// <summary>
        /// Gets the instance of the client.
        /// </summary>
        IClient Client
        {
            get;
        }

        /// <summary>
        /// Gets the instance of UIHandler.
        /// </summary>
        IUIHandler SkinHandler
        {
            get;
        }

        /// <summary>
        /// Sets the news feeds list.
        /// </summary>
        /// <param name="newsList">News list.</param>
        void SetNewsList(IList newsList);

        /// <summary>
        /// Set the startpage type.
        /// </summary>
        /// <param name="type">Type.</param>
        void SetStartPageView(StartPageViewTypes type);

        /// <summary>
        /// Navigates to application.
        /// </summary>
        /// <param name="profile">Application Profile.</param>
        void NavigateToApplication(IApplicationProfile profile);
    } 
    #endregion
}
