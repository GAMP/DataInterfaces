namespace CyClone.Core
{
    public interface IcyDiffList
    {
        #region PROPERTIES
        
        /// <summary>
        /// Gets extra entries.
        /// </summary>
        System.Collections.Generic.List<IcyFileSystemInfo> Extras { get; }

        /// <summary>
        /// Get total difference length for specified file.
        /// </summary>
        /// <param name="fileId"></param>
        /// <returns></returns>
        long GetDiffLength(int fileId);

        /// <summary>
        /// Gets hashes difference list.
        /// </summary>
        System.Collections.Generic.SortedList<int, System.Collections.Generic.SortedList<long, byte[]>> HashDiffList { get; }

        /// <summary>
        /// Gets lengths.
        /// </summary>
        System.Collections.Generic.Dictionary<int, long> Lengths { get; } 

        #endregion
    }
}
