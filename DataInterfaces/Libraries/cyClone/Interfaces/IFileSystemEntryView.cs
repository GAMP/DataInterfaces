using System;
using SharedLib;

namespace CyClone.ViewModels
{
    public interface IFileSystemEntryView:IItemBase
    {
        object Entry { get; }
        bool IsHidden { get; }
        bool IsSystem { get; }
        string Name { get; }
        bool IsDrive { get; }
        T EntryAs<T>();
        string FullName
        {
            get;
        }
        string Directory
        {
            get;
        }
    }
}
