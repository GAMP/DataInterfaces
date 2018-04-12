using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Data;
using SharedLib;
using SkinInterfaces;

namespace Client.ViewModels
{
    public interface IAppViewModel
    {
        /// <summary>
        /// Gets add date.
        /// </summary>
        DateTime AddDate { get;}

        /// <summary>
        /// Gets app id.
        /// </summary>
        int AppId { get; }


        /// <summary>
        /// Gets category id.
        /// </summary>
        int CategoryId { get; }

        /// <summary>
        /// Gets developer id.
        /// </summary>
        int? DeveloperId { get; }

        /// <summary>
        /// Gets publisher id.
        /// </summary>
        int? PublisherId { get;  }

        /// <summary>
        /// Gets description.
        /// </summary>
        string Description { get; }

  

        ListCollectionView Executables { get; }

        /// <summary>
        /// Gets executable titles.
        /// </summary>
        IEnumerable<string> ExecutableTitles { get; }

        /// <summary>
        /// Gets executable modes.
        /// </summary>
        IEnumerable<ApplicationModes> ExeModes { get; }

        NotifyTaskCompletion<byte[]> ImageData { get; }

        /// <summary>
        /// Gets rating.
        /// </summary>
        int Rating { get; }

        /// <summary>
        /// Gets release date.
        /// </summary>
        DateTime? ReleaseDate { get; }

        /// <summary>
        /// Gets title.
        /// </summary>
        string Title { get;  }
        int TotalExecutions { get; }
        double TotalExecutionTime { get; }
        int TotalRates { get;  }
        int UserRating { get;  }
    }
}