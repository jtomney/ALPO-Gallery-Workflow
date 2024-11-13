using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALPOGalleryTool.DataAccess.MongoDto
{
    [BsonIgnoreExtraElements]
    public class MongoEclipseDto
    {
        private string _errMsg = string.Empty;

        public MongoEclipseDto()
        {
            Seeing = 0d;
            Transparency = 0d;
        }

        [BsonElement("camera")]
        public string Camera { get; set; }

        [BsonElement("eclipse_type")]
        public string EclipseType { get; set; }

        public string ErrMsg { get => _errMsg; }

        [BsonElement("exposure")]
        public string Exposure { get; set; }

        [BsonElement("file_name")]
        public string FileName { get; set; }

        [BsonElement("filters")]
        public string[] Filters { get; set; }

        [BsonElement("focal_len")]
        public double FocalLength { get; set; }

        [BsonElement("gallery")]
        public string HostGallery { get; set; }

        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("insrt_dt")]
        public DateTime InsertTimestamp { get; set; }

        [BsonElement("iso")]
        public string ISO { get; set; }

        [BsonElement("latitude")]
        public double Latitude { get; set; }

        [BsonElement("location")]
        public string Location { get; set; }

        [BsonElement("longitude")]
        public double Longitude { get; set; }

        [BsonElement("magnitude")]
        public double Magnitude { get; set; }

        [BsonElement("mime")]
        public string MimeType { get; set; }

        [BsonElement("notes")]
        public string Notes { get; set; }

        [BsonElement("obscuration")]
        public double Obscured { get; set; }

        [BsonElement("initials")]
        public string ObsrvrInitials { get; set; }
        [BsonElement("section")]
        public string Section { get; set; }

        [BsonElement("seeing")]
        public double Seeing { get; set; }

        [BsonElement("stage")]
        public string Stage { get; set; }

        [BsonElement("tags")]
        public string[] Tags { get; set; }

        [BsonElement("telescope")]
        public string Telescope { get; set; }

        [BsonElement("transparency")]
        public double Transparency { get; set; }

        [BsonElement("url")]
        public string Url { get; set; }

        [BsonElement("obsrv_dt")]
        public DateTime UtObsrvDt { get; set; }
        public bool IsValid()
        {
            StringBuilder sb = new StringBuilder();
            bool result = true;
            if (MimeType == string.Empty)
            {
                result = false;
                sb.Append("MimeType is required. ");
            }
            if (Filters.Length == 0)
            {
                result = false;
                sb.Append("A filter value is required. ");
            }
            if (HostGallery == string.Empty)
            {
                result = false;
                sb.Append("HostGallery is required. ");
            }
            if (Url == string.Empty)
            {
                result = false;
                sb.Append("Url is required. ");
            }

            if (result == false) _errMsg = sb.ToString();
            return result;
        }
    }
}
