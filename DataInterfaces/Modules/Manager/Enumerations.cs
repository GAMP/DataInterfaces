using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Manager
{
    public enum KnownMenuRoot
    {
        Manager,
        Statistics,
        Help,
        Tools,
        View
    }

    /// <summary>
    /// Menu area enumeration.
    /// </summary>
    public enum MenuArea
    {
        Unset,
        Main,
        Quick,
        Hosts,
        Users,
        Log,
    }    
}
