using ALPOGalleryTool.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALPOGalleryTool.DataAccess.MongoDto
{
    public class MongoMarsObservation : IObservation
    {
        public string FileName { get; set; }
        public string[] Filters { get; set; }
        public string HostGallery { get; set; }
        public string MimeType { get; set; }
        public string Notes { get; set; }
        public string ObsrvrInitials { get; set; }
        public string Section { get; set; }
        public double Seeing { get; set; }
        public string[] Tags { get; set; }
        public string Telescope { get; set; }
        public double Transparency { get; set; }
        public string Url { get; set; }
        public DateTime UtObsrvDt { get; set; }
        public DateTime InsertTimestamp { get; set; }
    }
}
