using ALPOGalleryTool.DataAccess.MongoDto;
using ALPOGalleryTool.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ALPOGalleryTool.DataAccess
{
    public class MongoDataSrvc : IDataSrvc
    {
        private readonly string _cnnStr;
        private MongoClient _clnt;
        IMongoDatabase _db;

        public MongoDataSrvc(string cnnStr)
        {
            _cnnStr = cnnStr;
            _clnt = new MongoClient(_cnnStr);
            _db = _clnt.GetDatabase("alpo");
        }

        public int AddObservation(IObservation obsrvtn)
        {
            int result = 0;
            obsrvtn.InsertTimestamp = DateTime.UtcNow;
            try
            {
                IMongoCollection<MongoObservation> col = _db.GetCollection<MongoObservation>("observations");
                col.InsertOne((MongoObservation)obsrvtn);
                result = 1;
            }
            catch (Exception)
            {
                try
                {
                    var client = new MongoClient(_cnnStr);
                    var db = client.GetDatabase("alpo");
                    IMongoCollection<MongoObservation> col = db.GetCollection<MongoObservation>("observations");
                    col.InsertOne((MongoObservation)obsrvtn);
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

        public int AddObserver(IObserver obsrvr)
        {
            int result = 0;
            try
            {
                var client = new MongoClient(_cnnStr);
                var db = client.GetDatabase("alpo");
                IMongoCollection<MongoObserver> col = db.GetCollection<MongoObserver>("observers");
                col.InsertOne((MongoObserver)obsrvr);
                result = 1;
            }
            catch (Exception ex)
            {
                //if (ErrorThrown != null) ErrorThrown.Invoke(this, ex.Message);
                result = 0;
            }
            return result;
        }

        public int AddObsrvProfile(MongoObsrvProfile profile)
        {
            int result = 0;
            try
            {
                IMongoCollection<MongoObsrvProfile> col = _db.GetCollection<MongoObsrvProfile>("profiles");
                col.InsertOne((MongoObsrvProfile)profile);
                result = 1;
            }
            catch (Exception)
            {
                try
                {
                    var client = new MongoClient(_cnnStr);
                    var db = client.GetDatabase("alpo");
                    IMongoCollection<MongoObsrvProfile> col = db.GetCollection<MongoObsrvProfile>("profiles");
                    col.InsertOne((MongoObsrvProfile)profile);
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

        public int AddTelescope(ITelescope telescope)
        {
            int result = 0;
            try
            {
                var client = new MongoClient(_cnnStr);
                var db = client.GetDatabase("alpo");
                IMongoCollection<MongoTelescope> col = db.GetCollection<MongoTelescope>("telescopes");
                col.InsertOne((MongoTelescope)telescope);
                result = 1;
            }
            catch (Exception)
            {
                //if (ErrorThrown != null) ErrorThrown.Invoke(this, ex.Message);
                result = 0;
            }
            return result;
        }

        public IEnumerable<IObserver> GetAllObservers()
        {
            List<IObserver> result = new List<IObserver>();
            string connectionString = _cnnStr;
            var client = new MongoClient(connectionString);
            var db = client.GetDatabase("alpo");
            IMongoCollection<MongoObserver> col = db.GetCollection<MongoObserver>("observers");
            var bldr = Builders<MongoObserver>.Filter.Empty;
            var docs = col.Find(bldr).ToList();
            return docs;
        }

        public IEnumerable<ITelescope> GetAllTelescopes()
        {
            string connectionString = _cnnStr;
            var client = new MongoClient(connectionString);
            var db = client.GetDatabase("alpo");
            IMongoCollection<MongoTelescope> col = db.GetCollection<MongoTelescope>("telescopes");
            var bldr = Builders<MongoTelescope>.Filter.Empty;
            var scopes = col.Find(bldr).ToList();
            return scopes;
        }

        public IEnumerable<MongoCrRtn> GetCrRtns()
        {
            string connectionString = _cnnStr;
            var client = new MongoClient(connectionString);
            var db = client.GetDatabase("alpo");
            IMongoCollection<MongoCrRtn> col = db.GetCollection<MongoCrRtn>("carrington");
            var bldr = Builders<MongoCrRtn>.Filter.Empty;
            var docs = col.Find(bldr).ToList();
            return docs;
        }

        public IEnumerable<MongoLongitude> GetLongDataByPlanet(string planet)
        {
            string connectionString = _cnnStr;
            var client = new MongoClient(connectionString);
            var db = client.GetDatabase("alpo");
            IMongoCollection<MongoLongitude> col = db.GetCollection<MongoLongitude>("data_cm");
            var bldr = Builders<MongoLongitude>.Filter.Eq(d => d.Planet, planet);
            var cmData = col.Find(bldr).ToList();
            cmData.Sort();
            return cmData;
        }

        public IEnumerable<MongoObservation> GetObsrvtnsByDateRange(DateTime start, DateTime stop)
        {
            List<MongoObservation> result = new List<MongoObservation>();

            string connectionString = _cnnStr;
            var client = new MongoClient(connectionString);
            var db = client.GetDatabase("alpo");
            IMongoCollection<MongoObservation> col = db.GetCollection<MongoObservation>("observations");
            var bldr = Builders<MongoObservation>.Filter.Lte(o => o.UtObsrvDt, stop) &
                       Builders<MongoObservation>.Filter.Gte(o => o.UtObsrvDt, start);
            var observations = col.Find(bldr).ToList();
            if (observations.Any()) result = observations;
            return result;
        }

        public string GetObsrvUrl(string fileName)
        {
            string result = string.Empty;
            IMongoCollection<MongoObservation> col = _db.GetCollection<MongoObservation>("observations");
            var bldr = Builders<MongoObservation>.Filter.Eq(o => o.FileName, fileName);
            var docs = col.Find(bldr).ToList();
            if (docs.Count > 0)
            {
                result = docs[0].Url;
            }

            return result;
        }

        public IEnumerable<string> GetPersistentTags(string section)
        {
            List<String> result = new List<string>();
            try
            {
                string connectionString = _cnnStr;
                var client = new MongoClient(connectionString);
                var db = client.GetDatabase("alpo");
                IMongoCollection<MongoPersistentTag> col = db.GetCollection<MongoPersistentTag>("persistent_tags");
                var bldr = Builders<MongoPersistentTag>.Filter.Eq(o => o.Section, section);
                var tags = col.Find(bldr).ToList();
                result.AddRange(tags.Select(t => t.Tag).ToArray());
            }
            catch (Exception e)
            {
                result.Add(e.Message);
            }
            return result;
        }

        public IEnumerable<MongoCmTransit> GetPrimeMeridianTransitByPlanet(string planet)
        {
            IEnumerable<MongoCmTransit> cmData = new List<MongoCmTransit>();
            try
            {
                IMongoCollection<MongoCmTransit> col = _db.GetCollection<MongoCmTransit>("data_cm");
                var bldr = Builders<MongoCmTransit>.Filter.Eq(d => d.Planet, planet);
                cmData = col.Find(bldr).ToList();
                cmData.OrderBy(c => c.CM);
            }
            catch (Exception ex)
            {
                string connectionString = _cnnStr;
                _clnt = new MongoClient(connectionString);
                _db = _clnt.GetDatabase("alpo");
                IMongoCollection<MongoCmTransit> col = _db.GetCollection<MongoCmTransit>("data_cm");
                var bldr = Builders<MongoCmTransit>.Filter.Eq(d => d.Planet, planet);
                cmData = col.Find(bldr).ToList();
                cmData.OrderBy(c => c.CM);
            }

            return cmData;
        }

        public IEnumerable<MongoObsrvProfile> GetProfileBySectAndInit(string section, string initials)
        {
            List<MongoObsrvProfile> result = new List<MongoObsrvProfile>();
            try
            {
                string connectionString = _cnnStr;
                var client = new MongoClient(connectionString);
                var db = client.GetDatabase("alpo");
                IMongoCollection<MongoObsrvProfile> col = db.GetCollection<MongoObsrvProfile>("profiles");
                var bldr = Builders<MongoObsrvProfile>.Filter.Eq(p => p.Section, section) &
                    Builders<MongoObsrvProfile>.Filter.Eq(p => p.ObsrvrInitials, initials);
                var profiles = col.Find(bldr).ToList();
                if (profiles.Count > 0)
                {
                    result = profiles.ToList();
                }
            }
            catch (Exception)
            {
                result.Clear();
            }
            return result;
        }

        public IEnumerable<MongoObsrvProfile> GetAllProfiles()
        {
            List<MongoObsrvProfile> result = new List<MongoObsrvProfile>();
            try
            {
                string connectionString = _cnnStr;
                var client = new MongoClient(connectionString);
                var db = client.GetDatabase("alpo");
                IMongoCollection<MongoObsrvProfile> col = db.GetCollection<MongoObsrvProfile>("profiles");
                var bldr = Builders<MongoObsrvProfile>.Filter.Empty;
                var profiles = col.Find(bldr).ToList();
                if (profiles.Count > 0)
                {
                    result = profiles.OrderBy(p=>p.ObsrvrInitials).OrderBy(p=>p.ProfileName).ToList();
                }
            }
            catch (Exception)
            {
                result.Clear();
            }
            return result;
        }

        public IEnumerable<string> GetRecentTags(string section)
        {
            List<String> result = new List<string>();
            try
            {
                string connectionString = _cnnStr;
                var client = new MongoClient(connectionString);
                var db = client.GetDatabase("alpo");
                IMongoCollection<MongoObservation> col = db.GetCollection<MongoObservation>("observations");
                var bldr = Builders<MongoObservation>.Filter.Eq(o => o.Section, section) &
                           Builders<MongoObservation>.Filter.Gte(o => o.UtObsrvDt, DateTime.Now.AddDays(-45));
                var observations = col.Find(bldr).ToList();
                foreach (MongoObservation obs in observations)
                {
                    foreach (string tag in obs.Tags)
                    {
                        if (!tag.ToUpper().StartsWith("CM") && !result.Contains(tag) && !string.IsNullOrEmpty(tag))
                        {
                            result.Add(tag);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                result.Add(e.Message);
            }
            return result;
        }

        public IEnumerable<string> GetRecentTags(string section, int lookBack)
        {
            lookBack = lookBack * (- 1);
            List<String> result = new List<string>();
            try
            {
                string connectionString = _cnnStr;
                var client = new MongoClient(connectionString);
                var db = client.GetDatabase("alpo");
                IMongoCollection<MongoObservation> col = db.GetCollection<MongoObservation>("observations");
                var bldr = Builders<MongoObservation>.Filter.Eq(o => o.Section, section) &
                           Builders<MongoObservation>.Filter.Gte(o => o.UtObsrvDt, DateTime.Now.AddDays(lookBack));
                var observations = col.Find(bldr).ToList();
                foreach (MongoObservation obs in observations)
                {
                    foreach (string tag in obs.Tags)
                    {
                        if (!tag.ToUpper().StartsWith("CM") && !result.Contains(tag) && !string.IsNullOrEmpty(tag))
                        {
                            result.Add(tag);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                result.Add(e.Message);
            }
            return result;
        }

        public IEnumerable<string> GetRecentTagsByObsrvDt(string section, int lookBack, DateTime obsrvDt)
        {
            lookBack = lookBack * (-1);
            List<String> result = new List<string>();
            try
            {
                string connectionString = _cnnStr;
                var client = new MongoClient(connectionString);
                var db = client.GetDatabase("alpo");
                IMongoCollection<MongoObservation> col = db.GetCollection<MongoObservation>("observations");
                var bldr = Builders<MongoObservation>.Filter.Eq(o => o.Section, section) &
                           Builders<MongoObservation>.Filter.Gte(o => o.UtObsrvDt, obsrvDt.AddDays(lookBack)) &
                           Builders<MongoObservation>.Filter.Lte(o => o.UtObsrvDt, obsrvDt.AddDays(lookBack * -1));
                var observations = col.Find(bldr).ToList();
                foreach (MongoObservation obs in observations)
                {
                    foreach (string tag in obs.Tags)
                    {
                        if (!tag.ToUpper().StartsWith("CM") && !result.Contains(tag) && !string.IsNullOrEmpty(tag))
                        {
                            result.Add(tag);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                result.Add(e.Message);
            }
            return result;
        }
    }
}
