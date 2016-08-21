using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class add_product : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
            
         //   DropDownList ddList = (DropDownList).FindControl("DropDownList1");

        }
    }



    private void BindData()
    {
        
        SqlConnection con = new SqlConnection(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=test;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        SqlDataAdapter da = new SqlDataAdapter("SELECT * from product", con);
        DataTable dt = new DataTable();
        da.Fill(dt);
        GridView1.DataSource = dt;
             

        GridView1.DataBind();


    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        List<Category> c;
        IManagement im = new IManagement();
        c = im.getCategoryDetails();
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //Find the DropDownList in the Row

            DropDownList ddlCountries = (e.Row.FindControl("DropDownList1") as DropDownList);
            ddlCountries.DataTextField = "Name";
            ddlCountries.DataSource = c.ToList();
            ddlCountries.DataBind();

            //Add Default Item in the DropDownList
            ddlCountries.Items.Insert(0, new ListItem("Please select"));

            //Select the Country of Customer in DropDownList
            //string country = (e.Row.FindControl("lblCountry") as Label).Text;
            //ddlCountries.Items.FindByValue(country).Selected = true;
        }
    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        BindData();
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        BindData();
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Product p;
        String name = "helloname8";
        String colors = "hellocolor3";
        String desc = "hellodesc3";
        float price = 1200;
        int cat = 1001;
        p = new Product( name, desc, colors, price, cat);
        IManagement im = new IManagement();
        int prodId = im.addProductDetails(p);
        GridView1.EditIndex = -1;
        BindData();
        showalert(prodId);
    }

    public void showalert(int id)
    {
        Response.Write("<script> alert('" + id + "')</script>");
    }


    protected void btnAdd_Click(object sender, EventArgs e)
    {

        SqlConnection con = new SqlConnection(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=test;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        SqlDataAdapter da = new SqlDataAdapter("SELECT * from product", con);
        DataTable dt = new DataTable();
        da.Fill(dt);

        // Here we'll add a blank row to the returned DataTable
        DataRow dr = dt.NewRow();
        dt.Rows.InsertAt(dr, 0);
        //Creating the first row of GridView to be Editable
        GridView1.EditIndex = 0;
        GridView1.DataSource = dt;
        GridView1.DataBind();
        //Changing the Text for Inserting a New Record
        ((LinkButton)GridView1.Rows[0].Cells[0].Controls[0]).Text = "Insert";

    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        SqlConnection con = new SqlConnection(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=test;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "DELETE FROM quest_categories WHERE cat_id=@cat_id";
        cmd.Parameters.Add("@cat_id", SqlDbType.Int).Value = Convert.ToInt32(GridView1.Rows[e.RowIndex].Cells[1].Text);

        cmd.Connection = con;
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();

        BindData();

    }



   
}