using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SiteMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserId"] != null)
        {
            lnkLogout.Visible = true;
           
        }
        
        else
        {
            categoryview.Visible = false;
            folderview.Visible = false;
            upload.Visible = false;
        }
    }
    protected void logout_click(object sender, EventArgs e)
    {
        Session["UserId"] = null;
        Session["userType"] = null;
        Session["UserName"] = null;

        Response.Redirect("Login.aspx");
    }
}
