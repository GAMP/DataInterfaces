using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CyClone;

namespace SharedLib.Applications
{
    public interface IDeploymentProfile
    {
        string Destination { get; }
        string Source { get; }
        string Name { get; }
        Guid Guid { get; }
        FileInfoLevel ComparisonLevel { get; }
    }
}
