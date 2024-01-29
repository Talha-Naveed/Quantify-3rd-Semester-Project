using project.Business_Layer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.Data_Layer
{
    internal class AddVendor
    {
        public static void InputVendor(Vendor vendor)
        {
            string query = "Insert into Vendors ([Vendor Name], [Phone Number]) values ('"+vendor.VendorName+"', '"+vendor.VendorPhone+"')";

            SqlCommand cmd = new SqlCommand(query, Connection.GetConnection());
            cmd.ExecuteNonQuery();
        }
    }
}
