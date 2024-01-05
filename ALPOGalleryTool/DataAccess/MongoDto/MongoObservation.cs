using ALPOGalleryTool.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Text;

namespace ALPOGalleryTool.DataAccess.MongoDto
{
    [BsonIgnoreExtraElements]
    public class MongoObservation : IObservation
    {
        private string _errMsg = string.Empty;

        public string ErrMsg { get => _errMsg; }

        [BsonElement("file_name")]
        public string FileName { get; set; }

        [BsonElement("carrRtn")]
        public int CarringtonRotation { get; set; }

        [BsonElement("filters")]
        public string[] Filters { get; set; }

        [BsonElement("gallery")]
        public string HostGallery { get; set; }

        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("mime")]
        public string MimeType { get; set; }

        [BsonElement("notes")]
        public string Notes { get; set; }

        [BsonElement("initials")]
        public string ObsrvrInitials { get; set; }

        [BsonElement("section")]
        public string Section { get; set; }

        [BsonElement("seeing")]
        public double Seeing { get; set; }

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

        [BsonElement("insrt_dt")]
        public DateTime InsertTimestamp { get; set; }

        public MongoObservation()
        {
            Seeing = 0d;
            Transparency = 0d;
        }

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
