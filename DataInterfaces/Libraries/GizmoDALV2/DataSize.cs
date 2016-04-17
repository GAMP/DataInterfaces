using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GizmoDALV2
{
    #region SQLStringSize
    public static class SQLStringSize
    {
        public static readonly int TINY45 = 45;
        public static readonly int TINY = 255;
        public static readonly int NORMAL = 65535;
        public static readonly int MEDIUM = 16777215;
        public static readonly int MAX = int.MaxValue;
    } 
    #endregion

    #region SQLByteArraySize
    public static class SQLByteArraySize
    {
        public static int TINY = 255;
        public static int NORMAL = 65535;
        public static int MEDIUM = 16777215;
        public static int MAX = int.MaxValue;
    } 
    #endregion
}
