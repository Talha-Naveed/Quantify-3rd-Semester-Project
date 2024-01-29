using project.Business_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.Data_Layer
{
    internal static class DALTransactionDetails
    {

        public static SqlConnection GetConnection()
        {
            //Taha Connection String
            string connection_string = "Data Source=TALHA\\SQLEXPRESS;Initial Catalog=Project;Integrated Security=True;";

            SqlConnection connection = new SqlConnection(connection_string);

            return connection;
        }
        public static bool SaveTransactionWithProfit(Transaction transaction, Customer customer)
        {
            SqlConnection connection = GetConnection();
            connection.Open();

            // Start a transaction
            using (SqlTransaction sqlTransaction = connection.BeginTransaction())
            {
                try
                {
                    int customerID = GetCustomerID(connection, sqlTransaction, customer);

                    if (customerID == -1)
                    {
                        // Handle the case where the customer does not exist
                        throw new InvalidOperationException("Customer not found.");
                    }

                    string transactionQuery = "INSERT INTO Transactions ([Customer ID], [Transaction Date], [Grand Total]) VALUES (@CustomerID, @TransactionDate, @GrandTotal); SELECT SCOPE_IDENTITY();";
                    SqlCommand transactionCommand = new SqlCommand(transactionQuery, connection, sqlTransaction);

                    transactionCommand.Parameters.AddWithValue("@CustomerID", customerID);
                    transactionCommand.Parameters.AddWithValue("@TransactionDate", transaction.TransactionDate);
                    transactionCommand.Parameters.AddWithValue("@GrandTotal", transaction.GrandTotal);

                    // Get the generated Transaction ID
                    int transactionID = Convert.ToInt32(transactionCommand.ExecuteScalar());

                    // Insert the associated invoices
                    foreach (var invoice in transaction.Invoices)
                    {
                        string invoiceQuery = "INSERT INTO Invoice ([Transaction ID], [Product ID], [Product Quantity],[Sub Total]) VALUES (@TransactionID, @ProductID, @ProductQuantity, @SubTotal);";
                        SqlCommand invoiceCommand = new SqlCommand(invoiceQuery, connection, sqlTransaction);

                        invoiceCommand.Parameters.AddWithValue("@TransactionID", transactionID);
                        invoiceCommand.Parameters.AddWithValue("@ProductID", invoice.ProductID);
                        invoiceCommand.Parameters.AddWithValue("@ProductQuantity", invoice.ProductQuantity);
                        invoiceCommand.Parameters.AddWithValue("@SubTotal", invoice.SubTotal);

                        invoiceCommand.ExecuteNonQuery();

                        Profit profit = CalculateProfit(invoice.ProductID,invoice.ProductQuantity);
                        StoreProfitInDatabase(profit);
                    }

                    sqlTransaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    sqlTransaction.Rollback();
                    return false;
                }
            }
        }

        public static int InsertCustomer(string fullname)
        {
            SqlConnection connection = GetConnection();
            connection.Open();

            string insertCustomerQuery = "INSERT INTO Customers ([Customer Name]) VALUES (@CustomerName); SELECT SCOPE_IDENTITY();";
            SqlCommand insertCustomerCommand = new SqlCommand(insertCustomerQuery, connection);

            insertCustomerCommand.Parameters.AddWithValue("@CustomerName", fullname);

            int customerID = Convert.ToInt32(insertCustomerCommand.ExecuteScalar());

            return customerID;
        }



        public static int GetCustomerID()
        {
            string query = "Select next value for AutoCustomerID;";
            SqlCommand cmd = new SqlCommand(query, Connection.GetConnection());
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                return int.Parse(reader[0].ToString());
            }

            // Incase of error value to be returned is zero for further error handling.
            return 0;
        }

        private static int GetCustomerID(SqlConnection connection, SqlTransaction sqlTransaction, Customer customer)
        {
            // Check if the customer already exists based on the full name
            string checkCustomerQuery = "SELECT [Customer ID] FROM Customers WHERE [Customer Name] = @CustomerName";
            SqlCommand checkCustomerCommand = new SqlCommand(checkCustomerQuery, connection, sqlTransaction);
            checkCustomerCommand.Parameters.AddWithValue("@CustomerName", customer.CustomerName);

            object existingCustomerID = checkCustomerCommand.ExecuteScalar();

            if (existingCustomerID != null)
            {
                // Customer already exists, return the existing Customer ID
                return Convert.ToInt32(existingCustomerID);
            }
            else
            {
                // Customer not found
                return -1;
            }

        }
        // Profit
        public static void StoreProfitInDatabase(Profit profit)
        {
            // Insert profit information into the Profit table
            string profitQuery = "INSERT INTO Profit (ProductID, QuantitySold, SellingPrice, BuyingPrice, TotalProfit) VALUES (@ProductID, @QuantitySold, @SellingPrice, @BuyingPrice, @TotalProfit)";
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                SqlCommand profitCommand = new SqlCommand(profitQuery, connection);
                profitCommand.Parameters.AddWithValue("@ProductID", profit.ProductID);
                profitCommand.Parameters.AddWithValue("@QuantitySold", profit.QuantitySold);
                profitCommand.Parameters.AddWithValue("@SellingPrice", profit.SellingPrice);
                profitCommand.Parameters.AddWithValue("@BuyingPrice", profit.BuyingPrice);
                profitCommand.Parameters.AddWithValue("@TotalProfit", profit.TotalProfit);

                profitCommand.ExecuteNonQuery();
            }
        }
        public static Profit CalculateProfit(string productID, int quantitySold)
        {
            decimal buyingPrice = GetBuyingPrice(productID);
            decimal sellingPrice = GetSellingPrice(productID);

            // Calculate profit
            decimal totalBuyingPrice = buyingPrice * quantitySold;
            decimal totalSellingPrice = sellingPrice * quantitySold;
            decimal totalProfit = totalSellingPrice - totalBuyingPrice;

            // Create Profit object
            Profit profit = new Profit
            {
                ProductID = productID,
                QuantitySold = quantitySold,
                SellingPrice = totalSellingPrice,
                BuyingPrice = totalBuyingPrice,
                TotalProfit = totalProfit
            };

            return profit;
        }

        private static decimal GetBuyingPrice(string productID)
        {
            // Retrieve buying price from the Product table based on the product ID
            string query = "SELECT [Buying Price] FROM Products WHERE [Product ID] = @ProductID";
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@ProductID", productID);
                object buyingPrice = cmd.ExecuteScalar();

                return (buyingPrice != null) ? Convert.ToDecimal(buyingPrice) : 0;
            }

        }
        private static decimal GetSellingPrice(string productID)
        {
            // Retrieve selling price from the Product table based on the product ID
            string query = "SELECT [Selling Price] FROM Products WHERE [Product ID] = @ProductID";
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@ProductID", productID);
                object sellingPrice = cmd.ExecuteScalar();

                return (sellingPrice != null) ? Convert.ToDecimal(sellingPrice) : 0;
            }
        }

        private static int GetQuantity(string productID)
        {
            string query = "SELECT [Product Quantity] FROM Invoice WHERE [Product ID] = @ProductID";
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@ProductID", productID);

                // Execute the query and retrieve the result
                object result = cmd.ExecuteScalar();

                // Check if the result is not null and return the value as an integer
                return (result != null) ? Convert.ToInt32(result) : 0;
            }
        }

        // Assuming the product ID should be passed as a parameter to this method
        private static string GetProductID()
        {
            string query = "SELECT [Product ID] FROM Invoice";
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);

                // Execute the query and retrieve the result
                object result = cmd.ExecuteScalar();

                // Check if the result is not null and return the value as a string
                return (result != null) ? result.ToString() : null;
            }
        }

        public static DataTable GetProfitDataFromDatabase()
        {
            string query = "SELECT * FROM Profit";

            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                return dt;
            }
        }
        public static decimal GetTotalProfit()
        {
            string query = "SELECT SUM(TotalProfit) FROM Profit";

            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);

                // Execute the query and retrieve the result
                object result = cmd.ExecuteScalar();

                // Check if the result is not null and return the value as a decimal
                return (result != null) ? Convert.ToDecimal(result) : 0;
            }
        }
    }
}

