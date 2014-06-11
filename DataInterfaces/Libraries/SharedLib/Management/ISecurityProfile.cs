using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharedLib.Management
{
    #region ISecurityProfile
    public interface ISecurityProfile
    {
        int Id { get; set; }
        int DisabledDrives { get; set; }
        string Name { get; set; }
        List<ISecurityPolicy> Policies { get; set; }
        List<IRestriction> Restrictions { get; set; }
    }
    #endregion
}
