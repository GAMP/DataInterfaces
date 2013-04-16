using System;
namespace CyClone.Core
{
    public interface IcyAction
    {
        bool IsSucessfull { get; }
        Exception LastError { get; }
        System.Threading.ManualResetEvent ResetEvent { get; }
    }
  
}
