using System;

namespace CyClone.Core
{
    public interface IPatchBlock
    {
        long DataLength { get; set; }
        long DestinationOffset { get; set; }
        long SourceOffset { get; set; }
    }
}
