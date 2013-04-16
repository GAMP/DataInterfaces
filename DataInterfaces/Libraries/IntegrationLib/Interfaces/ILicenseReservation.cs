using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IntegrationLib
{
    #region ILicenseReservation
    public interface ILicenseReservation
    {
        global::System.Collections.Generic.Dictionary<int, global::IntegrationLib.IApplicationLicense> Licenses { get; }
        int Id { get; set; }
    }
    #endregion
}
