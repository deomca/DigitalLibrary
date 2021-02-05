using System.Data.SqlClient;
using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Text;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using DEFCCClass;
using DEFCCClass.MsSql;

public partial class Upload : System.Web.UI.Page
{
    string connectionString = ConfigurationManager.AppSettings["connString"].ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["mes"] == "true")
        {
            lblSuccessMessage.Visible = true;
        }
        else
        {
            lblSuccessMessage.Visible = false;
        }

        if (!IsPostBack)
        {

            if (Convert.ToInt16(Session["userType"]) > 0)
            {
                int userid = Convert.ToInt32(Session["UserId"]);
                int userType = Convert.ToInt32(Session["UserType"]);

                List<Division> listDivision = new DivisionPersist().GetAllDivisionByUserId(userid, userType);

                drpDivision.DataSource = listDivision;
                drpDivision.DataTextField = "Name";
                drpDivision.DataValueField = "DivisionId";
                drpDivision.DataBind();

                drpDivision.Items.Insert(0, "Select");

                

                BindGrid(null);



                List<Folder> listfolder = new FolderPersist().GetAllFoldersByUserId(Convert.ToInt32(Session["UserId"]), Convert.ToInt32(Session["UserType"]));

                drpFolder.DataSource = listfolder;
                drpFolder.DataTextField = "FolderName";
                drpFolder.DataValueField = "FolderId";
                drpFolder.DataBind();

             
                 
             

            }
            else
            {
                Response.Redirect("login.aspx");
            }

        }
    }
    protected void drpDivision_SelectedIndexChanged(object sender, EventArgs e)
    {
      

           int divisionid = Convert.ToInt32(drpDivision.SelectedValue);

            List<Range> listRange = new RangePersist().GetAllRangeByDivisionId(divisionid);

            drpRange.DataSource = listRange;
            drpRange.DataTextField = "RangeName";
            drpRange.DataValueField = "RangeId";
            drpRange.DataBind();

            drpRange.Items.Insert(0, "Select");
         
    }

    protected void drpRange_SelectedIndexChanged(object sender, EventArgs e)
    {
        int rangeid = Convert.ToInt32(drpRange.SelectedValue);

        List<Thana> listThana = new ThanaPersist().GetAllThanaByRangeId(rangeid);

        drpThana.DataSource = listThana;
        drpThana.DataTextField = "ThanaName";
        drpThana.DataValueField = "ThanaId";
        drpThana.DataBind();

        drpThana.Items.Insert(0, "Select");

           }

    protected void btnsave_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            try
            {
                string saveImagePath = ConfigurationManager.AppSettings["SaveImagePath"];
                string folderpath = drpFolder.SelectedItem.Text;
                string finalpath = saveImagePath + folderpath;

                if (!Directory.Exists(finalpath))
                {
                    DirectoryInfo di = Directory.CreateDirectory(finalpath);
                }

                string physicalSavePath = finalpath + "\\" + FileUpload1.FileName;

                FileUpload1.SaveAs(physicalSavePath);

                SqlConnection SqlConn = new SqlConnection(connectionString);

                SqlConn.Open();

                DateTime dt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));

                string query = "insert into dgl_thana_cadestralmap (thanaId,imagePath, Status,createdby,createddate,folderId) values (" + drpThana.SelectedValue + ",'" + FileUpload1.FileName + "','ACT','" + Session["UserName"] + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "'," + drpFolder.SelectedValue + ")";


                SqlCommand cmd = new SqlCommand(query, SqlConn);

                cmd.ExecuteNonQuery();

                SqlConn.Close();

                Response.Redirect("Upload.aspx?mes=true");

            }
            catch (Exception ex)
            {
                ex.ToString();
            }


        }

    }

    protected void grdUser_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
    {
        grdThanaMap.PageIndex = e.NewPageIndex;
        BindGrid();
    }

    public void BindGrid(string sortExpression = null)
    {
        using (SqlConnection SqlConn = new SqlConnection(connectionString))
        {
            using (SqlCommand cmdUser = new SqlCommand("GetThanaByUserId", SqlConn))
            {
                cmdUser.Parameters.Add(new SqlParameter("pUserId", SqlDbType.Int)).Value = Convert.ToInt32(Session["userId"]);
                cmdUser.Parameters.Add(new SqlParameter("pUserType", SqlDbType.Int)).Value = Convert.ToInt32(Session["userType"]);


                cmdUser.CommandType = CommandType.StoredProcedure;
                SqlConn.Open();

                SqlDataAdapter daUser = new SqlDataAdapter(cmdUser);
                DataTable dt = new DataTable();
                daUser.Fill(dt);

                if (sortExpression != null)
                {
                    DataView dv = dt.AsDataView();
                    this.SortDirection = this.SortDirection == "ASC" ? "DESC" : "ASC";

                    dv.Sort = sortExpression + " " + this.SortDirection;
                    grdThanaMap.DataSource = dv;
                }
                else
                {
                    grdThanaMap.DataSource = dt;
                }

                grdThanaMap.DataBind();
            }
        }
    }

    protected void grdUser_Sorting(object sender, System.Web.UI.WebControls.GridViewSortEventArgs e)
    {
        BindGrid(e.SortExpression);
    }

    private string SortDirection
    {
        get { return ViewState["SortDirection"] != null ? ViewState["SortDirection"].ToString() : "ASC"; }
        set { ViewState["SortDirection"] = value; }
    }

    protected void gvFiles_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Response.Clear();
        Response.ContentType = "application/octet-stream";
        Response.AppendHeader("Content-Disposition", "filename=" + e.CommandArgument);
        Response.Write(Server.MapPath("~/img/") + e.CommandArgument);
        Response.End();
    }

    protected void DownloadMap(object sender, EventArgs e)
    {
        string filePath = (sender as LinkButton).CommandArgument;
        string addPath = "img\\" + filePath;
        Response.ContentType = ContentType;
        Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
        Response.WriteFile(filePath);
        Response.End();
    }

    protected void lnkupload_Click(object sender, EventArgs e)
    {
        UploadMapSection.Visible = true;
        ViewMapSection.Visible = true;

    }
}