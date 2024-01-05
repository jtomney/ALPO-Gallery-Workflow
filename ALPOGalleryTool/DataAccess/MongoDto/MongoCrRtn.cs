using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ALPOGalleryTool.DataAccess.MongoDto
{
    public class MongoCrRtn
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("crNum")]
        public string CarringtonRotationNum { get; set; }

        [BsonElement("dt_start")]
        public DateTime StartDateTime { get; set; }
    }
}
