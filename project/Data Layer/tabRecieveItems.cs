using project.Business_Layer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project.Data_Layer
{
    internal class tabRecieveItems
    {
        public static void InsertInventory(Product product)
        {
            string query = "Insert into Products ([Product ID], [Product Name], [Product Description], [Quantity Available], [Product Price], [Product Price], [Vendor Name]) " +
                "values ('" + product.ProductID + "', '" + product.ProductName + "', '" + product.ProductDescription + "', '" + product.ProductQuantityAvailable + "', '" + product.ProductBuyingPrice + "', '" + product.ProductSellingPrice + "', '" + product.ProductVendorName + "');";

            SqlCommand cmd = new SqlCommand(query, Connection.GetConnection());
            cmd.ExecuteNonQuery();

        }

        public static List<string> GetVendorNames()
        {
            string query = "Select [Vendor Name] from Vendors;";
            List<string> list = new List<string>();

            SqlCommand cmd = new SqlCommand(query, Connection.GetConnection());
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(reader[0].ToString());
            }

            return list;
        }
    }
}
