using System;

namespace SharedLib
{
    public interface IItemBase
    {
        IItemBase Container { get; set; }
        bool IsSelected { get; set; }
        int ID { get; set; }
        bool IsVirtual { get; set; }
    }
}
