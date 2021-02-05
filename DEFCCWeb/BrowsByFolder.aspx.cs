using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;

public partial class BrowsByList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            DataTable dt = this.GetData("SELECT folderId, FolderName,ParentId FROM dgl_folder WHERE ParentId = 0");
            this.PopulateTreeView(dt, 0, null);
        }
    }

    private void PopulateTreeView(DataTable dtParent, int parentId, TreeNode treeNode)
    {
        foreach (DataRow row in dtParent.Rows)
        {
            TreeNode child = new TreeNode
            {
                Text = row["FolderName"].ToString(),
                Value = row["folderId"].ToString()
            };

            if (parentId == 0)
            {
                TreeView1.Nodes.Add(child);
                DataTable dtChild = this.GetData("SELECT folderId, FolderName,ParentId FROM dgl_folder WHERE ParentId = " + Convert.ToInt16(child.Value));

                PopulateTreeView(dtChild, Convert.ToInt16(child.Value), child);


            }
            else
            {
                treeNode.ChildNodes.Add(child);
                DataTable dtChild = this.GetData("SELECT folderId, FolderName,ParentId FROM dgl_folder WHERE ParentId = " + Convert.ToInt16(child.Value));

                PopulateTreeView(dtChild, Convert.ToInt16(child.Value), child);

            }


        }
    }


    private DataTable GetData(string query)
    {
        DataTable dt = new DataTable();
        string constr = ConfigurationManager.AppSettings["connString"];
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand(query))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    sda.Fill(dt);
                }
            }
            return dt;
        }
    }

    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
        string connectionString = ConfigurationManager.AppSettings["connString"];
        string imagePath = ConfigurationManager.AppSettings["GetImagePath"];

        SqlConnection SqlConn = new SqlConnection(connectionString);

        SqlConn.Open();
        SqlCommand SqlCmd;
        SqlDataAdapter da;

        string query = "Select map.Imagepath,map.ThanaMapid,folder.foldername from dgl_thana_cadestralmap map join dgl_folder folder on  folder.folderid=map.folderid where map.folderid=" + TreeView1.SelectedNode.Value;

        SqlCmd = new SqlCommand(query, SqlConn);

        da = new SqlDataAdapter(SqlCmd);
        DataTable dt = new DataTable();
        da.Fill(dt);


        //Building an HTML string.
        StringBuilder html = new StringBuilder();

        //Table start.
        html.Append("<table id='tbleThana' border = '0'>");

        html.Append("<tr>");

        //Building the Data rows.
        foreach (DataRow row in dt.Rows)
        {
            html.Append("<td id='" + row["ThanaMapId"] + "' width='200px'>");

            string imagepath = "<Image ID='thanaMap' src='" + imagePath + row["foldername"] + "\\" + row["Imagepath"] + "' Height='200px' Width='200px' />";

            html.Append(imagepath);
            html.Append("</td>");

        }
        html.Append("</tr>");
        html.Append("</table>");

        plcHolder.Controls.Add(new Literal { Text = html.ToString() });

    }
}