using System;
using System.Collections.ObjectModel;


namespace SharedLib.Applications
{
    public interface IPersonalUserFile:IHasVisualOptions
    {
        int ID { get; set; }
        ActivationType ActivationType { get; set; }
        ActivationType DeactivationType { get; set; }
        ObservableCollection<int> AllowedGroups { get; set; }
        bool CleanUp { get; set; }
        int CompressionLevel { get; set; }  
        bool IncludeSubDirectories { get; set; }
        bool IsStorable { get; set; }
        long MaxQuota { get; set; }
        string Name { get; set; }
        string SourcePath { get; set; }
    }
}
