using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLib.ViewModels
{
    #region IWizardSwitchValidate
    public interface IWizardSwitchValidate : IWizardItemViewModel, INotifyDataErrorInfo
    {
        Task<bool> SwitchValidateAsync();
        bool Validate();
    }
    #endregion
}
