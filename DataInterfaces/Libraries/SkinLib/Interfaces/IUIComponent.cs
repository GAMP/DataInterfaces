using System;

namespace SkinLib
{
    #region IUIComponent
    public interface IUIComponent
    {
        string AssemblyName { get; set; }
        string Description { get; set; }
        System.Windows.FrameworkElement Element { get; set; }
        string GUID { get; set; }
        string Title { get; set; }
        string ToString();
        string Type { get; set; }
    } 
    #endregion
}
