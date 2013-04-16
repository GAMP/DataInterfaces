using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CyClone.Core
{
    public interface IcyMapping
    {
        bool IsMounted { get; }
        void Mount();
        void Unmount();
        void Unmount(bool force);
    }
}
