using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class view_inventory : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null)
        {
            Response.Redirect("login.aspx");
            
        }

        DataTable dt = new DataTable();
        IManagement im = new IManagement();
        dt = im.displayProducts();
        myGrid.DataSource = dt;
        myGrid.DataBind();

    }
}