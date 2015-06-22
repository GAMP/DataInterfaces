using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GizmoDALV2
{
    public interface IEntityEventArgs
    {
        EntityEventType Type
        {
            get;
        }

        Type EntityType
        {
            get;
        }
    }
}
