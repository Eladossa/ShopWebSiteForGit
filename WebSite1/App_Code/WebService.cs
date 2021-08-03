using Business_Logic_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService
{

    public WebService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }


    [WebMethod]
    public string AddProduct(string productName, string categoryName, double price,
            int stock, string productDescription,
                         string productOverview, string productImage)
    {
        return BLL.AddProduct(productName, categoryName, price,
         stock, productDescription, productOverview, productImage);
    }

    [WebMethod]
    public string ProductList()
    {
        return BLL.ProductList();
    }


}
