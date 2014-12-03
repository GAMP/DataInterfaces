using SharedLib.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharedLib.Dispatcher
{
    #region Delegates
    public delegate void StateChangeDelegate(IOperation sender, OperationState state, params object[] param);
    public delegate void OperationUpdateDelegate(IOperation sender, params object[] param);
    #endregion
}
