using System;
using System.Windows;

namespace SkinLib
{
    #region IUIComponent
    public interface IUIComponent
    {
        string AssemblyName { get; set; }
        string Description { get; set; }
        FrameworkElement Instance { get; set; }
        string GUID { get; set; }
        string Title { get; set; }
        string ToString();
        string Type { get; set; }
        bool HasInstance { get; }
    } 
    #endregion
}
