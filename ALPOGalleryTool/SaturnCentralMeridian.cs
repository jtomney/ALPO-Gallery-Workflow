using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALPOGalleryTool.DataAccess;
using ALPOGalleryTool.DataAccess.MongoDto;
using ALPOGalleryTool.DataAccess.SaturnDataSetTableAdapters;
using ALPOGalleryTool.Interfaces;

namespace ALPOGalleryTool
{
    public class SaturnCentralMeridian
    {
        private const double MinuteIncrementFactorSysI = 0.5863d;
        private const double MinuteIncrementFactorSysII = 0.5637d;
        private readonly List<MongoCmTransit> _lstPrimeMeridianTransits;
        private SaturnDataSet.vwSaturnCMDataTable _saturnDataSet = new SaturnDataSet.vwSaturnCMDataTable();

        public SaturnCentralMeridian(IDataSrvc dataSrvc)
        {
            //DateTime earliest = DateTime.Today.AddDays(60);
            //DateTime oldest = DateTime.Today.AddDays(-60);
            //List<MongoCmTransit> lst = dataSrvc.GetPrimeMeridianTransitByPlanet("Saturn").ToList();
            //_lstPrimeMeridianTransits = lst.Where(c => c.CM >= oldest && c.CM <= earliest).ToList();

            vwSaturnCMTableAdapter vwSaturnCMTableAdapter = new vwSaturnCMTableAdapter();
            vwSaturnCMTableAdapter.Fill(_saturnDataSet);

        }
        public string GetSaturnCMbyObsrvDt(DateTime obsrvDt, string system)
        {
            string result = "Not Found";
            DateTime nextCM_Transit = DateTime.MinValue;
            foreach (SaturnDataSet.vwSaturnCMRow rw in _saturnDataSet.Rows)
            {
                if (rw.cm_transit >= obsrvDt && rw.system == system)
                {
                    nextCM_Transit = rw.cm_transit;
                    break;
                }
            }

            DateTime pm = nextCM_Transit;
            double deltaMinutes = pm.Subtract(obsrvDt).TotalMinutes;
            double offset = (system == "CMI")
                ? (MinuteIncrementFactorSysI * deltaMinutes)
                : (MinuteIncrementFactorSysII * deltaMinutes);
            while (offset > 360)
            {
                offset = offset - 360;
            }
            double cm = 360 - offset;
            result = Math.Round(cm).ToString(CultureInfo.InvariantCulture);


            //MongoCmTransit primeMeridianTransitTime = _lstPrimeMeridianTransits.FirstOrDefault(d => d.CM >= obsrvDt && d.LongSystem == system);
            //if (primeMeridianTransitTime != null)
            //{
            //    DateTime pm = primeMeridianTransitTime.CM;
            //    double deltaMinutes = pm.Subtract(obsrvDt).TotalMinutes;
            //    double offset = (system == "CMI")
            //        ? (MinuteIncrementFactorSysI * deltaMinutes)
            //        : (MinuteIncrementFactorSysII * deltaMinutes);
            //    while (offset > 360)
            //    {
            //        offset = offset - 360;
            //    }
            //    double cm = 360 - offset;
            //    result = Math.Round(cm).ToString(CultureInfo.InvariantCulture);
            //}

            return result;
        }
    }
}
