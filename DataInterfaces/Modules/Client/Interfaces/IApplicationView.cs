﻿using SharedLib.Applications;
using System;

namespace Client.ViewModels
{
    /// <summary>
    /// Application profile view model interface.
    /// </summary>
    public interface IApplicationView
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
    }
}
