using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Data;

namespace SkinLib
{
    public interface IUIHandler
    {
        List<Assembly> SkinAssemblies
        {
            get;
        }

        IUILayout CurrentLayout
        {
            get;
            set;
        }

        UserControl ActiveControl
        {
            get;
        }

        UserControl MouseOverControl
        {
            get;
        }

        bool IsMultiScreen { get; set; }
    }
}
