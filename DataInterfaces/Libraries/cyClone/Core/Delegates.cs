using CoreLib.Threading;

namespace CyClone.Core
{
    public delegate IcyDiffList CompareStrucutreDelegate(IcyDirectoryInfo destination, FileInfoLevel infoLevel, IAbortHandle abortHandle);
}