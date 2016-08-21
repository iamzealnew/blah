using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void submit_Click(object sender, EventArgs e)
    {
        if (username.Text == "shikhar" && password.Text == "admin")
        {
            Session["user"] = username.Text;
            Response.Redirect("Dashboard.aspx");
        }
    }
}