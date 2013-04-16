using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Manager
{
    /// <summary>
    /// System manager interface.
    /// </summary>
    public interface ISystemManager
    {
        IManagerViewModel ViewModel
        {
            get;
            set;
        }
        ISystemManager Current
        {
            get;
            set;
        }
    }
}
