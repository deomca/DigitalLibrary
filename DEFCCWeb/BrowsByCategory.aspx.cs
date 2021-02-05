using System.Data.SqlClient;
using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
public partial class BrowsByCategory : System.Web.UI.Page
{
    string connectionString = ConfigurationManager.AppSettings["connString"].ToString();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SqlConnection SqlConn = new SqlConnection(connectionString);

            SqlConn.Open();
            SqlCommand SqlCmd;
            SqlDataAdapter da;

            SqlCmd = new SqlCommand("GetDivisionByUserId", SqlConn);
            SqlCmd.CommandType = CommandType.StoredProcedure;

            SqlCmd.Parameters.Add(new SqlParameter("pUserId", SqlDbType.Int)).Value = Convert.ToInt32(Session["userId"]);
            SqlCmd.Parameters.Add(new SqlParameter("pUserType", SqlDbType.Int)).Value = Convert.ToInt32(Session["userType"]);


            da = new SqlDataAdapter(SqlCmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            drpDivision.DataSource = dt;
            drpDivision.DataTextField = "Name";
            drpDivision.DataValueField = "DivisionId";
            drpDivision.DataBind();

            drpDivision.Items.Insert(0, "Select");
            SqlConn.Close();
        }
    }

    //protected void drpDivision_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    DataTable dt = BindRangeByDivisionId(Convert.ToInt16(drpDivision.SelectedItem.Value));

    //    drpRange.DataSource = dt;
    //    drpRange.DataTextField = "RangeName";
    //    drpRange.DataValueField = "RangeId";
    //    drpRange.DataBind();

    //    drpRange.Items.Insert(0, "Select");

    //}
    private DataTable BindRangeByDivisionId(int divisonId)
    {
        SqlConnection SqlConn = new SqlConnection(connectionString);

        SqlConn.Open();
        SqlCommand SqlCmd;
        SqlDataAdapter da;

        SqlCmd = new SqlCommand("GetRangeByDivisionId", SqlConn);
        SqlCmd.CommandType = CommandType.StoredProcedure;

        SqlCmd.Parameters.Add(new SqlParameter("pDivisionId", SqlDbType.Int)).Value = divisonId;

        da = new SqlDataAdapter(SqlCmd);
        DataTable dt = new DataTable();
        da.Fill(dt);


        return dt;
    }


    //protected void drpRange_SelectedIndexChanged(object sender, EventArgs e)
    //{

    //    DataTable dt = GetThanaByRangeId(Convert.ToInt16(drpRange.SelectedItem.Value));

    //    drpThana.DataSource = dt;
    //    drpThana.DataTextField = "ThanaName";
    //    drpThana.DataValueField = "ThanaId";
    //    drpThana.DataBind();

    //    drpThana.Items.Insert(0, "Select");


    //}

    protected void rdRangeChanged(object sender, EventArgs e)
    {
        //drpDivision.SelectedValue = "0";
        //drpThana.SelectedValue = "0";

        rdRange.Checked = true;
        divRange.Visible = true;

        rdDivision.Checked = false;
        rdThana.Checked = false;
        divThana.Visible = false;
        divDivision.Visible = false;

       

        DataTable dt = BindAllRange();

        drpRange.DataSource = dt;
        drpRange.DataTextField = "RangeName";
        drpRange.DataValueField = "RangeId";
        drpRange.DataBind();

        drpRange.Items.Insert(0, "Select");

        drpThana.DataSource = new DataTable();      
        drpThana.DataBind();

        drpDivision.DataSource = new DataTable();
        drpDivision.DataBind();

    }

    protected void rdThanaChanged(object sender, EventArgs e)
    {
        //drpDivision.SelectedValue = "0";
        //drpRange.SelectedValue = "0";

        rdThana.Checked = true;
        divThana.Visible = true;

        rdDivision.Checked = false;
        rdRange.Checked = false;
        divThana.Visible = true;
        divDivision.Visible = false;
        divRange.Visible = false;

       
        DataTable dt = BindAllThana();

        drpThana.DataSource = dt;
        drpThana.DataTextField = "ThanaName";
        drpThana.DataValueField = "ThanaId";
        drpThana.DataBind();

        drpThana.Items.Insert(0, "Select");

        drpRange.DataSource = new DataTable();       
        drpRange.DataBind();

        drpDivision.DataSource = new DataTable();
        drpDivision.DataBind();

    }
    protected void rdDivisionChanged(object sender, EventArgs e)
    {
        //drpRange.SelectedValue = "0";
        //drpThana.SelectedValue = "0";

        rdDivision.Checked = true;
        divDivision.Visible = true;

        rdThana.Checked = false;
        rdRange.Checked = false;
        divThana.Visible = false;
        divDivision.Visible = true;
        divRange.Visible = false;

        

        DataTable dt = BindAllDivision();

        drpDivision.DataSource = dt;
        drpDivision.DataTextField = "Name";
        drpDivision.DataValueField = "DivisionId";
        drpDivision.DataBind();

        drpDivision.Items.Insert(0, "Select");

        drpRange.DataSource = new DataTable();       
        drpRange.DataBind();

        drpThana.DataSource = new DataTable();
        drpThana.DataBind();

    }
    private DataTable BindAllDivision()
    {
        SqlConnection SqlConn = new SqlConnection(connectionString);

        SqlConn.Open();
        SqlCommand SqlCmd;
        SqlDataAdapter da;

        SqlCmd = new SqlCommand("GetAllDivision", SqlConn);
        SqlCmd.CommandType = CommandType.StoredProcedure;

        da = new SqlDataAdapter(SqlCmd);
        DataTable dt = new DataTable();
        da.Fill(dt);

        return dt;
    }

    private DataTable BindAllThana()
    {
        SqlConnection SqlConn = new SqlConnection(connectionString);

        SqlConn.Open();
        SqlCommand SqlCmd;
        SqlDataAdapter da;

        SqlCmd = new SqlCommand("GetAllThana", SqlConn);
        SqlCmd.CommandType = CommandType.StoredProcedure;

        da = new SqlDataAdapter(SqlCmd);
        DataTable dt = new DataTable();
        da.Fill(dt);

        return dt;
    }

    private DataTable BindAllRange()
    {
        SqlConnection SqlConn = new SqlConnection(connectionString);

        SqlConn.Open();
        SqlCommand SqlCmd;
        SqlDataAdapter da;

        SqlCmd = new SqlCommand("GetAllRange", SqlConn);
        SqlCmd.CommandType = CommandType.StoredProcedure;

        da = new SqlDataAdapter(SqlCmd);
        DataTable dt = new DataTable();
        da.Fill(dt);

        return dt;
    }

    private DataTable GetThanaByRangeId(int RangeId)
    {
        SqlConnection SqlConn = new SqlConnection(connectionString);

        SqlConn.Open();
        SqlCommand SqlCmd;
        SqlDataAdapter da;

        SqlCmd = new SqlCommand("GetThanaByRangeId", SqlConn);
        SqlCmd.CommandType = CommandType.StoredProcedure;

        SqlCmd.Parameters.Add(new SqlParameter("pRangeId", SqlDbType.Int)).Value = RangeId;

        da = new SqlDataAdapter(SqlCmd);
        DataTable dt = new DataTable();
        da.Fill(dt);

        return dt;
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (drpDivision.SelectedValue != "0" && (drpRange.SelectedValue == "" || drpRange.SelectedValue == "Select") && (drpThana.SelectedValue == "" || drpThana.SelectedValue == "Select"))
        {
            SqlConnection SqlConn = new SqlConnection(connectionString);

            SqlConn.Open();
            SqlCommand SqlCmd;
            SqlDataAdapter da;

            SqlCmd = new SqlCommand("SearchRange", SqlConn);
            SqlCmd.CommandType = CommandType.StoredProcedure;

            SqlCmd.Parameters.Add(new SqlParameter("@pDivisionId", SqlDbType.Int)).Value = drpDivision.SelectedValue;
            SqlCmd.Parameters.Add(new SqlParameter("@pRangeId", SqlDbType.Int)).Value = 0;
            SqlCmd.Parameters.Add(new SqlParameter("@pThanaId", SqlDbType.Int)).Value = 0;

            da = new SqlDataAdapter(SqlCmd);
            DataTable dt = new DataTable();
            da.Fill(dt);


            //Building an HTML string.
            StringBuilder html = new StringBuilder();

            //Table start.
            html.Append("<table border = '0'>");

            //Building the Data rows.
            foreach (DataRow row in dt.Rows)
            {
                html.Append("<tr>");
                html.Append("<td>");
                html.Append(row["Name"]);
                html.Append("</td>");
                html.Append("</tr>");

                html.Append("<tr>");
                html.Append("<td style='padding-left:50px;padding-top:20px;'>");

                DataTable dtRange = BindRangeByDivisionId(Convert.ToInt16(row["DivisionId"]));

                html.Append("<table id='tblRange' border = '0'>");

                foreach (DataRow row2 in dtRange.Rows)
                {
                    html.Append("<tr>");
                    html.Append("<td>");
                    html.Append(row2["RangeName"]);
                    html.Append("</td>");
                    html.Append("</tr>");

                    html.Append("<tr>");
                    html.Append("<td style='padding-left:50px;padding-top:20px;'>");

                    DataTable dtthana = GetThanaByRangeId(Convert.ToInt16(row2["RangeId"]));

                    html.Append("<table id='tbleThana' border = '0'>");

                    foreach (DataRow row3 in dtthana.Rows)
                    {
                        html.Append("<tr>");
                        html.Append("<td'>");
                        html.Append(row3["ThanaName"]);
                        html.Append("</td>");
                        html.Append("</tr>");

                        html.Append("<tr>");
                        html.Append("<td style='padding-left:50px;padding-top:20px;'>");

                        DataTable dtthana1 = GetAllFilesByThanaId(Convert.ToInt16(row3["ThanaId"]));

                        html.Append("<table id='tbleThana' border = '0'>");

                        html.Append("<tr>");
                        foreach (DataRow row4 in dtthana1.Rows)
                        {

                            html.Append("<td id='" + row4["ThanaMapId"] + "' width='150px'>");
                            string imagepath = "<Image ID='thanaMap' src='" + row4["Imagepath"] + "' Height='100px' Width='100px' />";
                            html.Append(imagepath);
                            html.Append("</td>");

                        }
                        html.Append("</tr>");
                        html.Append("</table>");
                        html.Append("</td>");
                        html.Append("</tr>");
                    }

                    html.Append("</table>");

                    html.Append("</td>");

                    html.Append("</tr>");
                }



                html.Append("</table>");

                html.Append("</td>");

                html.Append("</tr>");
            }

            //Table end.
            html.Append("</table>");

            //Append the HTML string to Placeholder.
            plcHolder.Controls.Add(new Literal { Text = html.ToString() });

        }
        else if ((drpDivision.SelectedValue == "" || drpDivision.SelectedValue == "Select") && drpRange.SelectedValue != "0" && (drpThana.SelectedValue == "" || drpThana.SelectedValue == "Select"))
        {
            SqlConnection SqlConn = new SqlConnection(connectionString);

            SqlConn.Open();
            SqlCommand SqlCmd;
            SqlDataAdapter da;

            SqlCmd = new SqlCommand("SearchRange", SqlConn);
            SqlCmd.CommandType = CommandType.StoredProcedure;

            SqlCmd.Parameters.Add(new SqlParameter("@pDivisionId", SqlDbType.Int)).Value = 0;
            SqlCmd.Parameters.Add(new SqlParameter("@pRangeId", SqlDbType.Int)).Value = drpRange.SelectedValue;
            SqlCmd.Parameters.Add(new SqlParameter("@pThanaId", SqlDbType.Int)).Value = 0;

            da = new SqlDataAdapter(SqlCmd);
            DataTable dt = new DataTable();
            da.Fill(dt);


            //Building an HTML string.
            StringBuilder html = new StringBuilder();

            //Table start.
            html.Append("<table border = '0'>");

            //Building the Data rows.
            foreach (DataRow row in dt.Rows)
            {
                html.Append("<tr>");
                html.Append("<td>");
                html.Append(row["RangeName"]);
                html.Append("</td>");
                html.Append("</tr>");

                html.Append("<tr>");
                html.Append("<td style='padding-left:50px;padding-top:20px;'>");

                //DataTable dtRange = BindRangeByDivisionId(Convert.ToInt16(row["DivisionId"]));

                //html.Append("<table id='tblRange' border = '0'>");

                //foreach (DataRow row2 in dtRange.Rows)
                //{
                //    html.Append("<tr>");
                //    html.Append("<td>");
                //    html.Append(row2["RangeName"]);
                //    html.Append("</td>");
                //    html.Append("</tr>");

                //    html.Append("<tr>");
                //    html.Append("<td style='padding-left:50px;padding-top:20px;'>");

                DataTable dtthana = GetThanaByRangeId(Convert.ToInt16(row["RangeId"]));

                html.Append("<table id='tbleThana' border = '0'>");

                foreach (DataRow row3 in dtthana.Rows)
                {
                    html.Append("<tr>");
                    html.Append("<td'>");
                    html.Append(row3["ThanaName"]);
                    html.Append("</td>");
                    html.Append("</tr>");

                    html.Append("<tr>");
                    html.Append("<td style='padding-left:50px;padding-top:20px;'>");

                    DataTable dtthana1 = GetAllFilesByThanaId(Convert.ToInt16(row3["ThanaId"]));

                    html.Append("<table id='tbleThana' border = '0'>");

                    html.Append("<tr>");
                    foreach (DataRow row4 in dtthana1.Rows)
                    {

                        html.Append("<td id='" + row4["ThanaMapId"] + "' width='150px'>");
                        string imagepath = "<Image ID='thanaMap' src='" + row4["Imagepath"] + "' Height='100px' Width='100px' />";
                        html.Append(imagepath);
                        html.Append("</td>");

                    }
                    html.Append("</tr>");
                    html.Append("</table>");
                    html.Append("</td>");
                    html.Append("</tr>");
                }

                //    html.Append("</table>");

                //    html.Append("</td>");

                //    html.Append("</tr>");
                //}



                html.Append("</table>");

                html.Append("</td>");

                html.Append("</tr>");
            }

            //Table end.
            html.Append("</table>");

            //Append the HTML string to Placeholder.
            plcHolder.Controls.Add(new Literal { Text = html.ToString() });
        }
        else if ((drpDivision.SelectedValue == "" || drpDivision.SelectedValue == "Select") && (drpRange.SelectedValue == "" || drpRange.SelectedValue == "Select") && drpThana.SelectedValue != "0")
        {
            SqlConnection SqlConn = new SqlConnection(connectionString);

            SqlConn.Open();
            SqlCommand SqlCmd;
            SqlDataAdapter da;

            SqlCmd = new SqlCommand("SearchRange", SqlConn);
            SqlCmd.CommandType = CommandType.StoredProcedure;

            SqlCmd.Parameters.Add(new SqlParameter("@pDivisionId", SqlDbType.Int)).Value = 0;
            SqlCmd.Parameters.Add(new SqlParameter("@pRangeId", SqlDbType.Int)).Value = 0;
            SqlCmd.Parameters.Add(new SqlParameter("@pThanaId", SqlDbType.Int)).Value = drpThana.SelectedValue;

            da = new SqlDataAdapter(SqlCmd);
            DataTable dt = new DataTable();
            da.Fill(dt);


            //Building an HTML string.
            StringBuilder html = new StringBuilder();

            //Table start.
            html.Append("<table border = '0'>");

            //Building the Data rows.
            foreach (DataRow row in dt.Rows)
            {
                html.Append("<tr>");
                html.Append("<td>");
                html.Append(row["ThanaName"]);
                html.Append("</td>");
                html.Append("</tr>");

                html.Append("<tr>");
                html.Append("<td style='padding-left:50px;padding-top:20px;'>");

                //DataTable dtRange = BindRangeByDivisionId(Convert.ToInt16(row["DivisionId"]));

                //html.Append("<table id='tblRange' border = '0'>");

                //foreach (DataRow row2 in dtRange.Rows)
                //{
                //    html.Append("<tr>");
                //    html.Append("<td>");
                //    html.Append(row2["ThanaName"]);
                //    html.Append("</td>");
                //    html.Append("</tr>");

                //    html.Append("<tr>");
                //    html.Append("<td style='padding-left:50px;padding-top:20px;'>");

                //DataTable dtthana = GetThanaByRangeId(Convert.ToInt16(row2["RangeId"]));

                //html.Append("<table id='tbleThana' border = '0'>");

                //foreach (DataRow row3 in dtthana.Rows)
                //{
                //    html.Append("<tr>");
                //    html.Append("<td'>");
                //    html.Append(row3["ThanaName"]);
                //    html.Append("</td>");
                //    html.Append("</tr>");

                //    html.Append("<tr>");
                //    html.Append("<td style='padding-left:50px;padding-top:20px;'>");

                DataTable dtthana1 = GetAllFilesByThanaId(Convert.ToInt16(row["ThanaId"]));

                html.Append("<table id='tbleThana' border = '0'>");

                html.Append("<tr>");
                foreach (DataRow row4 in dtthana1.Rows)
                {

                    html.Append("<td id='" + row4["ThanaMapId"] + "' width='200px'>");
                    string imagepath = "<Image ID='thanaMap' src='" + row4["Imagepath"] + "' Height='200px' Width='200px' />";
                    html.Append(imagepath);
                    html.Append("</td>");

                }
                html.Append("</tr>");
                html.Append("</table>");
                html.Append("</td>");
                html.Append("</tr>");
                //  }

                // html.Append("</table>");

                //html.Append("</td>");

                //html.Append("</tr>");
                //   }

                //html.Append("</table>");
                //html.Append("</td>");
                //html.Append("</tr>");
            }

            //Table end.
            html.Append("</table>");

            //Append the HTML string to Placeholder.
            plcHolder.Controls.Add(new Literal { Text = html.ToString() });
        }
    }

    private DataTable GetAllFilesByThanaId(int thanaId)
    {
        SqlConnection SqlConn = new SqlConnection(connectionString);

        SqlConn.Open();
        SqlCommand SqlCmd;
        SqlDataAdapter da;

        SqlCmd = new SqlCommand("GetAllFilesByThanaId", SqlConn);
        SqlCmd.CommandType = CommandType.StoredProcedure;

        SqlCmd.Parameters.Add(new SqlParameter("@pThanaId", SqlDbType.Int)).Value = thanaId;

        da = new SqlDataAdapter(SqlCmd);
        DataTable dt = new DataTable();
        da.Fill(dt);

        return dt;
    }

    /*
    private List<Range> GetAllRangeByDivisionId(int DivisionId)
    {
        List<Range> listRange = new List<Range>();

        DataTable dt = BindRangeByDivisionId(DivisionId);

        foreach (DataRow dr in dt.Rows)
        {
            Range range = new Range();

            range.RangeId = Convert.ToInt16(dr["RangeId"]);
            range.RangeName = dr["RangeName"].ToString();

            listRange.Add(range);
        }
        return listRange;
    }

    private List<Thana> GetAllThanaBtRangeId(int RangeId)
    {
        List<Thana> listThana = new List<Thana>();

        DataTable dt = BindRangeByDivisionId(RangeId);

        foreach (DataRow dr in dt.Rows)
        {
            Thana thana = new Thana();

            thana.ThanaId = Convert.ToInt16(dr["ThanaId"]);
            thana.ThanaName = dr["ThanaName"].ToString();

            listThana.Add(thana);
        }
        return listThana;
    }
     * */
}