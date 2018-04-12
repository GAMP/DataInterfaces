using SharedLib;
using SharedLib.Views;
using System;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Threading;
using System.Threading.Tasks;

namespace Client
{
    /// <summary>
    /// Base module class.
    /// </summary>
    public abstract class ClientModuleBase : PropertyChangedBase,
        IPartImportsSatisfiedNotification
    {
        #region FIELDS
        private IClient client;
        #endregion

        #region IMPORTS

        /// <summary>
        /// Gets client instance.
        /// </summary>
        [Import()]
        public IClient Client
        {
            get { return this.client; }
            private set { this.SetProperty(ref this.client, value); }
        }

        [Import(AllowDefault = true)]
        public virtual IDialogService DialogService
        {
            get; protected set;
        }

        #endregion

        #region IPartImportsSatisfiedNotification
        public virtual void OnImportsSatisfied()
        {
        }
        #endregion
    }

    /// <summary>
    /// Module supporting switching in and out.
    /// </summary>
    public abstract class ClientSwitchInModule : ClientModuleBase, IClientSwitchInModule
    {
        #region FUNCTIONS

        /// <summary>
        /// Called once we switch to this module.
        /// </summary>
        /// <returns>
        /// Associated task.
        /// </returns>
        public virtual Task SwitchInAsync(CancellationToken ct)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// Called once we switching out of this module.
        /// </summary>
        /// <returns>
        /// Associated task.
        /// </returns>
        public virtual Task SwitchOutAsync(CancellationToken ct)
        {
            return Task.CompletedTask;
        }

        #endregion
    }

    /// <summary>
    /// Section module.
    /// </summary>
    [PartNotDiscoverable()]
    public abstract class ClientSectionModuleBase : ClientSwitchInModule, IClientSectionModule
    {
        #region FIELDS
        private IView view;
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets view.
        /// </summary>
        public virtual IView View
        {
            get { return this.view; }
            protected set { this.SetProperty(ref this.view, value); }
        }

        #endregion
    }

    /// <summary>
    /// User settings module.
    /// </summary>
    [PartNotDiscoverable()]
    public abstract class ClientUserSettingsModuleBase : ClientSwitchInModule, IClientUserSettingsModule
    {
        #region FIELDS
        private IView view;
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets view.
        /// </summary>
        public virtual IView View
        {
            get { return this.view; }
            protected set { this.SetProperty(ref this.view, value); }
        }

        #endregion
    }

    #region EXPORT ATTRIBUTES

    [MetadataAttribute(), AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ModuleDescriptionAttribute : Attribute
    {
        #region CONSTRUCTOR

        public ModuleDescriptionAttribute(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentNullException(nameof(title));

            this.Title = title;
        }

        public ModuleDescriptionAttribute(string title, string description) : this(title)
        { }

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets display title.
        /// </summary>
        public string Title
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets display description.
        /// </summary>
        public string Description
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets if description and title represented by localization keys.
        /// </summary>
        public bool IsLocalized
        {
            get; set;
        }

        #endregion
    }

    /// <summary>
    /// Used tot add material design icon to module.
    /// </summary>
    [MetadataAttribute(),AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ModuleIconAttribute : Attribute
    {
        #region CONSTRUCTOR

        public ModuleIconAttribute(string iconResource)
        {
            if (string.IsNullOrWhiteSpace(iconResource))
                throw new ArgumentNullException(nameof(iconResource));

            this.IconResource = iconResource;
        } 

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets icon resource.
        /// </summary>
        public string IconResource
        {
            get;
            private set;
        }

        #endregion
    }

    /// <summary>
    /// Display order attribute.
    /// </summary>
    [MetadataAttribute(), AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ModuleDisplayOrderAttribute : Attribute
    {
        #region CONSTRUCTOR
        public ModuleDisplayOrderAttribute(int order)
        {
            this.DiaplayOrder = order;
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets display order.
        /// </summary>
        public int DiaplayOrder
        {
            get;
            private set;
        }

        #endregion
    }

    [MetadataAttribute(),AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ModuleGuidAttribute : Attribute
    {
        #region CONSTRUCTOR

        public ModuleGuidAttribute(string guid)
        {
            if (string.IsNullOrWhiteSpace(guid))
                throw new ArgumentNullException(nameof(guid));

            this.Guid = guid;
        }

        #endregion

        #region PROPERTIES
        
        /// <summary>
        /// Gets guid.
        /// </summary>
        public string Guid
        {
            get;
            private set;
        } 

        #endregion
    }

    #endregion

    #region ICLIENTSKINMODULEMETADATA
    public interface IClientSkinModuleMetadata
    {
        #region PROPERTIES

        string Title { get; }

        string Description { get; }

        bool IsLocalized { get; }

        /// <summary>
        /// Gets module guid.
        /// </summary>
        string Guid { get; }

        /// <summary>
        /// Gets module display order.
        /// </summary>
        [DefaultValue(0)]
        int DiaplayOrder { get; }

        /// <summary>
        /// Gets module icon resource.
        /// </summary>
        string IconResource { get; }

        #endregion
    } 
    #endregion
}
