using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharedLib.Applications
{
    public interface ITClonable
    {
        T Clone<T>(T item);
    }
}
