using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLib
{
    /// <summary>
    /// Inteface implemented by object supporting checked state.
    /// </summary>
    public interface ICheckable
    {
        /// <summary>
        /// Gets or sets if item is checked.
        /// </summary>
        bool IsChecked
        {
            get; set;
        }
    }
}
