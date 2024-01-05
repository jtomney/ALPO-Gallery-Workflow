using ALPOGalleryTool.Interfaces;
using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ALPOGalleryTool.DataAccess.MongoDto
{
    [BsonIgnoreExtraElements]
    public class MongoObserver : IObserver
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("city")]
        public string City { get; set; }

        [BsonElement("country")]
        public string Country { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("first_name")]
        public string FirstName { get; set; }

        [BsonElement("initials")]
        public string Initials { get; set; }

        [BsonElement("last_name")]
        public string LastName { get; set; }

        [BsonElement("state_prvnc")]
        public string Region { get; set; }

        [BsonElement("email_name")]
        public string EmailName { get; set; }

        public MongoObserver()
        {
            EmailName = string.Empty;
        }

    }
}
