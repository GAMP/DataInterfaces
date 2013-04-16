using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetLib
{
    /// <summary>
    /// Defines Wake Up packet types.
    /// </summary>
    /// <remarks></remarks>
    public enum WakePacketType
    {
        All = 0,
        MagicPacket = 1,
        Normal = 2
    }
}
