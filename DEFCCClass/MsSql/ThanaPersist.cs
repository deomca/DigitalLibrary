using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace DEFCCClass.MsSql
{
    public class ThanaPersist
    {
        string connectionString = ConfigurationManager.AppSettings["connString"].ToString();

        public List<Thana> GetAllThanaByRangeId(int RangeId)
        {
            List<Thana> listThana = new List<Thana>();

            using (SqlConnection SqlConn = new SqlConnection(connectionString))
            {
                using (SqlCommand SqlCmd = new SqlCommand("GetThanaByRangeId", SqlConn))
                {
                    SqlConn.Open();
                    SqlCmd.CommandType = CommandType.StoredProcedure;

                    SqlCmd.Parameters.Add(new SqlParameter("pRangeId", SqlDbType.VarChar)).Value = RangeId;


                    SqlDataAdapter da = new SqlDataAdapter(SqlCmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Thana thana = new Thana();
                        thana.ThanaId = Convert.ToInt32(dr["ThanaId"]);
                        thana.ThanaName = dr["ThanaName"].ToString();
                        listThana.Add(thana);
                    }
                }
            }

            return listThana;
        }
    }
}
