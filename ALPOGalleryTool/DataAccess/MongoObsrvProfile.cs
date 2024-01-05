using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ALPOGalleryTool.DataAccess
{
    public class MongoObsrvProfile
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("profile_name")]
        public string ProfileName { get; set; }

        [BsonElement("initials")]
        public string ObsrvrInitials { get; set; }

        [BsonElement("tags")]
        public string[] Tags { get; set; }

        [BsonElement("telescope")]
        public string Telescope { get; set; }

        [BsonElement("section")]
        public string Section { get; set; }

        [BsonElement("filters")]
        public string[] Filters { get; set; }

    }
}
