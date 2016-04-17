using Manager.ViewModels;
using SharedLib.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.ViewModels
{
    /// <summary>
    /// Exposed by user view model locator.
    /// </summary>
    public interface IHostViewModelLocator : IViewModelLocator<IHostViewModel>
    {
    }
}
