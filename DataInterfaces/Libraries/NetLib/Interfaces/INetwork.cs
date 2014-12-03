using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetLib;

namespace NetLib
{
    #region INetwork
    public interface INetwork
    {
        #region EVENTS
        event EventHandler<ConnectionChangedArgs> ConnectionChanged;
        #endregion

        #region PROPERTIES

        IConnection StreamConnection
        {
            get;
            set;
        }

        IConnection DataGramConnection
        {
            get;
            set;
        }
        
        #endregion
    } 
    #endregion
}
