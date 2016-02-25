using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreLib;
using CoreLib.Threading;
using System.IO;

namespace CyClone.Core
{
    public delegate void MappingsConfigurationChangedDelegate(object sender, MappingsEventArgs e);    
    public delegate void FileChangedDelegate(object sender, IcyFileSystemInfo file);
    public delegate void CollectStrucutreInfoDelegate(IcyDirectoryInfo source,FileInfoLevel infoLevel,int hashBlockSize,HashType hashType,bool recursive, IAbortHandle abortHandle);
    public delegate IcyDiffList CompareStrucutreDelegate(IcyDirectoryInfo destination,FileInfoLevel infoLevel,IAbortHandle abortHandle);
}
