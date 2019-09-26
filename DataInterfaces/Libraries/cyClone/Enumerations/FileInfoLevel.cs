using System;

namespace CyClone
{
    /// <summary>
    /// Generic file operations option enumeration.
    /// </summary>
    /// <remarks></remarks>
    [Flags()]
    public enum FileInfoLevel
    {
        /// <summary>
        /// None Flag
        /// </summary>
        None = 0,
        /// <summary>
        /// Attributes Flag
        /// </summary>
        Attributes = 1,
        /// <summary>
        /// Security descriptors flags
        /// </summary>
        SecurityDescriptors = 2,
        /// <summary>
        ///Creation time flag
        /// </summary>
        /// <remarks></remarks>
        CreationTime = 4,
        /// <summary>
        /// Last write time flag
        /// </summary>
        LastWriteTime = 8,
        /// <summary>
        /// Last access flag
        /// </summary>
        LastAccessTime = 16,
        /// <summary>
        ///Directories Will Be Collected
        /// </summary>
        Directory = 32,
        /// <summary>
        ///Files Will Be Collected
        /// </summary>
        File = 64,
        /// <summary>
        /// MD5 Hash Flag
        /// </summary>
        Hash = 128,
        /// <summary>
        /// Length Will Be Collected
        /// </summary>
        Length = 256,
        /// <summary>
        /// Data Block Hashing Flag
        /// </summary>
        BlockHash = 512,
        /// <summary>
        /// Excluded Files Flag
        /// </summary>
        ExcludedFiles = 1024,
        /// <summary>
        /// Excluded Directories Flag
        /// </summary>
        /// <remarks></remarks>
        ExcludedDirectories = 2048,
        /// <summary>
        ///Flags Missing Entry.
        /// </summary>
        Missing = 4096,
        /// <summary>
        /// Flags an empty file.
        /// </summary>
        ZeroLength = 8192,
        /// <summary>
        /// Mirror flag.
        /// </summary>
        Mirror = 16384,
        /// <summary>
        /// Flags cleanup operations ignore.
        /// </summary>
        CleanIgnore = 32768,
        /// <summary>
        /// Flags a missing block.
        /// </summary> 
        BlockMissing = 65536,
        /// <summary>
        /// Flags a block difference.
        /// </summary>
        BlockDifference = 131072,
        /// <summary>
        /// Enables dynamic block comparison.
        /// </summary>
        DynamicBlockComparison = 262144,
        /// <summary>
        /// Enables recursive collection of extra files in extra subdirectories.
        /// </summary>
        RecurseExtraDirectories = 524288,
        /// <summary>
        /// Gnereic comparison flag.
        /// </summary>
        ComparisonBasic = LastWriteTime | Length | ComparisonSimple,
        /// <summary>
        /// Generic date time stamping flag.
        /// </summary>
        DateTimeStamps = LastWriteTime | LastAccessTime | CreationTime,
        /// <summary>
        /// Simple comparison mode.
        /// </summary>
        ComparisonSimple = Length | Attributes | File | Directory,
        /// <summary>
        /// Advanced comparison mode.
        /// </summary>
        ComparisonAdvanced = ComparisonBasic | Hash,
        /// <summary>
        /// Basic length collection flag.
        /// </summary>
        LengthBasic = Length | File | Directory,
        /// <summary>
        /// Basic comparison without attributes.
        /// </summary>
        ComparisonBasicNoAttributes = LengthBasic | LastWriteTime,
    }
}
