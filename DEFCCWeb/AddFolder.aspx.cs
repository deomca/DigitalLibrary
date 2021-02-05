using System.Data.SqlClient;
using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Text;
using System.Web.UI.WebControls;
using DEFCCClass.MsSql;
using System.Collections;
using DEFCCClass;
using System.Collections.Generic;


public partial class AddFolder : System.Web.UI.Page
{
    string connectionString = ConfigurationManager.AppSettings["connString"].ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Convert.ToInt16(Session["userType"]) > 0)
            {

                List<Folder> listfolder = new FolderPersist().GetAllFoldersByUserId(Convert.ToInt32(Session["UserId"]), Convert.ToInt32(Session["UserType"]));

                grdFolder.DataSource = listfolder;
                grdFolder.DataBind();


                drpParentFolder.DataSource = listfolder;
                drpParentFolder.DataTextField = "FolderName";
                drpParentFolder.DataValueField = "FolderId";
                drpParentFolder.DataBind();


            }
            else
            {
                Response.Redirect("login.aspx");

            }
        }
    }
    protected void btnSaveFolder_Click(object sender, EventArgs e)
    {
        int folderid = 0;
       
        if (drpParentFolder.SelectedValue != "")
            folderid = Convert.ToInt32(drpParentFolder.SelectedValue);
        
        new FolderPersist().SaveFolder(folderid, txtFolderName.Text.ToString(), "ACT", Session["UserName"].ToString(), DateTime.Now);


        string saveImagePath = ConfigurationManager.AppSettings["SaveImagePath"];

        string folderpath = string.Empty;
       
        if (drpParentFolder.SelectedValue != "")
            folderpath = drpParentFolder.SelectedItem.Text;
       
        string finalpath = saveImagePath + folderpath + "\\" + txtFolderName.Text;

        if (!Directory.Exists(finalpath))
        {
            DirectoryInfo di = Directory.CreateDirectory(finalpath);
        }

        Response.Redirect("AddFolder.aspx");
    }


    protected void grdFolder_SelectedIndexChanged(object sender, EventArgs e)
    {
        //grdFolder.PageIndex = e.NewPageIndex;
        //BindGrid();
    }
    //public void BindGrid(string sortExpression = null)
    //{
    //    using (SqlConnection SqlConn = new SqlConnection(connectionString))
    //    {
    //        using (SqlCommand cmdUser = new SqlCommand("GetFolderByUserId", SqlConn))
    //        {
    //            cmdUser.Parameters.Add(new SqlParameter("pUserId", SqlDbType.Int)).Value = Convert.ToInt32(Session["userId"]);
    //            cmdUser.Parameters.Add(new SqlParameter("pUserType", SqlDbType.Int)).Value = Convert.ToInt32(Session["userType"]);


    //            cmdUser.CommandType = CommandType.StoredProcedure;
    //            SqlConn.Open();

    //            SqlDataAdapter daUser = new SqlDataAdapter(cmdUser);
    //            DataTable dt = new DataTable();
    //            daUser.Fill(dt);

    //            if (sortExpression != null)
    //            {
    //                DataView dv = dt.AsDataView();
    //                this.SortDirection = this.SortDirection == "ASC" ? "DESC" : "ASC";

    //                dv.Sort = sortExpression + " " + this.SortDirection;
    //                grdFolder.DataSource = dv;
    //            }
    //            else
    //            {
    //                grdFolder.DataSource = dt;
    //            }

    //            grdFolder.DataBind();
    //        }
    //    }
    //}
}