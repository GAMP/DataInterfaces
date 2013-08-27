using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharedLib;
using System.Collections.ObjectModel;
using System.Windows;
using System.Xml;
using System.IO;
using System.ComponentModel;
using SkinInterfaces;

namespace SkinLib
{
    #region UIConfiguration
    [Serializable()]
    public class UIConfiguration : PropertyChangedNotificator, IUIConfiguration
    {
        #region Constructor

        /// <summary>
        /// Creates a new configuration instance.
        /// </summary>
        public UIConfiguration()
        {
        }

        /// <summary>
        /// Creates a new configuration instance from given configuration file name.
        /// </summary>
        /// <param name="fileName"></param>
        /// <remarks></remarks>
        public UIConfiguration(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                throw new ArgumentNullException("FileName","Configuration file name may not be null or empty");            
            this.FileName = fileName;
        }

        #endregion

        #region Fileds
        private ObservableCollection<UIComponent> components;
        private ObservableCollection<FrameworkElement> userControls;
        private ObservableCollection<UILayout> layouts;
        private ObservableCollection<string> assemblies;
        [NonSerialized()]
        private ObservableCollection<Exception> erors;
        [NonSerialized()]
        private Dictionary<string, UIComponent> componentsDictionary;
        [NonSerialized()]
        private Dictionary<string, FrameworkElement> userControlsDictionary;
        [NonSerialized()]
        protected Dictionary<string, UILayout> layoutDictionary;
        private string mFileName;
        [NonSerialized()]
        private XmlNode mXmlRepresentation;
        private UIComponent 
            mainWindowComponent, 
            controlBoxComponent,
            taskBarComponenet, 
            applicationListComponent;
        #endregion

        #region Private Properties

        internal Dictionary<string, UIComponent> ComponentDictionary
        {
            get
            {
                if (this.componentsDictionary == null)
                    this.componentsDictionary = new Dictionary<string, UIComponent>();
                return this.componentsDictionary;
            }
        }

        internal Dictionary<string, FrameworkElement> UserControlDictionary
        {
            get
            {
                if (this.userControlsDictionary == null)
                    this.userControlsDictionary = new Dictionary<string, FrameworkElement>();
                return this.userControlsDictionary;
            }
        }
        
        #endregion

        #region Properties

        /// <summary>
        /// Gets the file name of the loaded configuration.
        /// </summary>
        public string FileName
        {
            get { return this.mFileName; }
            set
            {
                this.mFileName = value;
                this.RaisePropertyChanged("FileName");
            }
        }

        /// <summary>
        /// Gets or sets the list of the components present in this configuration.
        /// </summary>
        public ObservableCollection<UIComponent> Components
        {
            get
            {
                if (this.components == null)
                    this.components = new ObservableCollection<UIComponent>();
                return this.components;
            }
        }

        /// <summary>
        /// Gets or sets configurations user controls instances.
        /// </summary>
        public ObservableCollection<FrameworkElement> UserControls
        {
            get
            {
                if (this.userControls == null)
                    this.userControls = new ObservableCollection<FrameworkElement>();
                return this.userControls;
            }
        }

        /// <summary>
        /// Gets or sets a list of the layouts present in this configuration.
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public ObservableCollection<UILayout> Layouts
        {
            get
            {
                if (this.layouts == null)
                    this.layouts = new ObservableCollection<UILayout>();
                return this.layouts;
            }
        }

        /// <summary>
        /// Gets or sets the component that represents the main window.
        /// </summary>
        public UIComponent MainWindowComponent
        {
            get
            {
                if (this.mainWindowComponent == null)
                    this.mainWindowComponent = new UIComponent(this);
                return this.mainWindowComponent;
            }
            set
            {
                this.mainWindowComponent = value;
                this.RaisePropertyChanged("MainWindowComponent");
            }
        }

        /// <summary>
        /// Gets or sets the component that represents the control box.
        /// </summary>
        public UIComponent ControlBoxComponent
        {
            get
            {
                if (this.controlBoxComponent == null)
                    this.controlBoxComponent = new UIComponent(this);
                return this.controlBoxComponent;
            }
            set
            {
                this.controlBoxComponent = value;
                this.RaisePropertyChanged("ControlBoxComponent");
            }
        }

        /// <summary>
        /// Gets or sets the component that represents the task bar.
        /// </summary>
        public UIComponent TaskBarComponent
        {
            get
            {
                if (this.taskBarComponenet == null)
                    this.taskBarComponenet = new UIComponent(this);
                return this.taskBarComponenet;
            }
            set
            {
                this.taskBarComponenet = value;
                this.RaisePropertyChanged("TaskBarComponent");
            }
        }

        /// <summary>
        /// Gets or sets the component that represents the application list.
        /// </summary>
        public UIComponent ApplicationListComponent
        {
            get
            {
                if (this.applicationListComponent == null)
                    this.applicationListComponent = new UIComponent(this);
                return this.applicationListComponent;
            }
            set
            {
                this.applicationListComponent = value;
                this.RaisePropertyChanged("ApplicationListComponent");
            }
        }

        /// <summary>
        /// Gets or sets XML Node representing the class.
        /// </summary>
        public XmlNode XmlRepresentation
        {
            get { return this.mXmlRepresentation; }
            set
            {
                this.mXmlRepresentation = value;
                this.RaisePropertyChanged("XmlRepresentation");
            }
        }

        /// <summary>
        /// Gets the list of the assemblies assigned to this configuration.
        /// </summary>
        public ObservableCollection<string> Assemblies
        {
            get
            {
                if (this.assemblies == null)
                    this.assemblies = new ObservableCollection<string>();
                return this.assemblies;
            }
        }

        /// <summary>
        /// Gets or sets the errors in the current configuration.
        /// </summary>
        public ObservableCollection<Exception> Errors
        {
            get
            {
                if (this.erors == null)
                    this.erors = new ObservableCollection<Exception>();
                return this.erors;
            }
        }

        /// <summary>
        /// When ovveriden responsible of loading main ui modules.
        /// </summary>
        /// <param name="ModulesNode">Node containing main modules</param>
        protected virtual void LoadModules(XmlNode ModulesNode)
        {
        }

        #endregion

        #region Loading Functions

        public void Load()
        {
            XmlDocument XmlDocument = new XmlDocument();
            XmlDocument.Load(this.FileName);
            this.XmlRepresentation = XmlDocument;

            #region COMPONENTS
            //Check if configuration node exists
            XmlNode ComponentsNode = XmlDocument.SelectSingleNode("Configuration/Components");
            if ((ComponentsNode != null))
            {
                this.LoadComponents(ComponentsNode);
            }
            else
            {
                throw new Exception("Components XML node not found!");
            }
            #endregion

            #region LAYOUTS
            XmlNode LayoutsNode = XmlDocument.SelectSingleNode("Configuration/Layouts");
            if ((LayoutsNode != null))
            {
                this.LoadLayouts(LayoutsNode);
            }
            else
            {
                throw new Exception("Layout XML node not found!");
            }
            #endregion

            #region MAINWINDOW
            XmlElement MainWindow = (XmlElement)XmlDocument.SelectSingleNode("Configuration/Components/Modules/MainWindow");
            if ((MainWindow != null))
            {
                UIComponent Componenet = this.LoadComponenet(MainWindow);
                this.MainWindowComponent = Componenet;
            }
            else
            {
                throw new Exception("Main Window XML node not found!");
            }
            #endregion

            #region CONTROLBOX
            XmlElement ControlBox = (XmlElement)XmlDocument.SelectSingleNode("Configuration/Components/Modules/ControlBox");
            if ((ControlBox != null))
            {
                UIComponent Componenet = this.LoadComponenet(ControlBox);
                this.ControlBoxComponent = Componenet;
            }
            else
            {
                throw new Exception("Control Box XML node not found!");
            }
            #endregion

            #region TASKBAR
            XmlElement TaskBarNode = (XmlElement)XmlDocument.SelectSingleNode("Configuration/Components/Modules/TaskBar");
            if ((TaskBarNode != null))
            {
                UIComponent Componenet = this.LoadComponenet(TaskBarNode);
                this.TaskBarComponent = Componenet;
                this.InternalAdd(Componenet);
            }
            else
            {
                throw new Exception("TaskBar XML node not found!");
            }
            #endregion

            #region APPLIST
            XmlElement AppListNode = (XmlElement)XmlDocument.SelectSingleNode("Configuration/Components/Modules/ApplicationsList");
            if ((AppListNode != null))
            {
                UIComponent Componenet = this.LoadComponenet(AppListNode);
                this.ApplicationListComponent = Componenet;
                this.InternalAdd(Componenet);
            }
            else
            {
                throw new Exception("Application List XML node not found!");
            }
            #endregion

            #region ASSEMBLIES
            XmlNode AssembliesNode = XmlDocument.SelectSingleNode("Configuration/Assemblies");
            if ((LayoutsNode != null))
            {
                this.LoadAssemblies(AssembliesNode);
            }
            else
            {
                throw new Exception("Assemblies XML node not found!");
            }
            #endregion

            this.LoadModules(XmlDocument.SelectSingleNode("Configuration/Components/Modules"));
        }

        /// <summary>
        /// Loads the compoenents from given xml node.
        /// </summary>
        /// <param name="ComponentsNode"></param>
        private void LoadComponents(XmlNode ComponentsNode)
        {
            this.ComponentDictionary.Clear();
            this.Components.Clear();
            foreach (XmlElement node in ComponentsNode.ChildNodes)
            {
                try
                {
                    if (node.Name != "Modules")
                    {
                        UIComponent Component = new UIComponent(this);
                        Component.AssemblyName = node.Attributes["Assembly"].Value;
                        Component.Type = node.Attributes["Type"].Value;
                        Component.GUID = node.Attributes["GUID"].Value;

                        if (node.HasAttribute("Title"))
                            Component.Title = node.Attributes["Title"].Value;
                        if (node.HasAttribute("Description"))
                            Component.Description = node.Attributes["Description"].Value;

                        this.ComponentDictionary.Add(Component.GUID, Component);
                        this.Components.Add(Component);
                    }
                }
                catch
                {
                    //Log failed component loading
                    continue;
                }
            }
        }

        private void InternalAdd(UIComponent Componenet)
        {
            this.ComponentDictionary.Add(Componenet.GUID, Componenet);
            this.Components.Add(Componenet);
        }

        /// <summary>
        /// Loads UIComponent from specified node.
        /// </summary>
        public UIComponent LoadComponenet(XmlElement ComponentNode)
        {
            UIComponent Component = new UIComponent(this);
            Component.AssemblyName = ComponentNode.Attributes["Assembly"].Value;
            Component.Type = ComponentNode.Attributes["Type"].Value;
            Component.GUID = ComponentNode.Attributes["GUID"].Value;

            if (ComponentNode.HasAttribute("Title"))
                Component.Title = ComponentNode.Attributes["Title"].Value;
           
            if (ComponentNode.HasAttribute("Description"))
                Component.Description = ComponentNode.Attributes["Description"].Value;
            
            return Component;
        }

        /// <summary>
        /// Loads the layouts from the XML node.
        /// </summary>
        private void LoadLayouts(XmlNode LayoutsNode)
        {
            this.Layouts.Clear();
            foreach (XmlNode layoutNode in LayoutsNode.ChildNodes)
            {
                //Create new configuration class                
                UILayout layout = new UILayout(this);

                //set xml
                layout.XmlRepresentation = layoutNode;

                //Populate the class with xml data
                layout.Height = (double)new DoubleConverter().ConvertFromInvariantString(layoutNode.Attributes["Height"].Value);
                layout.Width = (double)new DoubleConverter().ConvertFromInvariantString(layoutNode.Attributes["Width"].Value);
                layout.IsDefault = bool.Parse(layoutNode.Attributes["IsDefault"].Value);
                layout.Left = int.Parse(layoutNode.Attributes["Left"].Value);
                layout.Top = int.Parse(layoutNode.Attributes["Top"].Value.ToString());
                layout.Name = layoutNode.Attributes["Name"].Value.ToString();
                layout.ResolutionWidth = int.Parse(layoutNode.Attributes["ResolutionWidth"].Value);
                layout.ResolutionHeight = int.Parse(layoutNode.Attributes["ResolutionHeight"].Value);
                layout.ImagePath = layoutNode.Attributes["ImagePath"].Value.ToString();

                //Set default name
                if (layout.Name == string.Empty)
                    layout.Name = "Configuration : " + this.Layouts.Count;

                this.Layouts.Add(layout);
            }
        }

        /// <summary>
        /// Load the assemblies File Names from the configuration file.
        /// </summary>
        private void LoadAssemblies(XmlNode AssembliesNode)
        {
            this.Assemblies.Clear();
            foreach (XmlElement AssemblyElement in AssembliesNode.ChildNodes)
            {
                if ((AssemblyElement.HasAttribute("FileName")))
                {
                    string AssemblyFileName = AssemblyElement.Attributes["FileName"].Value;
                    this.Assemblies.Add(AssemblyFileName);
                }
            }
        }

        /// <summary>
        /// Saves the configuration to default file.
        /// </summary>
        public void Save()
        {
            this.Save(this.FileName);
        }

        /// <summary>
        /// Saves the configuration to specified file.
        /// </summary>
        /// <param name="FileName">Configuration file name.</param>
        /// <remarks></remarks>
        public void Save(string FileName)
        {
            #region Create New XML Document
            XmlDocument xmlDocument = new XmlDocument();
            //create declaration node
            xmlDocument.CreateNode(XmlNodeType.XmlDeclaration, "", "");
            //create root node
            XmlElement root = xmlDocument.CreateElement("Configuration");
            //set root attributes
            root.SetAttribute("Version", System.Windows.Forms.Application.ProductVersion);
            #endregion

            #region Add base nodes
            //create components node
            XmlNode componentsNode = xmlDocument.CreateElement("Components");

            //create assemblies node
            XmlNode assembliesNode = xmlDocument.CreateElement("Assemblies");

            //create layouts node
            XmlNode layoutsNode = xmlDocument.CreateElement("Layouts");
            #endregion

            #region Add Shell modules nodes
            XmlElement MainWindowNode = xmlDocument.CreateElement("Components/Modules/MainWindow");
            XmlElement ControlBox = xmlDocument.CreateElement("Components/Modules/ControlBox");
            XmlElement TaskBar = xmlDocument.CreateElement("Components/Modules/TaskBar");
            XmlElement AppList = xmlDocument.CreateElement("Components/Modules/ApplicationsList");
            #endregion

            #region Set components attributes
            foreach (UIComponent skinComponent in this.Components)
            {
                XmlElement componentNode = xmlDocument.CreateElement(skinComponent.Type);
                componentNode.SetAttribute("GUID", skinComponent.GUID);
                componentNode.SetAttribute("Type", skinComponent.Type);
                componentNode.SetAttribute("Assembly", skinComponent.AssemblyName);
                componentNode.SetAttribute("Title", skinComponent.Title);
                componentNode.SetAttribute("Description", skinComponent.Description);
                componentsNode.AppendChild(componentNode);
            }
            #endregion

            #region Add current layouts
            foreach (UILayout layout in this.Layouts)
            {
                if (layout.IsInitialized)
                    layout.Accept();               
                XmlNode ImportedNode = xmlDocument.ImportNode(layout.XmlRepresentation, true);
                layoutsNode.AppendChild(ImportedNode);
            }
            #endregion

            #region Set Main Modules Attributes
            MainWindowNode.SetAttribute("GUID", this.MainWindowComponent.GUID);
            MainWindowNode.SetAttribute("Assembly", this.MainWindowComponent.AssemblyName);
            MainWindowNode.SetAttribute("Type", this.MainWindowComponent.Type);
            ControlBox.SetAttribute("GUID", this.ControlBoxComponent.GUID);
            ControlBox.SetAttribute("Assembly", this.ControlBoxComponent.AssemblyName);
            ControlBox.SetAttribute("Type", this.ControlBoxComponent.Type);
            TaskBar.SetAttribute("GUID", this.TaskBarComponent.GUID);
            TaskBar.SetAttribute("Assembly", this.TaskBarComponent.AssemblyName);
            TaskBar.SetAttribute("Type", this.TaskBarComponent.Type);
            AppList.SetAttribute("GUID", this.ApplicationListComponent.GUID);
            AppList.SetAttribute("Assembly", this.ApplicationListComponent.AssemblyName);
            AppList.SetAttribute("Type", this.ApplicationListComponent.Type);
            #endregion

            #region Add Assemblies
            foreach (string Assembly in this.Assemblies)
            {
                XmlElement AssemblyNode = xmlDocument.CreateElement("Assembly");
                AssemblyNode.SetAttribute("FileName", Assembly);
                assembliesNode.AppendChild(AssemblyNode);
            }
            #endregion

            #region Append Nodes
            root.AppendChild(componentsNode);
            root.AppendChild(layoutsNode);
            root.AppendChild(MainWindowNode);
            root.AppendChild(assembliesNode);
            xmlDocument.AppendChild(root);
            #endregion

            #region Save document
            xmlDocument.Save(FileName);
            #endregion
        }

        /// <summary>
        /// Checks if specified string is valid GUID.
        /// </summary>
        /// <param name="GUIDString"></param>
        /// <returns></returns>
        public bool IsValidGUID(string GUIDString)
        {
            Guid temp;
            return !String.IsNullOrWhiteSpace(GUIDString) && Guid.TryParse(GUIDString, out temp);
        }

        /// <summary>
        /// Checks if the given component GUID exists in this configuration.
        /// </summary>
        public bool HasComponent(string guid)
        {
            return this.ComponentDictionary.ContainsKey(guid);
        }

        /// <summary>
        /// Checks if configuration contains specified assembly file.
        /// </summary>
        /// <param name="FileName"></param>
        /// <returns></returns>
        public bool HasAssembly(string FileName)
        {
            foreach (string AssemblyFile in this.Assemblies)
                if (string.Compare(AssemblyFile, FileName, true) == 0)
                    return true;
            return false;
        }

        public void Instanate()
        {
            this.UserControlDictionary.Clear();
            this.UserControls.Clear();
            foreach (UIComponent Component in this.Components)
            {
                try
                {
                    FrameworkElement Instance = (FrameworkElement)UIHandler.Current.CreateInstance(Component);
                    if ((Instance != null) & !(Component.GUID == this.MainWindowComponent.GUID))
                    {
                        this.UserControlDictionary.Add(Component.GUID, Instance);
                        this.UserControls.Add(Instance);
                    }
                }
                catch
                {
                    continue;
                }
            }
        }

        public void AddComponent(UIComponent Component)
        {
            if (Component != null)
            {
                this.ComponentDictionary.Add(Component.GUID, Component);
                this.Components.Add(Component);
                this.UserControlDictionary.Add(Component.GUID, Component.Instance);
                this.UserControls.Add(Component.Instance);
            }
        }

        public void RemoveComonent(UIComponent Component)
        {
            if (Component != null)
            {
                if (this.ComponentDictionary.ContainsKey(Component.GUID))
                {
                    this.ComponentDictionary.Remove(Component.GUID);
                    this.Components.Remove(Component);
                    this.UserControlDictionary.Remove(Component.GUID);
                    this.UserControls.Remove(Component.Instance);
                }
            }
        }

        public void RemoveComponent(string ComponentGUID)
        {
            if (this.ComponentDictionary.ContainsKey(ComponentGUID))
            {
                UIComponent component = this.ComponentDictionary[ComponentGUID];
                this.RemoveComonent(component);
            }
        }

        #endregion
    }
    #endregion

    #region UIConfigurationChild
    public abstract class UIConfigurationChild : PropertyChangedNotificator
    {
        #region Constructor
        public UIConfigurationChild(UIConfiguration config)
        {
            if (config == null)
                throw new ArgumentNullException("Config", "Configuration instance may not be null");
            this.Configuration = config;
        }
        #endregion

        #region Fields
        private UIConfiguration configuration;
        #endregion

        #region Properties

        /// <summary>
        /// Gets the parent configuration of this layout.
        /// </summary>
        public UIConfiguration Configuration
        {
            get { return this.configuration; }
            protected set
            {
                this.configuration = value;
                this.RaisePropertyChanged("Configuration");
            }
        }
        #endregion
    } 
    #endregion
}
