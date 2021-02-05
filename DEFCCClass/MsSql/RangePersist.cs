using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace DEFCCClass.MsSql
{
    public class RangePersist
    {
        string connectionString = ConfigurationManager.AppSettings["connString"].ToString();
        public List<Range> GetAllRangeByDivisionId(int DivisionId)
        {
            List<Range> listRange = new List<Range>();

            using (SqlConnection SqlConn = new SqlConnection(connectionString))
            {
                using (SqlCommand SqlCmd = new SqlCommand("GetRangeByDivisionId", SqlConn))
                {
                    SqlConn.Open();
                    SqlCmd.CommandType = CommandType.StoredProcedure;

                    SqlCmd.Parameters.Add(new SqlParameter("pDivisionId", SqlDbType.VarChar)).Value = DivisionId;


                    SqlDataAdapter da = new SqlDataAdapter(SqlCmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Range rang = new Range();
                        rang.RangeId = Convert.ToInt32(dr["RangeId"]);
                        rang.RangeName = dr["RangeName"].ToString();
                        listRange.Add(rang);
                    }
                }
            }

            return listRange;
        }

    }
}
