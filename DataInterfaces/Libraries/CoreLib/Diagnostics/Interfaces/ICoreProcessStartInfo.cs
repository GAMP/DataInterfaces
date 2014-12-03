using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace CoreLib.Diagnostics
{
    #region ICoreProcessStartInfo
    public interface ICoreProcessStartInfo
    {
        string Arguments { get; set; }
        bool CreateNoWindow { get; set; }
        string FileName { get; set; }
        string Password { get; set; }
        string Username { get; set; }
        bool WaitForTermination { get; set; }
        string WorkingDirectory { get; set; }
        ProcessStartInfo ToStartInfo();
    }
    #endregion
}
