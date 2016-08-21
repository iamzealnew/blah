using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Product
/// </summary>
public class Product
{
    
    public String name;
    public String des;
    public string color;
    public float price;
    public int categoryId;
    public Product()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public Product(String name,String des, string color,float price,int categoryId )
    {

        
        this.name = name;
        this.des = des;
        this.color = color;
        this.price = price;
        this.categoryId = categoryId;

    }
}