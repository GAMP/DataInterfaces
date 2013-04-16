using System;
using SkinLib;
using System.Collections.ObjectModel;
using System.Windows;

namespace SkinLib
{
    public interface IUILayout
    {
        void Accept();
        System.Windows.Media.Brush Background { get; set; }
        IUIConfiguration Configuration { get; }
        ReadOnlyCollection<FrameworkElement> Controls { get; }
        double Height { get; set; }
        string ImagePath { get; set; }
        bool IsDefault { get; set; }
        bool IsInitialized { get; }
        int Left { get; set; }
        void Load();
        string Name { get; set; }
        int ResolutionHeight { get; set; }
        int ResolutionWidth { get; set; }
        int Top { get; set; }
        System.Xml.XmlNode ToXml();
        System.Windows.Data.ListCollectionView UserControls { get; }
        double Width { get; set; }
        System.Xml.XmlNode XmlRepresentation { get; set; }
    }
}
