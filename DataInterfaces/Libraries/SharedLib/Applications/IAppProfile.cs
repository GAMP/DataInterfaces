using System;
namespace SharedLib.Applications
{
    public interface IAppProfile
    {
        string Name { get; set; }
        System.Collections.Generic.HashSet<int> Profiles { get; set; }
        int Id { get; }
    }
}
