using Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Business_Logic_Layer
{
    public class BLL
    {

        public static string AddProduct(string productName, string categoryName, double price,
            int stock, string productDescription,
                         string productOverview, string productImage)
        {
            bool addProduct = DAL.AddProduct(productName, categoryName, price,
             stock, productDescription,
                          productOverview, productImage);
            return new JavaScriptSerializer().Serialize(addProduct);
        }

       // public static string ProductList2()

       //{
           // DataTable productsTable = DAL.GetProducts();
           // return DataTableToJson(productsTable);
        //}

        public static string ProductList()

        {
            DataTable productsTable = DAL.GetProducts();
            DataSet ds = new DataSet();
            ds.Merge(productsTable);

            List<Product> productsList = new List<Product>();

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {

                for (int i = 0; i < ds.Tables[0].Rows.Count ; i++)
                {
                    productsList.Add(new Product((int)ds.Tables[0].Rows[i]["ProductID"],
                        (string)ds.Tables[0].Rows[i]["ProductName"],
                        (string)ds.Tables[0].Rows[i]["CategoryName"], (float)ds.Tables[0].Rows[i]["Price"],
                        (int)ds.Tables[0].Rows[i]["Stock"], (string)ds.Tables[0].Rows[i]["ProductDescription"],
                        (string)ds.Tables[0].Rows[i]["ProductOverview"],
                        (string)ds.Tables[0].Rows[i]["ProductImage"])); 
                }
            }

            return new JavaScriptSerializer().Serialize(productsList);
        }
  


        public static string DataTableToJson(DataTable table)
        {
            var jsonString = new StringBuilder();
            if (table.Rows.Count > 0)
            {
                jsonString.Append("[");
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    jsonString.Append("{");
                    for (int j = 0; j < table.Columns.Count; j++)
                    {
                        if (j < table.Columns.Count - 1)
                        {
                            jsonString.Append("\"" + table.Columns[j].ColumnName.ToString()
                                              + "\":" + "\""
                                              + table.Rows[i][j].ToString() + "\",");
                        }
                        else if (j == table.Columns.Count - 1)
                        {
                            jsonString.Append("\"" + table.Columns[j].ColumnName.ToString()
                                              + "\":" + "\""
                                              + table.Rows[i][j].ToString() + "\"");
                        }
                    }
                    if (i == table.Rows.Count - 1)
                    {
                        jsonString.Append("}");
                    }
                    else
                    {
                        jsonString.Append("},");
                    }
                }
                jsonString.Append("]");
            }
            return jsonString.ToString();
        }
    }
}
