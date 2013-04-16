using System;
namespace CyClone.Core
{
    public interface IcyDiffList
    {
        System.Collections.Generic.List<CyClone.Core.IcyFileSystemInfo> Extras { get; }
        long GetDiffLength(int fileId);
        System.Collections.Generic.SortedList<int, System.Collections.Generic.SortedList<long, byte[]>> HashDiffList { get; }
        System.Collections.Generic.Dictionary<int, long> Lengths { get; }
    }
}
