using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public float Price { get; set; }
        public int Stock { get; set; }
        public string ProductDescription { get; set; }
        public string ProductOverview { get; set; }
        public string ProductImage { get; set; }
   

    public Product(int productID, string productName, string categoryName, float price,
            int stock, string productDescription,
                         string productOverview, string productImage)
    {
        ProductID = productID;
        ProductName = productName;
        CategoryName = categoryName;
        Price = price;
        Stock = stock;
        ProductDescription = productDescription;
        ProductOverview = productOverview;
        ProductImage = productImage;

    }
}
}