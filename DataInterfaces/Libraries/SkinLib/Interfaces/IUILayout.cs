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
        string ImagePath { get; set; }
        bool IsDefault { get; set; }
        bool IsInitialized { get; }       
        void Apply();
        string Name { get; set; }
        double Height { get; set; }
        double Width { get; set; }
        int ResolutionHeight { get; set; }
        int ResolutionWidth { get; set; }
        int Left { get; set; }
        int Top { get; set; }
        System.Xml.XmlNode ToXml();
        System.Xml.XmlNode XmlRepresentation { get; set; }
    }
}
