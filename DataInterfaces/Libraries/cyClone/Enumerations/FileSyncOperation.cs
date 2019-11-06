using System;

namespace CyClone
{
    /// <summary>
    /// File sync operation types.
    /// </summary>
    [Flags()]
    public enum FileSyncOperation
    {
        /// <summary>
        /// No error occurred.
        /// </summary>
        None = 0,
        /// <summary>
        /// Could not set file attributes.
        /// </summary>
        Attributes = 1,
        /// <summary>
        /// Could not set length.
        /// </summary>
        Length = 2,
        /// <summary>
        /// Could not sync streams content.
        /// </summary>
        ContentSynchronization = 4,
        /// <summary>
        /// Could not open source stream.
        /// </summary>
        SourceOpen = 8,
        /// <summary>
        /// Could not open destination stream.
        /// </summary>
        DestinationOpen = 16,
        /// <summary>
        /// Could not delete incomplete file.
        /// </summary>
        IncompleteFileDelete = 32,
        /// <summary>
        /// Source stream could not be closed.
        /// </summary>
        SourceStreamClose = 64,
        /// <summary>
        /// Destination stream could not be closed.
        /// </summary>
        DestinationStreamClose = 128,
    }
}
