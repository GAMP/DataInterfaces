using System.Collections.Generic;

namespace Client.ViewModels
{
    public interface IAppExeViewModelLocator
    {
        IList<IAppExeViewModel> ListSource { get; }
    }
}
