using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CoreLib.Registry
{
    /// <summary>
    /// Registry file interfaces.
    /// </summary>
    public interface IRegistryFile
    {
        void Import(string filename);
        void Export(string filename);
        void Import();
        void Export(Stream stream);
    }
}
