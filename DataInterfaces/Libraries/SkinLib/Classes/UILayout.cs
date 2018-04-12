using System;
using System.Linq;
using System.Data;
using System.Windows.Controls;
using System.Xml;
using System.Windows.Media;
using System.Windows;
using System.ComponentModel;
using SkinInterfaces;
using System.Reflection;

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
            imagePath,
            videoPath;
        private bool
            isDefault,
            mIsInitialized;
        private Brush backroundBrush;
        private XmlNode xml;
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
                this.RaisePropertyChanged("Height");
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
                this.RaisePropertyChanged("Left");
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

        public string VideoPath
        {
            get { return this.videoPath; }
            set
            {
                this.videoPath = value;
                this.RaisePropertyChanged(nameof(this.VideoPath));
            }
        }

        /// <summary>
        /// Gets or sets XML node representing the class.
        /// </summary>
        public XmlNode Xml
        {
            get { return this.xml; }
            set
            {
                this.xml = value;
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
            #region VALIDATE
            if (this.Xml == null)
                throw new ArgumentNullException("XML representation is null"); 
            #endregion

            var userControlsNode = this.Xml.SelectSingleNode("UserControls");

            if (userControlsNode == null)
                return;

            //filter out xmlelement children, this can protect from trying to access comments (XmlComment) etc
            foreach (XmlElement childNode in userControlsNode.ChildNodes.Cast<XmlNode>().Where(x=> x is XmlElement))
            {
                try
                {
                    if (childNode.Attributes == null || childNode.Attributes.Count == 0)
                        return;

                    //continue if no GUID specified
                    if (childNode.HasAttribute("GUID") == false)
                        continue;

                    //get GUID string
                    string guidString = childNode.Attributes["GUID"].Value;

                    //continue iof GUID is invalid
                    if (!this.Configuration.IsValidGUID(guidString))
                        continue;

                    //continue if no component exists
                    if (!this.Configuration.HasComponent(guidString))
                        continue;

                    //apply configuration
                    if (this.Configuration.UserControlDictionary.ContainsKey(guidString))
                    {
                        var controlInstance = this.Configuration.UserControlDictionary[guidString];
                        if (controlInstance != null)
                            this.ApplyToElement(controlInstance, childNode);
                    }
                }
                catch(Exception ex)
                {
                    this.Configuration.Errors.Add(new Exception(String.Format("Could not apply component layout from xml node {0}", childNode.OuterXml), ex));
                }
            }
            this.IsInitialized = true;
        }

        private void ApplyToElement(FrameworkElement uiElement, XmlElement elementNode)
        {
            #region Enums

            if (elementNode.HasAttribute("Visibility"))
                uiElement.Visibility = (Visibility)Enum.Parse(typeof(Visibility), elementNode.Attributes["Visibility"].Value);

            if (elementNode.HasAttribute("HorizontalAlignment"))
                uiElement.HorizontalAlignment = (HorizontalAlignment)
                    Enum.Parse(typeof(HorizontalAlignment), elementNode.Attributes["HorizontalAlignment"].Value);

            if (elementNode.HasAttribute("VerticalAlignment"))
                uiElement.VerticalAlignment = (VerticalAlignment)Enum.Parse(typeof(VerticalAlignment), elementNode.Attributes["VerticalAlignment"].Value);

            #endregion

            #region Thickness

            if (elementNode.HasAttribute("Margin"))
                uiElement.Margin = (Thickness)new ThicknessConverter().ConvertFromInvariantString(elementNode.Attributes["Margin"].Value);

            #endregion

            #region Integers

            if (elementNode.HasAttribute("ZIndex"))
            {
                int tempInt;
                if (int.TryParse(elementNode.Attributes["ZIndex"].Value.ToString(), out tempInt))
                    uiElement.SetValue(Canvas.ZIndexProperty, tempInt);
            }

            if (elementNode.HasAttribute("Row"))
            {
                int tempInt;
                if (int.TryParse(elementNode.Attributes["Row"].Value.ToString(), out tempInt))
                    uiElement.SetValue(Grid.RowProperty, tempInt);
            }

            if (elementNode.HasAttribute("Column"))
            {
                int tempInt;
                if (int.TryParse(elementNode.Attributes["Column"].Value.ToString(), out tempInt))
                    uiElement.SetValue(Grid.ColumnProperty, tempInt);
            }

            if (elementNode.HasAttribute("ColumnSpan"))
            {
                int tempInt;
                if (int.TryParse(elementNode.Attributes["ColumnSpan"].Value.ToString(), out tempInt))
                    uiElement.SetValue(Grid.ColumnSpanProperty, tempInt);
            }

            if (elementNode.HasAttribute("RowSpan"))
            {
                int tempInt;
                if (int.TryParse(elementNode.Attributes["RowSpan"].Value.ToString(), out tempInt))
                    uiElement.SetValue(Grid.RowSpanProperty, tempInt);
            }

            if (elementNode.HasAttribute("Top"))
            {
                int tempInt;
                if (int.TryParse(elementNode.Attributes["Top"].Value.ToString(), out tempInt))
                    uiElement.SetValue(Canvas.TopProperty, tempInt);
            }

            if (elementNode.HasAttribute("Left"))
            {
                int tempInt;
                if (int.TryParse(elementNode.Attributes["Left"].Value.ToString(), out tempInt))
                    uiElement.SetValue(Canvas.LeftProperty, tempInt);
            }

            #endregion

            #region Doubles

            //create shared converter
            DoubleConverter doubleConverter = new DoubleConverter();

            if (elementNode.HasAttribute("Opacity"))
            {
                double tempDouble;
                if (double.TryParse(doubleConverter.ConvertFromInvariantString(elementNode.Attributes["Opacity"].Value).ToString(), out tempDouble))
                    uiElement.Opacity = tempDouble;
            }

            if (elementNode.HasAttribute("Width"))
            {
                double tempDouble;
                if (double.TryParse(doubleConverter.ConvertFromInvariantString(elementNode.Attributes["Width"].Value).ToString(), out tempDouble))
                    uiElement.Width = tempDouble;
            }

            if (elementNode.HasAttribute("Height"))
            {
                double tempDouble;
                if (double.TryParse(doubleConverter.ConvertFromInvariantString(elementNode.Attributes["Height"].Value).ToString(), out tempDouble))
                    uiElement.Height = tempDouble;
            }

            if (elementNode.HasAttribute("MinHeight"))
            {
                double tempDouble;
                if (double.TryParse(doubleConverter.ConvertFromInvariantString(elementNode.Attributes["MinHeight"].Value).ToString(), out tempDouble))
                    uiElement.MinHeight = tempDouble;
            }

            if (elementNode.HasAttribute("MinWidth"))
            {
                double tempDouble;
                if (double.TryParse(doubleConverter.ConvertFromInvariantString(elementNode.Attributes["MinWidth"].Value).ToString(), out tempDouble))
                    uiElement.MinWidth = tempDouble;
            }

            if (elementNode.HasAttribute("MaxWidth"))
            {
                double tempDouble;
                if (double.TryParse(doubleConverter.ConvertFromInvariantString(elementNode.Attributes["MaxWidth"].Value).ToString(), out tempDouble))
                    uiElement.MaxWidth = tempDouble;
            }

            if (elementNode.HasAttribute("MaxHeight"))
            {
                double tempDouble;
                if (double.TryParse(doubleConverter.ConvertFromInvariantString(elementNode.Attributes["MaxHeight"].Value).ToString(), out tempDouble))
                    uiElement.MaxHeight = tempDouble;
            }

            #endregion

            #region Dependency Properties
            foreach (FieldInfo field in typeof(ExternalProperties).GetFields())
            {
                if (object.ReferenceEquals(field.FieldType, typeof(DependencyProperty)))
                {
                    DependencyProperty protperty = (DependencyProperty)field.GetValue(null);
                    TypeConverter converter = TypeDescriptor.GetConverter(protperty.PropertyType);
                    if (elementNode.HasAttribute(protperty.Name))
                    {
                        uiElement.SetValue(protperty, converter.ConvertFrom(elementNode.Attributes[protperty.Name].Value));
                    }
                    else
                    {
                        uiElement.SetValue(protperty, protperty.DefaultMetadata.DefaultValue);
                    }
                }
            }
            #endregion
        }

        public XmlNode ToXml()
        {
            XmlDocument xmlDocument = new XmlDocument();
            XmlElement xmlElement = xmlDocument.CreateElement("Layout");
            xmlDocument.AppendChild(xmlElement);

            xmlElement.SetAttribute("Name", this.Name);
            xmlElement.SetAttribute("ImagePath", this.ImagePath);
            xmlElement.SetAttribute("Width", new DoubleConverter().ConvertToInvariantString(this.Width.ToString()));
            xmlElement.SetAttribute("Height", new DoubleConverter().ConvertToInvariantString(this.Height));
            xmlElement.SetAttribute("IsDefault", this.IsDefault.ToString());
            xmlElement.SetAttribute("ResolutionWidth", new DoubleConverter().ConvertToInvariantString(this.ResolutionWidth));
            xmlElement.SetAttribute("ResolutionHeight", new DoubleConverter().ConvertToInvariantString(this.ResolutionHeight));
            xmlElement.SetAttribute("Left", this.Left.ToString());
            xmlElement.SetAttribute("Top", this.Top.ToString());
            
            XmlElement UserControlsElement = xmlDocument.CreateElement("UserControls");
            foreach (FrameworkElement uiElement in this.Configuration.UserControls)
            {
                XmlNode ElementXml = this.ToXml(uiElement);
                XmlNode ImportNode = xmlDocument.ImportNode(ElementXml, true);
                UserControlsElement.AppendChild(ImportNode);
            }

            xmlDocument.SelectSingleNode("Layout").AppendChild(UserControlsElement);
            return xmlDocument.FirstChild;
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
            this.Xml = this.ToXml();
            this.IsInitialized = false;
        }      

        #endregion
    }
}
