using Client;
using System;

namespace IntegrationLib
{
    [Obsolete()]
    public delegate void AvailabilityChangedDelegate(object sender, AvailabilityEventArgs args);
    public delegate void LoginStateChanagedDelegate(object sender, UserEventArgs args);    
}
