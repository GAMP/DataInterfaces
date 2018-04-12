using CoreLib.Threading;

namespace CyClone.Core
{
    public delegate void MappingsConfigurationChangedDelegate(object sender, MappingsEventArgs e);
    public delegate void FileChangedDelegate(object sender, IcyFileSystemInfo file);
    public delegate void CollectStrucutreInfoDelegate(IcyDirectoryInfo source, FileInfoLevel infoLevel, int hashBlockSize, HashType hashType, bool recursive, IAbortHandle abortHandle);
    public delegate IcyDiffList CompareStrucutreDelegate(IcyDirectoryInfo destination, FileInfoLevel infoLevel, IAbortHandle abortHandle);
}

namespace CyClone.Security
{
    public delegate void VerifyAccessDelegate(object sender, VerifyAccessEventArgs e);
}