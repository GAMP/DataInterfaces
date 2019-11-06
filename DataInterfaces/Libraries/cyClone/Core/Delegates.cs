using CoreLib.Threading;

namespace CyClone.Core
{
    /// <summary>
    /// Compare structure delegate.
    /// </summary>
    /// <param name="destination">Destination.</param>
    /// <param name="infoLevel">Info level.</param>
    /// <param name="abortHandle">Abort handle.</param>
    /// <returns>Difference list.</returns>
    public delegate IcyDiffList CompareStrucutreDelegate(IcyDirectoryInfo destination, FileInfoLevel infoLevel, IAbortHandle abortHandle);
}