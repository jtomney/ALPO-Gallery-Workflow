using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ALPOGalleryTool.DataAccess.MongoDto
{
    [BsonIgnoreExtraElements]
    public class MongoPersistentTag
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("section")]
        public string Section { get; set; }

        [BsonElement("tag")]
        public string Tag { get; set; }

        [BsonElement("eventType")]
        public string EventType { get; set; }
    }
}
