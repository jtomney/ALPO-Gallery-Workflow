using System;
using System.Collections.Generic;
using ALPOGalleryTool.DataAccess;
using ALPOGalleryTool.DataAccess.MongoDto;

namespace ALPOGalleryTool.Interfaces
{
    public interface IDataSrvc
    {
        int AddObservation(IObservation obsrvtn);

        int AddObserver(IObserver obsrvr);

        int AddObsrvProfile(MongoObsrvProfile profile);

        int AddTelescope(ITelescope telescope);

        IEnumerable<IObserver> GetAllObservers();

        IEnumerable<MongoObsrvProfile> GetAllProfiles();

        IEnumerable<ITelescope> GetAllTelescopes();

        IEnumerable<MongoCrRtn> GetCrRtns();

        IEnumerable<MongoLongitude> GetLongDataByPlanet(string planet);

        IEnumerable<MongoObservation> GetObsrvtnsByDateRange(DateTime start, DateTime stop);

        string GetObsrvUrl(string fileName);

        IEnumerable<string> GetPersistentTags(string section);

        IEnumerable<MongoCmTransit> GetPrimeMeridianTransitByPlanet(string planet);

        IEnumerable<MongoObsrvProfile> GetProfileBySectAndInit(string section, string initials);
        IEnumerable<string> GetRecentTags(string section);
        IEnumerable<string> GetRecentTags(string section, int lookBack);
        IEnumerable<string> GetRecentTagsByObsrvDt(string section, int lookBack, DateTime obsrvDt);
    }
}
