using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
    public interface IMediaCapture
    {
        /// <summary>
        /// Shows capture dialog.
        /// </summary>
        /// <param name="result">Result image.</param>
        /// <returns>True if sucessfully captured otherwise false.</returns>
        bool CaptureImage(out byte[] result);
    }
}
