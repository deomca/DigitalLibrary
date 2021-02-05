using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace DEFCCClass.MsSql
{
    public class FolderPersist
    {
        string connectionString = ConfigurationManager.AppSettings["connString"].ToString();
        public List<Folder> GetAllFoldersByUserId(int userid, int usertype)
        {
            List<Folder> listFol = new List<Folder>();

            using (SqlConnection SqlConn = new SqlConnection(connectionString))
            {
                using (SqlCommand SqlCmd = new SqlCommand("GetAllFoldersByUserId", SqlConn))
                {
                    SqlConn.Open();
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.Add(new SqlParameter("@pUserId", SqlDbType.Int)).Value = userid;
                    SqlCmd.Parameters.Add(new SqlParameter("@pUserType", SqlDbType.VarChar)).Value = usertype;
                    SqlDataAdapter da = new SqlDataAdapter(SqlCmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Folder fol = new Folder();
                      
                        fol.FolderId = Convert.ToInt32(dr["FolderId"]);
                        fol.FolderName = dr["FolderName"].ToString();
                        fol.ParentId = Convert.ToInt32(dr["ParentId"]);
                        fol.CreatedBy = dr["CreatedBy"].ToString();
                        fol.ParentFolderName = dr["parentfolder"].ToString();
                        fol.CreatedDate = Convert.ToDateTime(dr["CreatedDate"]);
                      
                        listFol.Add(fol);
                    }
                }
            }

            return listFol;
        }

       

        public void SaveFolder(int parentid, string foldername, string status, string createdby, DateTime createddate)
        {
            using (SqlConnection SqlConn = new SqlConnection(connectionString))
            {
                using (SqlCommand SqlCmd = new SqlCommand("SaveFolder", SqlConn))
                {
                    SqlConn.Open();
                    SqlCmd.CommandType = CommandType.StoredProcedure;

                    SqlCmd.Parameters.Add(new SqlParameter("@ParentId", SqlDbType.Int)).Value = parentid;
                    SqlCmd.Parameters.Add(new SqlParameter("@FolderName", SqlDbType.VarChar)).Value = foldername;
                    SqlCmd.Parameters.Add(new SqlParameter("@Status", SqlDbType.VarChar)).Value = status;
                    SqlCmd.Parameters.Add(new SqlParameter("@CreatedBy", SqlDbType.VarChar)).Value = createdby;
                    SqlCmd.Parameters.Add(new SqlParameter("@CreatedDate", SqlDbType.DateTime)).Value = createddate;


                    SqlCmd.ExecuteNonQuery();

                }
            }


            // string query2 = "insert into dgl_folder ( ParentId,FolderName,Status,CreatedBy,CreatedDate) values (" + parentid + ",'" + foldername + "','"+ status +"','" + createdby + "','" + createddate+ "')";




        }

    }
}
