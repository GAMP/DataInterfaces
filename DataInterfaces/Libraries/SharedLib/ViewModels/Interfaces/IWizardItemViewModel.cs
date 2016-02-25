using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLib.ViewModels
{
    #region IWizardItemViewModel
    public interface IWizardItemViewModel
    {
        object View
        {
            get;
        }
    }
    #endregion
}
