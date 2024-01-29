using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.Data_Layer
{
    internal class TabInventory
    {
        public static DataTable SearchProductNameInDatabase(string searchText)
        {
            DataTable table = new DataTable();
            string query = "SELECT * FROM Products WHERE [Product ID] LIKE '%' + @searchText + '%' OR [Product Name] LIKE '%' + @searchText + '%';";
            SqlCommand command = new SqlCommand(query, Connection.GetConnection());
            command.Parameters.AddWithValue("@searchText", searchText);
            SqlDataAdapter adapter = new SqlDataAdapter(command);

            //Need work here
            adapter.Fill(table);
            return table;
        }
    }
}
