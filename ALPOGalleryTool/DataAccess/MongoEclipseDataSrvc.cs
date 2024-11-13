using ALPOGalleryTool.DataAccess.MongoDto;
using ALPOGalleryTool.Interfaces;
using DnsClient.Protocol;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace ALPOGalleryTool.DataAccess
{
    public class MongoEclipseDataSrvc : IEclipseDataSrvc
    {
        private readonly string _cnnStr;
        private MongoClient _clnt;
        private IMongoDatabase _db;

        public MongoEclipseDataSrvc(string cnnStr)
        {
            _cnnStr = cnnStr;
            _clnt = new MongoClient(_cnnStr);
            _db = _clnt.GetDatabase("alpo");
        }

        public int AddObservation(MongoEclipseDto obsrvtn)
        {
            int result = 0;
            obsrvtn.InsertTimestamp = DateTime.UtcNow;
            try
            {
                IMongoCollection<MongoEclipseDto> col = _db.GetCollection<MongoEclipseDto>("observations");
                col.InsertOne((MongoEclipseDto)obsrvtn);
                result = 1;
            }
            catch (Exception)
            {
                try
                {
                    var client = new MongoClient(_cnnStr);
                    var db = client.GetDatabase("alpo");
                    IMongoCollection<MongoEclipseDto> col = db.GetCollection<MongoEclipseDto>("observations");
                    col.InsertOne((MongoEclipseDto)obsrvtn);
                    result = 1;
                    _clnt = client;
                    _db = db;
                }
                catch (Exception exRetry)
                {
                    //if (ErrorThrown != null) ErrorThrown.Invoke(this, ex.Message);
                    result = 0;
                }
            }
            return result;
        }

        public IEnumerable<MongoEclipseDto> GetAllEclipseObservations()
        {
            List<MongoEclipseDto> result = new List<MongoEclipseDto>();
            var client = new MongoClient(_cnnStr);
            var db = client.GetDatabase("alpo");
            IMongoCollection<MongoEclipseDto> col = db.GetCollection<MongoEclipseDto>("observations");
            var bldr = Builders<MongoEclipseDto>.Filter.Eq(d => d.HostGallery, "Eclipse");
            result = col.Find(bldr).ToList();
            return result;
        }

        public IEnumerable<string> GetPersistentTags(string eclipseType)
        {
            List<String> result = new List<string>();
            try
            {
                string connectionString = _cnnStr;
                var client = new MongoClient(connectionString);
                var db = client.GetDatabase("alpo");
                IMongoCollection<MongoPersistentTag> col = db.GetCollection<MongoPersistentTag>("persistent_tags");
                var fltr = Builders<MongoPersistentTag>.Filter.Eq(o => o.Section, "Eclipse");
                fltr &= Builders<MongoPersistentTag>.Filter.Eq(o => o.EventType, eclipseType);
                var tags = col.Find(fltr).ToList();
                result.AddRange(tags.Select(t => t.Tag).ToArray());
            }
            catch (Exception e)
            {
                result.Add(e.Message);
            }
            return result;
        }

        public int UpdateEclipseRecord(MongoEclipseDto rec)
        {
            int result = 0;

            var dbClient = new MongoClient(_cnnStr);

            IMongoDatabase db = dbClient.GetDatabase("alpo");

            var observations = db.GetCollection<BsonDocument>("observations");

            var filter = Builders<BsonDocument>.Filter.Eq("file_name", rec.FileName);
            var update = Builders<BsonDocument>.Update.Set("url", rec.Url);

            UpdateResult updResult = observations.UpdateOne(filter, update);
            result = (int)updResult.ModifiedCount;
            return result;
        }
    }
}
