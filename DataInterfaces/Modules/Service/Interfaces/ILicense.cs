using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServerService
{
    public interface ILicense
    {
        int Count { get; }
        DateTime Expires { get; }
        string HardwareId { get; }
        bool HasValidLicenses { get; }
        bool HasValidTrialLicenses { get; }
        bool IsLocalExpired { get; }
        bool IsLocalTrialExpired { get; }
        bool IsServerExpired { get; }
        bool IsServerTrialExpired { get; }
        DateTime Issued { get; }
        bool Local { get; }
        int TotalCount { get; }
        int TrialCount { get; }
        DateTime TrialExpires { get; }  
    }
}
