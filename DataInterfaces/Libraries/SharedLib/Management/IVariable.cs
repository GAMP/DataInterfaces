using System;
namespace SharedLib.Management
{
    public interface IVariable
    {
        int ID { get; set; }
        string FullName { get; }
        string Name { get; set; }
        ModuleScopes Scope { get; set; }
        string Value { get; set; }
    }
}
