using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Category
/// </summary>
public class Category
{

    private int categoryId;
    private String name;
    public Category()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public Category(int CategoryId, String Name)
    {
        this.CategoryId = CategoryId;
        this.Name = Name;
    }

    public int CategoryId
    {
        get
        {
            return categoryId;
        }

        set
        {
            categoryId = value;
        }
    }

    public string Name
    {
        get
        {
            return name;
        }

        set
        {
            name = value;
        }
    }
}