using System;


namespace SharedLib.Applications
{
    public interface IPersonalUserFile:IHasVisualOptions
    {
        int ID { get; set; }
        ActivationType ActivationType { get; set; }
        System.Collections.ObjectModel.ObservableCollection<int> AllowedGroups { get; set; }
        bool CleanUp { get; set; }
        int CompressionLevel { get; set; }
        ActivationType DeactivationType { get; set; }
        bool IncludeSubDirectories { get; set; }
        bool IsStorable { get; set; }
        long MaxQuota { get; set; }
        string Name { get; set; }
        string SourcePath { get; set; }
    }

    public class PUFEventArgs : BaseEventArgs
    {
        #region Fileds
        private ActionCodes type;
        private IPersonalUserFile profile;
        private Exception exception;
        private PufActionType actionType;
        #endregion

        #region Properties
        public IPersonalUserFile Profile
        {
            get { return this.profile; }
            protected set { this.profile = value; }
        }
        public Exception Exception
        {
            get { return this.exception; }
            protected set
            {
                this.exception = value;
            }
        }
        public ActionCodes Event
        {
            get { return this.type; }
            protected set { this.type = value; }
        }
        public PufActionType ActionType
        {
            get { return this.actionType; }
            set { this.actionType = value; }
        }
        #endregion

        #region Constructor
        public PUFEventArgs(IPersonalUserFile profile,
            ActionCodes type, PufActionType actionType,
            Exception error = null)
        {
            this.Profile = profile;
            this.Event = type;
            this.ActionType = actionType;
            this.Exception = error;
        } 
        #endregion
    }
}
