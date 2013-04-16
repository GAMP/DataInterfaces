using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using SharedLib;

namespace Client
{
    public delegate void LockStateChangedDelegate(object sender,LockStateEventArgs e);
    public delegate void ClientIdChangedDelegate(object sender,IdChangeEventArgs e);
    public delegate bool NotifyEventDelegate(ClientEventTypes type, EventArgs arguments);
    public delegate void SecurtyStateChangeDelegate(object sender,SecurityStateArgs e);
    public delegate void ExecutionContextStateChangedDelegate(object sender, ExecutionContextStateArgs e);
    public delegate void ExecutionContextCollectionEvent(object sender,CollectionChangeEventArgs e);
    public delegate void OutOfOrderStateChangeDelegate(object sender,OutOfOrderStateEventArgs e);
}
