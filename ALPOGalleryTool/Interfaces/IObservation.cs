using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALPOGalleryTool.Interfaces
{
    public interface IObservation
    {
        string FileName { get; set; }
        string[] Filters { get; set; }
        string HostGallery { get; set; }
        string MimeType { get; set; }
        string Notes { get; set; }
        string ObsrvrInitials { get; set; }
        string Section { get; set; }
        double Seeing { get; set; }
        string[] Tags { get; set; }
        string Telescope { get; set; }
        double Transparency { get; set; }
        string Url { get; set; }
        DateTime UtObsrvDt { get; set; }
        DateTime InsertTimestamp { get; set; }
    }
}
