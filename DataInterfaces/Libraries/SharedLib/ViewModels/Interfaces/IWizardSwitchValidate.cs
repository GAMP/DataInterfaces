using System.ComponentModel;
using System.Threading.Tasks;

namespace SharedLib.ViewModels
{
    #region IWizardSwitchValidate
    public interface IWizardSwitchValidate : IWizardItemViewModel, INotifyDataErrorInfo
    {
        #region FUNCTIONS

        Task<bool> SwitchValidateAsync();

        bool Validate(); 

        #endregion
    }
    #endregion
}
