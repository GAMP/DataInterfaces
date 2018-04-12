using System;
namespace CoreLib.Threading
{
    public interface IAbortHandle
    {
        /// <summary>
        /// Aborts.
        /// </summary>
        void Abort();
        
        /// <summary>
        /// Aborts and waits untill abort is complete.
        /// </summary>
        void AbortWait();
        
        /// <summary>
        /// Aborts and waits for specified amount of time.
        /// </summary>
        /// <param name="miliSeconds"></param>
        void AbortWait(int miliSeconds);

        /// <summary>
        /// Gets or sets the async result.
        /// </summary>
        IAsyncResult AsyncResult { get; set; }
        
        /// <summary>
        /// Gets the instance of internal delegate.
        /// </summary>
        MulticastDelegate Delegate { get; }
        
        /// <summary>
        /// Gets if the operation was previously marked aborted.
        /// </summary>
        bool IsAborted { get; }
    }
}
