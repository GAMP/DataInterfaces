using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows;
using System.Collections.ObjectModel;

namespace SkinLib
{
    public  interface IUIConfiguration
    {
        ObservableCollection<FrameworkElement> UserControls
        {
            get;
        }
    }
}
