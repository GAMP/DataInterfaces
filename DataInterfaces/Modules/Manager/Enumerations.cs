using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Manager
{
    #region KnownMenuRoot
    public enum KnownMenuRoot
    {
        Manager,
        Statistics,
        Help,
        Tools,
        View
    }
    #endregion

    #region KnownMenuArea
    /// <summary>
    /// Menu area enumeration.
    /// </summary>
    public enum KnownMenuArea
    {
        Main,
        Quick,
        Hosts,
        Users,
        Log,
    } 
    #endregion
}
