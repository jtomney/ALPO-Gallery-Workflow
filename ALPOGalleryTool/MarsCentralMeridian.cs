using ALPOGalleryTool.DataAccess.MongoDto;
using ALPOGalleryTool.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ALPOGalleryTool
{
    public class MarsCentralMeridian
    {
        private const double MinuteIncrementFactor = 0.2434d;
        private readonly List<DateTime> _lstPrimeMeridianTransits;

        public MarsCentralMeridian(IDataSrvc dataSrvc)
        {
            DateTime earliest = DateTime.Today.AddDays(5);
            DateTime oldest = DateTime.Today.AddDays(-270);
            List<MongoCmTransit> lst = dataSrvc.GetPrimeMeridianTransitByPlanet("Mars").ToList();
            _lstPrimeMeridianTransits = lst.Where(c => c.CM >= oldest && c.CM <= earliest).Select(c => c.CM).ToList();
        }

        public string GetMarsCMbyObsrvDt(DateTime obsrvDt)
        {
            string result = "Not Found";
            DateTime obsrvDtLessDay = obsrvDt.AddDays(-1);
            List<DateTime> primeMeridianTransitTimes = _lstPrimeMeridianTransits.Where(d => d >= obsrvDtLessDay).OrderBy(d=>d).ToList();
            if (primeMeridianTransitTimes.Any())
            {
                DateTime pm = primeMeridianTransitTimes[0];
                for (int i = 1; i < primeMeridianTransitTimes.Count; i++)
                {
                    if (primeMeridianTransitTimes[i] < obsrvDt)
                    {
                        pm = primeMeridianTransitTimes[i];
                    }
                    else
                    {
                        break;
                    }
                }
                double deltaMinutes = obsrvDt.Subtract(pm).TotalMinutes;
                double cm = (MinuteIncrementFactor * deltaMinutes);
                result = Math.Round(cm).ToString(CultureInfo.InvariantCulture);
            }

            return result;
        }

    }
}
