using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALPOGalleryTool.DataAccess.MongoDto;
using ALPOGalleryTool.Interfaces;

namespace ALPOGalleryTool
{
    public class JupiterCentralMeridian
    {
        private const double MinuteIncrementFactorSysI = 0.6096d;
        private const double MinuteIncrementFactorSysII = 0.6045d;
        private readonly List<MongoCmTransit> _lstPrimeMeridianTransits;

        public JupiterCentralMeridian(IDataSrvc dataSrvc, DateTime obsrvDt)
        {
            DateTime earliest = obsrvDt.AddDays(1);
            DateTime oldest = obsrvDt.AddDays(-1);
            List<MongoCmTransit> lst = dataSrvc.GetPrimeMeridianTransitByPlanet("Jupiter").ToList();
            _lstPrimeMeridianTransits = lst.Where(c => c.CM >= oldest && c.CM <= earliest).ToList();
        }
        public string GetJupiterCMbyObsrvDt(DateTime obsrvDt, string system)
        {
            string result = "Not Found";
            MongoCmTransit primeMeridianTransitTime = _lstPrimeMeridianTransits.FirstOrDefault(d => d.CM >= obsrvDt && d.LongSystem == system);
            if (primeMeridianTransitTime!=null)
            {
                DateTime pm = primeMeridianTransitTime.CM;
                double deltaMinutes = pm.Subtract(obsrvDt).TotalMinutes;
                double cm = (system == "CMI")
                    ? 360 - (MinuteIncrementFactorSysI * deltaMinutes)
                    : 360 - (MinuteIncrementFactorSysII * deltaMinutes);
                while (cm < 0)
                {
                    cm = 360 + cm;
                }
                result = Math.Round(cm).ToString(CultureInfo.InvariantCulture);
            }

            return result;
        }

    }
}
