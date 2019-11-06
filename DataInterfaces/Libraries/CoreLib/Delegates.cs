using CoreLib.Diagnostics;

namespace CoreLib
{
    /// <summary>
    /// Process event delegate.
    /// </summary>
    /// <param name="sender">Sender.</param>
    /// <param name="process">Args.</param>
    public delegate void ProcessEventDelegate(object sender, ICoreProcess process);

    /// <summary>
    /// Exception event delegate.
    /// </summary>
    /// <param name="sender">Sender.</param>
    /// <param name="args">Args.</param>
    public delegate void ExceptionEventDelegate(object sender, ExceptionEventArgs args); 
}
