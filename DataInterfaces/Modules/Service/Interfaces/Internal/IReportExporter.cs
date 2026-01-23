using ServerService.Reporting;
using System.IO;

namespace ServerService.Services
{
    /// <summary>
    /// Represents a type used to export reports.
    /// </summary>
    public interface IReportExporter
    {
        /// <summary>
        /// Exports the specified report.
        /// </summary>
        /// <param name="export"></param>
        /// <returns></returns>
        MemoryStream Export(ExportDTO export);
    }
}
