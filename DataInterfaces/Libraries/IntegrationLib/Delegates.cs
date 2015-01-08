using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Client;

namespace IntegrationLib
{
    public delegate void AvailabilityChangedDelegate(object sender, AvailabilityEventArgs args);
    public delegate void LoginStateChanagedDelegate(object sender, UserEventArgs args);    
}
