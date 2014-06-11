using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharedLib.Management
{
    #region IHostGroup
    public interface IHostGroup
    {
        int Id { get; set; }
        int ApplicationProfileId { get; set; }
        string Name { get; set; }
        int SecurityProfileId { get; set; }
        bool ShellEnabled { get; set; }
        string SkinName { get; set; }
    }
    #endregion
}
