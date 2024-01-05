using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALPOGalleryTool.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ALPOGalleryTool.DataAccess.MongoDto
{
    public class MongoTelescope : ITelescope
    {
        public MongoTelescope()
        {
            FocalLength = -1;
            FocalRatio = -1;
        }

        [BsonElement("aperture_mm")]
        public int Aperture { get; set; }

        [BsonElement("focal_length")]
        public double FocalLength { get; set; }

        [BsonElement("f_ratio")]
        public double FocalRatio { get; set; }

        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("initials")]
        public string Initials { get; set; }

        [BsonElement("notes")]
        public string Notes { get; set; }

        [BsonElement("scope_type")]
        public string ScopeType { get; set; }
    }
}
