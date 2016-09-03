using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLib.ViewModels
{
    public interface IViewAwareModel
    {
        /// <summary>
        /// Gets view.
        /// </summary>
        object View { get; }
    }
}
