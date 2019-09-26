using System;

namespace ServerService
{
    /// <summary>
    /// License management service.
    /// </summary>
    /// <remarks>
    /// Implemented by Gizmo server.
    /// </remarks>
    public interface ILicenseManagmentService
    {
        #region EVENTS
        /// <summary>
        /// Occours on license reservation change.
        /// </summary>
        event EventHandler<LicenseReservationEventArgs> LicenseReservationChange;
        #endregion
    }
}
