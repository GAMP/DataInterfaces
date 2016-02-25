using SharedLib.Applications;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Client.ViewModels
{
    /// <summary>
    /// Application profile view model interface.
    /// </summary>
    public interface IApplicationViewModel
    {
        /// <summary>
        /// Gets if view model has accessible executables.
        /// <remarks>
        /// If at least one deployment profile is defined at any contained executable true will be returned.
        /// </remarks>
        /// </summary>
        bool HasAccessibleExecutables { get; }

        /// <summary>
        /// Gets application porofile of this application view model.
        /// </summary>
        IApplicationProfile Profile { get; }

        /// <summary>
        /// Gets executables view models.
        /// </summary>
        IEnumerable<IExecutableViewModel> Executables { get; }
    }
}
