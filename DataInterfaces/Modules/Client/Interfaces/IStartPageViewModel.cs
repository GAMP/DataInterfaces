using SharedLib;
using System;

namespace Client.ViewModels
{
    public interface IStartPageViewModel
    {
        /// <summary>
        /// Gets or sets current page view type.
        /// </summary>
        StartPageViewTypes CurrentViewType { get; set; }

        /// <summary>
        /// Select current application view model by application profile.
        /// </summary>
        /// <param name="profile">Application profile.</param>
        void SelectViewByApp(SharedLib.Applications.IApplicationProfile profile);
        
        /// <summary>
        /// Selects current application by id.
        /// </summary>
        /// <param name="appId">Application profile id.</param>
        void SelectViewByAppId(int appId);
        
        /// <summary>
        /// Gets application view model by application profile id.
        /// </summary>
        /// <param name="appId">Application profile id.</param>
        /// <returns>Application view model, Throws ArgumentException in case no application found with specified id.</returns>
        IApplicationViewModel GetView(int appId);
    }
}
