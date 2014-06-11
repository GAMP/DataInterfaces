using SharedLib;
using System;

namespace NetLib
{
    public interface IHostInfo
    {
        int GroupId { get; set; }
        string IpAddress { get; set; }
        string HostName { get; set; }
        string MacAddress { get; set; }
        int Number { get; set; }
        bool Registered { get; set; }
        HostState State { get; }
        int Id { get; set; }
    }
}
