using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DEFCCClass;
using DEFCCClass.MsSql;

public partial class Login : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userId"] != null)
        {
            Response.Redirect("index.aspx");
        }
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtUserName.Text) && !string.IsNullOrEmpty(txtPassword.Text))
        {
            User userModel = new User();

            userModel.UserName = txtUserName.Text.Trim();
            userModel.Password = txtPassword.Text.Trim();

            UserPersist userPersist = new UserPersist();

            User LoggedInUser = userPersist.CheckValidUser(userModel);

            if (LoggedInUser.UserId > 0)
            {
                Session["UserId"] = LoggedInUser.UserId;
                Session["UserType"] = LoggedInUser.UserType;
                Session["UserName"] = LoggedInUser.UserName;
            }
            else
            {
                lblmessage.Text = "Please provide valid User Name / Password";
            }

            if (Convert.ToInt16(Session["userType"]) > 0)
            {
                Response.Redirect("index.aspx");
            }
            else if (Convert.ToInt16(Session["userType"]) < 0)
            {
                Response.Redirect("UploadDivision.aspx");
            }
        }
        
    }
}