using System.IO;

namespace CoreLib.Registry
{
    /// <summary>
    /// Registry file interfaces.
    /// </summary>
    public interface IRegistryFile
    {
        #region FUNCTIONS
        
        /// <summary>
        /// Imports from file.
        /// </summary>
        /// <param name="filename">File name.</param>
        void Import(string filename);

        /// <summary>
        /// Exoirts to file.
        /// </summary>
        /// <param name="filename">File name.</param>
        void Export(string filename);

        /// <summary>
        /// Imports from memory.
        /// </summary>
        void Import();

        /// <summary>
        /// Exoprts to stream.
        /// </summary>
        /// <param name="stream">Export stream.</param>
        void Export(Stream stream); 

        #endregion
    }
}
