using System;
using CyClone.Core;

namespace CyClone.Core
{
    #region IcySync
    public interface IcySync
    {
        IcyFileSystemInfo CurrentFile { get; }
        long CurrentOffset { get; }
        event ErrorEventDelegate Error;
        event FileChangedDelegate FileChanged;
        int ReadBufferSize { get; set; }
        long TotalWritten { get; }
        int WriteBufferSize { get; set; }
    } 
    #endregion
}
