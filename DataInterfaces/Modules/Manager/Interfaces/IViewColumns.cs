using SharedLib.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Manager.Views
{
    /// <summary>
    /// View that exposes data grid columns.
    /// </summary>
    public interface IViewColumns : IView
    {
        /// <summary>
        /// Gets view column collection.
        /// </summary>
        ObservableCollection<DataGridColumn> Columns { get; }
    }


}
