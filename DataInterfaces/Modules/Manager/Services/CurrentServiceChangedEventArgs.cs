using SharedLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Manager.Services
{
    #region CurrentServiceChangedEventArgs
    public class CurrentServiceChangedEventArgs : SelectedChangeEventArgs<IGizmoService>
    {
        #region CONSTRUCTOR
        public CurrentServiceChangedEventArgs(IGizmoService current, IGizmoService previous)
        {
            this.Current = current;
            this.Previous = previous;
        }
        #endregion
    }
    #endregion    
}
