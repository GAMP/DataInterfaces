using System;
using System.ComponentModel;

namespace SharedLib.ViewModels
{
    public interface IValidateViewModelBase
    {
        bool HasErrors { get; }
        bool HasSelfErrors { get; }
        bool IsValid { get; }

        event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        void Validate();
    }
}