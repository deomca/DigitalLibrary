using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace DEFCCClass.MsSql
{

    public class DivisionPersist
    {
        string connectionString = ConfigurationManager.AppSettings["connString"].ToString();

        public List<Division> GetAllDivisionByUserId(int UserId, int UserType)
        {            
            List<Division> listDivision = new List<Division>();
            
            using (SqlConnection SqlConn = new SqlConnection(connectionString))
            {
                using (SqlCommand SqlCmd = new SqlCommand("GetDivisionByUserId", SqlConn))
                {
                    SqlConn.Open();
                    SqlCmd.CommandType = CommandType.StoredProcedure;

                    SqlCmd.Parameters.Add(new SqlParameter("pUserId", SqlDbType.VarChar)).Value = UserId;
                    SqlCmd.Parameters.Add(new SqlParameter("pUserType", SqlDbType.VarChar)).Value = UserType;

                    SqlDataAdapter da = new SqlDataAdapter(SqlCmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    foreach(DataRow dr in ds.Tables[0].Rows)
                    {
                        Division div = new Division();

                        div.DivisionId = Convert.ToInt32(dr["DivisionId"]);
                        div.Name = dr["Name"].ToString();

                        listDivision.Add(div);                       
                    }
                }
            }

            return listDivision;
        }
    }
}
