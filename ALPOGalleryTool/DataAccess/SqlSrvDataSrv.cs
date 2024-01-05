using ALPOGalleryTool.DataAccess.SqlSrvDto;
using ALPOGalleryTool.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALPOGalleryTool.DataAccess
{
    public class SqlSrvDataSrv : IActvRgnDataSrvc
    {
        private readonly string _cnnStr;

        public SqlSrvDataSrv(string cnnStr)
        {
            _cnnStr = cnnStr;
        }
        public IEnumerable<ActvRgnDateDto> GetActvRgnByDate(DateTime date)
        {
            List<ActvRgnDateDto> result = new List<ActvRgnDateDto>();
            using (SqlDataAdapter da = new SqlDataAdapter($"SELECT * FROM ARbyDate WHERE ObsrvDt = '{date.ToString("G")}'", _cnnStr))
            {
                DataSet ds = new DataSet();
                da.Fill(ds);

                foreach (DataRow rw in ds.Tables[0].Rows)
                {
                    ActvRgnDateDto tmp = new ActvRgnDateDto()
                    {
                        ArDt = (DateTime)rw["ObsrvDt"],
                        ActvRgn = (string)rw["AR"]
                    };
                    result.Add(tmp);
                }
            }
            return result;
        }

        public int InsertActvRgn(ActvRgnDateDto dto)
        {
            int result = 0;
            using (SqlConnection conn = new SqlConnection(_cnnStr))
            {
                conn.Open();
                string sql = "INSERT INTO ARbyDate (ObsrvDt, AR) VALUES ('" + dto.ArDt.ToString("G") + "','" + dto.ActvRgn + "')";
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    result = cmd.ExecuteNonQuery();
                }
            }
            return result;
        }
    }
}
