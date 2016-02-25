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
using Client.ViewModels;

namespace Client.ViewModels
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
        /// Gets StartPageViewModel.
        /// </summary>
        IStartPageViewModel StartPageView
        {
            get;
        }

        /// <summary>
        /// Gets client instance.
        /// </summary>
        IClient Client
        {
            get;
        }

        /// <summary>
        /// Gets UIHandler instance.
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
