using System.Collections.Generic;
using System.Windows.Data;

namespace SharedLib.ViewModels
{
    public interface ITreeItemViewModel
    {
        IEnumerable<ITreeItemViewModel> Children { get; }
        void Initialize();
        bool? IsChecked { get; set; }
        bool IsExpanded { get; set; }
        bool IsInitiallySelected { get; }
        bool IsSelected { get; set; }
        string Name { get; set; }
        ITreeItemViewModel Parent { get; set; }
        void VerifyCheckState();
        void SetIsChecked(bool? value, bool updateChildren, bool updateParent);        
    }

    public interface ITreeItemViewModelObservable : ITreeItemViewModel
    {
        ListCollectionView ChildrenView { get; }
    }
}
