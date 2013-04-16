using System;
using System.IO;

namespace CyClone.Core
{
    public interface IcyHandleInfo
    {
        SharedLib.Dispatcher.IMessageDispatcher Dispatcher { get; }
        string FullName { get; }
        Microsoft.Win32.SafeHandles.SafeFileHandle SafeHandle { get; }
        FileStream FileStream { get; }
        int SystemPointer
        {
            get;
        }
        bool IsClosed
        {
            get;
        }
        void Close();
    }
}
