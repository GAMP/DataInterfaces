using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharedLib;

namespace ServerService
{
    /// <summary>
    /// Service view model interface.
    /// </summary>
    public interface IServiceViewModel
    {
        /// <summary>
        /// Gets the service instance for this model.
        /// </summary>
        IService Service
        {
            get;
        }
        /// <summary>
        /// Gets or sets the current view of the model.
        /// </summary>
        ManagerViewTypes CurrentViewType
        {
            get;
            set;
        }
    }
 
}
