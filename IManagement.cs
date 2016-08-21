using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for IManagement
/// </summary>
public class IManagement
{
    public IManagement()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public List<Category> getCategoryDetails()
    {
        SqlConnection con = new SqlConnection(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=test;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        con.Open();
        SqlCommand cmd = new SqlCommand();

        cmd = new SqlCommand("active_category", con);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataReader dr = cmd.ExecuteReader();
        List<Category> c = new List<Category>();
        Category cnew = new Category();
        while(dr.Read())
        {
            cnew = new Category( Convert.ToInt32(dr.GetValue(0)) , dr.GetValue(1).ToString());
            c.Add(cnew);
        }

        //sp a
        return c;
    }

    public int addProductDetails(Product p)
    {
        SqlConnection con = new SqlConnection(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=test;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        con.Open();
        SqlCommand cmd = new SqlCommand();
        
            cmd = new SqlCommand("add_product",con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("name", p.name));
            cmd.Parameters.Add(new SqlParameter("color", p.color));
            cmd.Parameters.Add(new SqlParameter("description", p.des));
            cmd.Parameters.Add(new SqlParameter("price", p.price));
            cmd.Parameters.Add(new SqlParameter("categoryId", p.categoryId));
            cmd.Parameters.AddWithValue("@productId" , SqlDbType.Int);
            cmd.Parameters["@productId"].Direction = ParameterDirection.Output;

            cmd.ExecuteNonQuery();

        int a = Convert.ToInt32(cmd.Parameters["@productId"].Value);

            return a;
    }

    public DataTable displayProducts()
    {
        SqlConnection con = new SqlConnection(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=test;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        con.Open();
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        try
        {
            cmd = new SqlCommand("get_product",con);
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            da.Fill(dt);
            
        }
        catch (Exception x)
        {
            
        }
        finally
        {
            cmd.Dispose();
            con.Close();
        }
        return dt;

    }

}