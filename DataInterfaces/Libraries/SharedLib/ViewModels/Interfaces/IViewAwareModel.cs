using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLib.ViewModels
{
    /// <summary>
    /// Represents a view aware model.
    /// </summary>
    public interface IViewAwareModel
    {
        #region PROPERTIES
        
        /// <summary>
        /// Gets view.
        /// </summary>
        object View { get; }
        
        #endregion
    }
}
