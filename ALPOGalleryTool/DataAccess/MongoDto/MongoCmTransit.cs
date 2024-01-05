using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace ALPOGalleryTool.DataAccess.MongoDto
{
    [BsonIgnoreExtraElements]
    public class MongoCmTransit: IComparable
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("planet")]
        public string Planet { get; set; }

        [BsonElement("cm_transit")]
        public DateTime CM { get; set; }

        [BsonElement("system")]
        public string LongSystem { get; set; }

        public MongoCmTransit()
        {
            CM = DateTime.MaxValue;
            LongSystem = "";
        }

        public int CompareTo(object obj)
        {
            MongoCmTransit other = (MongoCmTransit) obj;
            return DateTime.Compare(this.CM, other.CM);
        }
    }
}
