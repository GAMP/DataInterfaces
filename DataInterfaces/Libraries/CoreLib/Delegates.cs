using CoreLib.Diagnostics;

namespace CoreLib
{
    public delegate void ProcessEventDelegate(object sender, ICoreProcess process);
    public delegate void ExceptionEventDelegate(object sender, ExceptionEventArgs args); 
}
