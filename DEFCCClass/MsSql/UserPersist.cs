using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace DEFCCClass.MsSql
{
    public class UserPersist
    {
        string connectionString = ConfigurationManager.AppSettings["connString"].ToString();

        public User CheckValidUser(User user)
        {
            User userModel = new User();

            using (SqlConnection SqlConn = new SqlConnection(connectionString))
            {                
                using (SqlCommand SqlCmd = new SqlCommand("ValidateUSer", SqlConn))
                {
                    SqlConn.Open();
                    SqlCmd.CommandType = CommandType.StoredProcedure;

                    SqlCmd.Parameters.Add(new SqlParameter("@pUserName", SqlDbType.VarChar)).Value = user.UserName;
                    SqlCmd.Parameters.Add(new SqlParameter("@pPassword", SqlDbType.VarChar)).Value = user.Password;

                    SqlDataAdapter da = new SqlDataAdapter(SqlCmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        userModel.UserId = Convert.ToInt32(ds.Tables[0].Rows[0]["UserId"]);
                        userModel.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                        userModel.UserType = Convert.ToInt32(ds.Tables[0].Rows[0]["UserType"]);                       
                    }
                }               
            }

            return userModel;
        }
    }
}
