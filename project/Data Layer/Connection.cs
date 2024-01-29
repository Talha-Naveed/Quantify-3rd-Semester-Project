using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using project.Presentation_Layer;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using project.Business_Layer;
using System.Data.SqlTypes;

namespace project.Data_Layer
{
    internal static class Connection
    {
        public static SqlConnection GetConnection()
        {
            //Taha Connection String
            //string connection_string = "Data Source=XPERTFN\\SQLEXPRESS;Initial Catalog=AliUniformCenterDB;Integrated Security=True;";


            //Talha Connection string
            string connection_string = "Data Source=TALHA\\SQLEXPRESS;Initial Catalog=Project;Integrated Security=True;";

            SqlConnection connection = new SqlConnection(connection_string);
            connection.Open();
            

            return connection;
        }
        public static SqlDataReader SearchProductIdInDatabase(string searchText)
        {
            string query = "SELECT [Product ID], [Product Name], [Product Price] FROM Products WHERE [Product ID] ='" + searchText + "';";
            SqlCommand command = new SqlCommand(query, Connection.GetConnection());
            SqlDataReader reader = command.ExecuteReader();
            return reader;
        }

        public static DataTable SearchProductNameInDatabase(string searchText)
        {
            DataTable table = new DataTable();

            string query = "SELECT [Product ID], [Product Name], [Product Description], [Quantity Available], [Product Price], [Vendor Name] FROM Products WHERE [Product ID] LIKE '%' + @searchText + '%' OR [Product Name] LIKE '%' + @searchText + '%';";
            SqlCommand command = new SqlCommand(query, Connection.GetConnection());

            command.Parameters.AddWithValue("@searchText", searchText);

            SqlDataAdapter adapter = new SqlDataAdapter(command);

            //Work here too
            adapter.Fill(table);

            return table;

        }

        public static int GetProductQty(string productID)
        {
            
            int Qty = 0;

            DataTable table = new DataTable();

            string query = "SELECT [Quantity Available] FROM Products WHERE [Product ID] = '"+productID+"'  ";
            SqlCommand sqlCommand = new SqlCommand(query, Connection.GetConnection());
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(table);

            if(table.Rows.Count > 0)
            {
                Qty = int.Parse(table.Rows[0]["Quantity Available"].ToString());
            }

            return Qty;
        }

        public static bool UpdateQty(string productID, int Qty)
        {
            bool Found = false;

            
            string query = "update Products set [Quantity Available] = @Qty where [Product ID] = @productID;";
            SqlCommand sqlCommand = new SqlCommand(query, Connection.GetConnection());
            sqlCommand.Parameters.AddWithValue("@Qty", Qty);
            sqlCommand.Parameters.AddWithValue("@productID", productID);

            int rows = sqlCommand.ExecuteNonQuery();
            if(rows > 0)
            {
                Found = true;
            }
            else
            { 
                Found = false; 
            }

            return Found;
        }
        public static bool IncreaseQty(string productID, int IncreaseQty)
        {
            bool Found = false;

            

            int currentQty = GetProductQty(productID);
            
            int NewQty = currentQty + IncreaseQty;
            Found =UpdateQty(productID, NewQty);

            return Found;
        }
        public static bool DecreaseQty(string productID, int DecreaseQty)
        {
            bool Found = false;

            
            
            int currentQty = GetProductQty(productID);

            int NewQty = currentQty - DecreaseQty;
            Found = UpdateQty(productID, NewQty);

            return Found;
        }

    }
}
