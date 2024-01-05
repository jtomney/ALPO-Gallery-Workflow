using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ALPOGalleryTool.DataAccess.MongoDto
{
    [BsonIgnoreExtraElements]
    public class MongoLongitude:IComparable
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("planet")]
        public string Planet { get; set; }

        [BsonElement("obsrvdt")]
        public string DateStamp { get; set; }

        [BsonElement("cm")]
        public double? CM { get; set; }

        [BsonElement("cm1")]
        public double? CM_I { get; set; }

        [BsonElement("cm2")]
        public double? CM_II { get; set; }

        public int CompareTo(object obj)
        {
            MongoLongitude other = (MongoLongitude) obj;
            return String.CompareOrdinal(DateStamp, other.DateStamp);
        }
    }
}
