using ServerService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerService
{
    #region ILicenseManagmentService
    public interface ILicenseManagmentService
    {
        #region EVENTS
        /// <summary>
        /// Occours on license reservation change.
        /// </summary>
        event EventHandler<ReservationEventArgs> ReservationChange;
        #endregion
    }
    #endregion
}
