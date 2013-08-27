using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Xml;
using System.Windows.Media;
using System.Windows;
using System.Windows.Data;
using System.ComponentModel;
using System.Linq;
using SkinInterfaces;
using System.IO;
using System.Reflection;
using SkinLib;
using SharedLib;

namespace SkinLib
{
    /// <summary>
    /// Represents UI Layout configuration.
    /// </summary>
    public class UILayout :
        UIConfigurationChild,
        IUILayout
    {
        #region Constructor

        /// <summary>
        /// Creates a new instance of layout.
        /// </summary>
        /// <param name="config">UIConfiguration instance.</param>
        public UILayout(UIConfiguration config):base(config)
        {
            #region Validation
            if (config == null)
                throw new ArgumentNullException("Configuration", "Layout configuration may not be null.");
            #endregion

            this.Configuration = config;
        }

        #endregion

        #region Fields
        private double
            width,
            height;
        private int
            resolutionWidth,
            resolutionHeight,
            left,
            top;
        private string
            configurationName,
            imagePath;
        private bool
            isDefault,
            mIsInitialized;
        private Brush backroundBrush;
        private XmlNode xmlRepresentation;
        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets wether current interface configuration is default.
        /// </summary>
        public bool IsDefault
        {
            get { return this.isDefault; }
            set
            {
                this.isDefault = value;
                this.RaisePropertyChanged("IsDefault");
            }
        }

        /// <summary>
        /// Gets resolution Width.
        /// </summary>
        public int ResolutionWidth
        {
            get { return this.resolutionWidth; }
            set
            {
                this.resolutionWidth = value;
                this.RaisePropertyChanged("ResolutionWidth");
            }
        }

        /// <summary>
        /// Gets resolution Height.
        /// </summary>
        public int ResolutionHeight
        {

            get { return this.resolutionHeight; }
            set
            {
                this.resolutionHeight = value;
                this.RaisePropertyChanged("ResolutionHeight");
            }
        }

        /// <summary>
        /// Gets or sets interface width.
        /// </summary>
        public double Width
        {
            get { return this.width; }
            set
            {
                this.width = value;
                this.RaisePropertyChanged("Width");
            }
        }

        /// <summary>
        /// Gets or sets interface height.
        /// </summary>
        public double Height
        {
            get { return this.height; }
            set
            {
                this.height = value;
                RaisePropertyChanged("Height");
            }
        }

        /// <summary>
        /// Gets or sets interface left position.
        /// </summary>
        public int Left
        {
            get { return this.left; }
            set
            {
                this.left = value;
                RaisePropertyChanged("Left");
            }
        }

        /// <summary>
        /// Gets or sets interface top position.
        /// </summary>
        public int Top
        {
            get { return this.top; }
            set
            {
                this.top = value;
                this.RaisePropertyChanged("Top");
            }
        }

        /// <summary>
        /// Gets or sets the name of current configuration.
        /// </summary>
        public string Name
        {
            get { return this.configurationName; }
            set
            {
                this.configurationName = value;
                this.RaisePropertyChanged("Name");
            }
        }

        /// <summary>
        /// Gets or sets the brush for the backgound.
        /// </summary>
        public Brush Background
        {
            get { return this.backroundBrush; }
            set
            {
                this.backroundBrush = value;
                this.RaisePropertyChanged("Background");
            }
        }

        /// <summary>
        /// Gets or sets the path to the background image for the current layout.
        /// </summary>
        public string ImagePath
        {
            get { return this.imagePath; }
            set
            {
                this.imagePath = value;
                this.RaisePropertyChanged("ImagePath");
            }
        }

        /// <summary>
        /// Gets or sets XML Node representing the class.
        /// </summary>
        public XmlNode XmlRepresentation
        {
            get { return this.xmlRepresentation; }
            set
            {
                this.xmlRepresentation = value;
                this.RaisePropertyChanged("XmlRepresentation");
            }
        } 

        /// <summary>
        /// Gets if configuration was previously initialized.
        /// </summary>
        public bool IsInitialized
        {
            get { return this.mIsInitialized; }
            protected set
            {
                this.mIsInitialized = value;
                this.RaisePropertyChanged("IsInitialized");
            }
        }

        #endregion   

        #region Functions

        public void Apply()
        {
            XmlElement ElementNode = (XmlElement)this.XmlRepresentation.SelectSingleNode("UserControls");
            foreach (XmlElement ChildElementNode in ElementNode.ChildNodes)
            {
                //continue if no GUID specified
                if (ChildElementNode.HasAttribute("GUID") == false)
                    continue;

                //get GUID string
                string GUIDString = ChildElementNode.Attributes["GUID"].Value;

                //continue iof GUID is invalid
                if (!this.Configuration.IsValidGUID(GUIDString))
                    continue;

                //continue if no component exists
                if (!this.Configuration.HasComponent(GUIDString))
                    continue;

                //apply configuration
                if (this.Configuration.UserControlDictionary.ContainsKey(GUIDString))
                {
                    var controlInstance = this.Configuration.UserControlDictionary[GUIDString];
                    if (controlInstance != null)
                        this.ApplyToElement(controlInstance, ChildElementNode);
                }
            }
            this.IsInitialized = true;
        }

        private void ApplyToElement(FrameworkElement Element, XmlElement ElementNode)
        {
            #region Enums

            if (ElementNode.HasAttribute("Visibility"))
                Element.Visibility = (Visibility)Enum.Parse(typeof(Visibility), ElementNode.Attributes["Visibility"].Value);

            if (ElementNode.HasAttribute("HorizontalAlignment"))
                Element.HorizontalAlignment = (HorizontalAlignment)
                    Enum.Parse(typeof(HorizontalAlignment), ElementNode.Attributes["HorizontalAlignment"].Value);

            if (ElementNode.HasAttribute("VerticalAlignment"))
                Element.VerticalAlignment = (VerticalAlignment)Enum.Parse(typeof(VerticalAlignment), ElementNode.Attributes["VerticalAlignment"].Value);

            #endregion

            #region Thickness

            if (ElementNode.HasAttribute("Margin"))
                Element.Margin = (Thickness)new ThicknessConverter().ConvertFromInvariantString(ElementNode.Attributes["Margin"].Value);

            #endregion

            #region Integers

            if (ElementNode.HasAttribute("ZIndex"))
            {
                int tempInt;
                if (int.TryParse(ElementNode.Attributes["ZIndex"].Value.ToString(), out tempInt))
                    Element.SetValue(Canvas.ZIndexProperty, tempInt);
            }

            if (ElementNode.HasAttribute("Row"))
            {
                int tempInt;
                if (int.TryParse(ElementNode.Attributes["Row"].Value.ToString(), out tempInt))
                    Element.SetValue(Grid.RowProperty, tempInt);
            }

            if (ElementNode.HasAttribute("Column"))
            {
                int tempInt;
                if (int.TryParse(ElementNode.Attributes["Column"].Value.ToString(), out tempInt))
                    Element.SetValue(Grid.ColumnProperty, tempInt);
            }

            if (ElementNode.HasAttribute("ColumnSpan"))
            {
                int tempInt;
                if (int.TryParse(ElementNode.Attributes["ColumnSpan"].Value.ToString(), out tempInt))
                    Element.SetValue(Grid.ColumnSpanProperty, tempInt);
            }

            if (ElementNode.HasAttribute("RowSpan"))
            {
                int tempInt;
                if (int.TryParse(ElementNode.Attributes["RowSpan"].Value.ToString(), out tempInt))
                    Element.SetValue(Grid.RowSpanProperty, tempInt);
            }

            if (ElementNode.HasAttribute("Top"))
            {
                int tempInt;
                if (int.TryParse(ElementNode.Attributes["Top"].Value.ToString(), out tempInt))
                    Element.SetValue(Canvas.TopProperty, tempInt);
            }

            if (ElementNode.HasAttribute("Left"))
            {
                int tempInt;
                if (int.TryParse(ElementNode.Attributes["Left"].Value.ToString(), out tempInt))
                    Element.SetValue(Canvas.LeftProperty, tempInt);
            }

            #endregion

            #region Doubles

            //create shared converter
            DoubleConverter doubleConverter = new DoubleConverter();

            if (ElementNode.HasAttribute("Opacity"))
            {
                double tempDouble;
                if (double.TryParse(doubleConverter.ConvertFromInvariantString(ElementNode.Attributes["Opacity"].Value).ToString(), out tempDouble))
                    Element.Opacity = tempDouble;
            }

            if (ElementNode.HasAttribute("Width"))
            {
                double tempDouble;
                if (double.TryParse(doubleConverter.ConvertFromInvariantString(ElementNode.Attributes["Width"].Value).ToString(), out tempDouble))
                    Element.Width = tempDouble;
            }

            if (ElementNode.HasAttribute("Height"))
            {
                double tempDouble;
                if (double.TryParse(doubleConverter.ConvertFromInvariantString(ElementNode.Attributes["Height"].Value).ToString(), out tempDouble))
                    Element.Height = tempDouble;
            }

            if (ElementNode.HasAttribute("MinHeight"))
            {
                double tempDouble;
                if (double.TryParse(doubleConverter.ConvertFromInvariantString(ElementNode.Attributes["MinHeight"].Value).ToString(), out tempDouble))
                    Element.MinHeight = tempDouble;
            }

            if (ElementNode.HasAttribute("MinWidth"))
            {
                double tempDouble;
                if (double.TryParse(doubleConverter.ConvertFromInvariantString(ElementNode.Attributes["MinWidth"].Value).ToString(), out tempDouble))
                    Element.MinWidth = tempDouble;
            }

            if (ElementNode.HasAttribute("MaxWidth"))
            {
                double tempDouble;
                if (double.TryParse(doubleConverter.ConvertFromInvariantString(ElementNode.Attributes["MaxWidth"].Value).ToString(), out tempDouble))
                    Element.MaxWidth = tempDouble;
            }

            if (ElementNode.HasAttribute("MaxHeight"))
            {
                double tempDouble;
                if (double.TryParse(doubleConverter.ConvertFromInvariantString(ElementNode.Attributes["MaxHeight"].Value).ToString(), out tempDouble))
                    Element.MaxHeight = tempDouble;
            }

            #endregion

            #region Dependency Properties
            foreach (FieldInfo field in typeof(ExternalProperties).GetFields())
            {
                if (object.ReferenceEquals(field.FieldType, typeof(DependencyProperty)))
                {
                    DependencyProperty protperty = (DependencyProperty)field.GetValue(null);
                    TypeConverter converter = TypeDescriptor.GetConverter(protperty.PropertyType);
                    if (ElementNode.HasAttribute(protperty.Name))
                    {
                        Element.SetValue(protperty, converter.ConvertFrom(ElementNode.Attributes[protperty.Name].Value));
                    }
                    else
                    {
                        Element.SetValue(protperty, protperty.DefaultMetadata.DefaultValue);
                    }
                }
            }
            #endregion
        }

        public XmlNode ToXml()
        {
            XmlDocument XmlDoc = new XmlDocument();
            XmlElement XmlElement = XmlDoc.CreateElement("Layout");
            XmlDoc.AppendChild(XmlElement);
            XmlElement.SetAttribute("Name", this.Name);
            XmlElement.SetAttribute("ImagePath", this.ImagePath);
            XmlElement.SetAttribute("Width", new DoubleConverter().ConvertToInvariantString(this.Width.ToString()));
            XmlElement.SetAttribute("Height", new DoubleConverter().ConvertToInvariantString(this.Height));
            XmlElement.SetAttribute("IsDefault", this.IsDefault.ToString());
            XmlElement.SetAttribute("ResolutionWidth", new DoubleConverter().ConvertToInvariantString(this.ResolutionWidth));
            XmlElement.SetAttribute("ResolutionHeight", new DoubleConverter().ConvertToInvariantString(this.ResolutionHeight));
            XmlElement.SetAttribute("Left", this.Left.ToString());
            XmlElement.SetAttribute("Top", this.Top.ToString());
            XmlElement UserControlsElement = XmlDoc.CreateElement("UserControls");
            foreach (FrameworkElement Element in this.Configuration.UserControls)
            {
                XmlNode ElementXml = this.ToXml(Element);
                XmlNode ImportNode = XmlDoc.ImportNode(ElementXml, true);
                UserControlsElement.AppendChild(ImportNode);
            }
            XmlDoc.SelectSingleNode("Layout").AppendChild(UserControlsElement);
            return XmlDoc.FirstChild;
        }

        protected XmlNode ToXml(FrameworkElement element)
        {
            XmlDocument document = new XmlDocument();
            XmlElement child = document.CreateElement(element.GetType().ToString());
            document.AppendChild(child);

            #region Base attributes saving
            child.SetAttribute("Width", new DoubleConverter().ConvertToInvariantString(element.Width));
            child.SetAttribute("Height", new DoubleConverter().ConvertToInvariantString(element.Height));
            child.SetAttribute("HorizontalAlignment", element.HorizontalAlignment.ToString());
            child.SetAttribute("VerticalAlignment", element.VerticalAlignment.ToString());
            child.SetAttribute("Margin", new ThicknessConverter().ConvertToInvariantString(element.Margin));
            child.SetAttribute("Visibility", element.Visibility.ToString());
            child.SetAttribute("ZIndex", Canvas.GetZIndex(element).ToString());
            child.SetAttribute("Row", Grid.GetRow(element).ToString());
            child.SetAttribute("Column", Grid.GetColumn(element).ToString());
            child.SetAttribute("RowSpan", Grid.GetRowSpan(element).ToString());
            child.SetAttribute("ColumnSpan", Grid.GetColumnSpan(element).ToString());
            child.SetAttribute("Top", Canvas.GetTop(element).ToString());
            child.SetAttribute("Left", Canvas.GetLeft(element).ToString());
            child.SetAttribute("MinWidth", new DoubleConverter().ConvertToInvariantString(element.MinWidth));
            child.SetAttribute("MinHeight", new DoubleConverter().ConvertToInvariantString(element.MinHeight));
            child.SetAttribute("MaxWidth", new DoubleConverter().ConvertToInvariantString(element.MaxWidth));
            child.SetAttribute("MaxHeight", new DoubleConverter().ConvertToInvariantString(element.MaxHeight));
            if (element.VisualState() == SkinInterfaces.ElementVisualState.Minimized)
            {
                child.SetAttribute("Opacity", ((FrameworkElement)element).RestoreVisuals().Opacity.ToString());
            }
            else
            {
                child.SetAttribute("Opacity", element.Opacity.ToString());
            }
            #endregion

            #region Dependency properties saving
            foreach (FieldInfo field in typeof(ExternalProperties).GetFields())
            {
                if (object.ReferenceEquals(field.FieldType, typeof(DependencyProperty)))
                {
                    DependencyProperty property = (DependencyProperty)field.GetValue(null);

                    //Check if object dependency property is set to default value 
                    object propertyValue = element.GetValue(property);

                    //Only save this property configuration if not set to default value
                    if (propertyValue != property.DefaultMetadata.DefaultValue)
                        child.SetAttribute(property.Name, propertyValue.ToString());                   
                }
            }
            #endregion

            return document.FirstChild;
        }

        /// <summary>
        /// Accepts the current Layout.
        /// </summary>
        public void Accept()
        {
            this.XmlRepresentation = this.ToXml();
            this.IsInitialized = false;
        }      

        #endregion
    }
}
