using ALPOGalleryTool.DataAccess.MongoDto;
using Org.BouncyCastle.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALPOGalleryTool.Interfaces
{
    public interface IEclipseDataSrvc
    {
        int AddObservation(MongoEclipseDto obsrvtn);

        IEnumerable<MongoEclipseDto> GetAllEclipseObservations();

        int UpdateEclipseRecord(MongoEclipseDto rec);

        IEnumerable<string> GetPersistentTags(string tagType);
    }
}
