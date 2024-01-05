using ALPOGalleryTool.DataAccess.SqlSrvDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALPOGalleryTool.Interfaces
{
    public interface IActvRgnDataSrvc
    {
        IEnumerable<ActvRgnDateDto> GetActvRgnByDate(DateTime date);

        int InsertActvRgn (ActvRgnDateDto dto);
    }
}
