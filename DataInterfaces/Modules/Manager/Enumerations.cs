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

    #region MenuArea
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
    #endregion
}
