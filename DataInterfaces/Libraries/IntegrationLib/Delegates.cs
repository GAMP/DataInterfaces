using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Client;

namespace IntegrationLib
{
    /// <summary>
    /// Occours when availability changes.
    /// </summary>
    /// <param name="sender">Object sender.</param>
    /// <param name="args">Event arguments.</param>
    public delegate void AvailabilityChangedDelegate(object sender, AvailabilityEventArgs args);

    /// <summary>
    /// Occours when login state changes.
    /// </summary>
    /// <param name="sender">Object sender.</param>
    /// <param name="args">Event arguments.</param>
    public delegate void LoginStateChanagedDelegate(object sender, UserEventArgs args);    
}
