using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer
{
    public class DAL
    {

        private static string connetionString = "Data Source=ELAD_HA\\SQLEXPRESS;Initial Catalog=SupplementsStore;Integrated Security=True";



        public static bool AddProduct(string productName, string categoryName, double price,
            int stock, string productDescription,
                         string productOverview, string productImage)
        {
            System.Data.SqlClient.SqlConnection conn = new SqlConnection(connetionString);
            SqlDataAdapter adapter;
            SqlCommand comm;
            try
            {
                conn.Open();
                comm = new SqlCommand("InsertProduct", conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add(new SqlParameter("productName", productName));
                comm.Parameters.Add(new SqlParameter("CategoryName", categoryName));
                comm.Parameters.Add(new SqlParameter("Price", price));
                comm.Parameters.Add(new SqlParameter("Stock", stock));
                comm.Parameters.Add(new SqlParameter("ProductDescription", productDescription));
                comm.Parameters.Add(new SqlParameter("ProductOverview", productOverview));
                comm.Parameters.Add(new SqlParameter("ProductImage", productImage));

                adapter = new SqlDataAdapter(comm);
                DataSet dataset = new DataSet();
                adapter.Fill(dataset, "products");
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

            }
        }
        public static DataTable GetProducts()
        {
            SqlConnection conn = new SqlConnection(connetionString);
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand command;
            try
            {
                conn.Open();
                command = new SqlCommand("SELECT * FROM AllProducts", conn);
                adapter.SelectCommand = command;
                DataSet dataset = new DataSet();
                adapter.Fill(dataset, "products");

                if (dataset.Tables["Products"].Rows.Count != 0)
                {
                    return dataset.Tables["Products"];
                }
                return null;

            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

            }
        }
    }
}
