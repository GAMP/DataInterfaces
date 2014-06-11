using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLib.Views
{
    /// <summary>
    /// Represents a view
    /// </summary>
    public interface IView
    {
        /// <summary>
        /// Gets or sets the data context of the view.
        /// </summary>
        object DataContext { get; set; }
    }
}
