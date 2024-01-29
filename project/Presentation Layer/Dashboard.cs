using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using project.Data_Layer;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using project.Business_Layer;
using project.Presentation_Layer;
using System.Runtime.InteropServices;

namespace project
{
    public partial class Dashboard : MaterialForm
    {
        readonly MaterialSkinManager skinManager;
        int imageNum = 1;
        bool dark_mode = false;

        public Dashboard()
        {
            InitializeComponent();
            skinManager = MaterialSkinManager.Instance;
            skinManager.EnforceBackcolorOnAllComponents = true;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.Teal400, MaterialSkin.Primary.Teal700, MaterialSkin.Primary.Teal100, MaterialSkin.Accent.Indigo100, MaterialSkin.TextShade.WHITE);
            InitializeDataGridView();
        }
        // For Make a Sales Tab
        private void InitializeDataGridView()
        {
            // Creating columns for the DataGridView
            SalesGridView.ColumnCount = 5;
            SalesGridView.Columns[0].Name = "Product ID";
            SalesGridView.Columns[1].Name = "Product Name";
            SalesGridView.Columns[2].Name = "Rate";
            SalesGridView.Columns[3].Name = "Quantity";
            SalesGridView.Columns[4].Name = "Price";

        }
        private void Dashboard_Load(object sender, EventArgs e)
        {
            cmbRecieveVendorName.DataSource = tabRecieveItems.GetVendorNames();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
        }

        private void Dark_Mode_CheckedChanged(object sender, EventArgs e)
        {
            if(dark_mode )
            {
                skinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
                dark_mode = false;
            }
            else
            {
                skinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.DARK;
                dark_mode = true;
            }
        }

        private void btnRecieveOk_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in GridRecieveItems.Rows)
                {
                    if (row!=null)
                    {
                        Product product = new Product(row.Cells["RecieveID"].Value.ToString(), row.Cells["RecieveName"].Value.ToString(), row.Cells["RecieveDescription"].Value.ToString(), int.Parse(row.Cells["RecieveQuantity"].Value.ToString()), int.Parse(row.Cells["RecieveCost"].Value.ToString()), int.Parse(row.Cells["RecievePrice"].Value.ToString()), cmbRecieveVendorName.SelectedValue.ToString());
                        tabRecieveItems.InsertInventory(product);
                    }
                    
                }
            }
            catch (NullReferenceException ex)
            {
               
            }

            // After doing the work the grid is cleared
            GridRecieveItems.Rows.Clear();
        }
        private void btnRecieveCancel_Click(object sender, EventArgs e)
        {
            GridRecieveItems.Rows.Clear();
        }

        // For Searching the Product by ID or by Name
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text; 

            if (keyword != null) 
            { 
                DataTable dt = Connection.SearchProductNameInDatabase(keyword);
                ProductNameGridView.DataSource = dt; 
            }
        }
        
        //to calculate return
        private void btnReturn_Click(object sender, EventArgs e)
        {
            Calculate();
        }

        private void btnRecieveNewVendor_Click(object sender, EventArgs e)
        {
            NewVendor newVendor = new NewVendor();
            this.Hide();
            newVendor.Show();
        }
        //to delete rows
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (SalesGridView.SelectedRows.Count > 0)
            {
                int selectedItem = SalesGridView.SelectedRows[0].Index;
                SalesGridView.Rows.RemoveAt(selectedItem);
            }
            else
            {
                MessageBox.Show("Please select a row to delete.", "No Row Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //updating qty after selling and saving the transaction details
        private bool SaveTransaction()
        {
            string fullNameParts = txtFullName.Text;

            // Assuming you have a Customer object or properties to set
            Customer customer = new Customer
            {
                CustomerName = fullNameParts,
                // Add other properties if needed
            };
            //int Customer_ID = DALTransactionDetails.GetCustomerID();
            Transaction transaction = new Transaction
            {
                // Set the customer ID
                //CustomerID = Customer_ID,
                TransactionDate = DateTime.Now,
                GrandTotal = decimal.Parse(txtTotal.Text),
            };

            // Add invoices from SalesGridView to the transaction
            foreach (DataGridViewRow row in SalesGridView.Rows)
            {
                string productID = row.Cells["Product ID"].Value.ToString();
                int productQuantity = int.Parse(row.Cells["Quantity"].Value.ToString());
                decimal subTotal = decimal.Parse(row.Cells["Price"].Value.ToString());

                // Assuming project.Business_Layer.Invoice is the correct class
                Invoice invoice = new Invoice
                {
                    ProductID = productID,
                    ProductQuantity = productQuantity,
                    SubTotal = subTotal,
                };

                transaction.Invoices.Add(invoice);
            }

            bool success = DALTransactionDetails.SaveTransactionWithProfit(transaction,customer);

            if (success)
            {
                MessageBox.Show("Transaction saved successfully!");
                return true;
            }
            else
            {
                MessageBox.Show("Failed to save the transaction. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        

        // Method to update quantities and clear SalesGridView
        private void UpdateQuantitiesAndClearGrid()
        {
            try
            {
                foreach (DataGridViewRow row in SalesGridView.Rows)
                {
                    string productID = row.Cells["Product ID"].Value.ToString();
                    int quantitySold = int.Parse(row.Cells["Quantity"].Value.ToString());
                    if (Connection.DecreaseQty(productID, quantitySold))
                    {
                        MessageBox.Show($"Quantity for Product ID {productID} updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Failed to update quantity for Product ID {productID}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                SalesGridView.Rows.Clear();
                txtTotal.Text = "0.00";
                txtRecieved.Text = "0.00";
                txtReturn.Text = "0.00";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveTransaction();
            UpdateQuantitiesAndClearGrid();
        }
         
        

        double gross_recieve_total;
        private void GridRecieveItems_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            foreach (DataGridViewRow row in GridRecieveItems.Rows)
            {
                if (row.Cells["RecieveCost"].Value != null)
                {
                    gross_recieve_total += int.Parse(row.Cells["RecieveQuantity"].Value.ToString()) * int.Parse(row.Cells["RecieveCost"].Value.ToString());
                }
            }
            lblRecieveTotalValue.Text = gross_recieve_total.ToString();
        }

        private void txtSearchInventory_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearchInventory.Text;

            if (keyword != null)
            {
                DataTable dt = TabInventory.SearchProductNameInDatabase(keyword);
                GridInventory.DataSource = dt;
            }
        }

        private void SLider()
        {
            if (imageNum == 4)
            {
                imageNum = 1;
            }

            pictureBox1.ImageLocation = string.Format(@"Images\{0}.png", imageNum);
            imageNum++;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            SLider();
        }

        private void txtFullName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true; // Prevent the beep sound
                CreateCustomer();
            }
        }
        private void CreateCustomer()
        {
            try
            {
                Customer customer = new Customer();
                string fullName = txtFullName.Text;
                // Call the InsertCustomer method to create the customer and get the generated Customer ID
                int customerID = DALTransactionDetails.InsertCustomer(fullName);

                // Optionally, set the generated Customer ID in your Customer object
                customer.CustomerID = customerID;
                MessageBox.Show($"Customer created successfully! Customer ID: {customerID}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {

            }
        }

        private void txtMakeSales_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                e.SuppressKeyPress = true;
        }
        private void txtMakeSales_TextChanged(object sender, EventArgs e)
        {
            makeSale();
        }
        // Barcode Text Box for Make a Sale
        private void makeSale()
        {
            string ProductID = txtMakeSales.Text;
            string ProductName = null;
            decimal ProductPrice = 0;
            SqlDataReader Products = Connection.SearchProductIdInDatabase(ProductID);

            foreach (var items in Products)
            {
                ProductID = Products[0].ToString();
                ProductName = Products[1].ToString();
                ProductPrice = int.Parse(Products[2].ToString());

                // Check if the product with the same ID already exists in the SalesGridView
                bool productExists = false;
                foreach (DataGridViewRow row in SalesGridView.Rows)
                {
                    if (row.Cells["Product ID"].Value != null && row.Cells["Product ID"].Value.ToString() == ProductID)
                    {
                        // Product with the same ID already exists, increment quantity
                        int currentQuantity = int.Parse(row.Cells["Quantity"].Value.ToString());
                        row.Cells["Quantity"].Value = currentQuantity + 1;

                        // Update the total
                        decimal total = ProductPrice * (currentQuantity + 1);
                        row.Cells["Price"].Value = total;

                        productExists = true;
                        break;
                    }
                }
                if (!productExists)
                {
                    // Product with the same ID doesn't exist, add a new row
                    int productQuantity = 1;
                    decimal total = ProductPrice * productQuantity;
                    SalesGridView.Rows.Add(ProductID, ProductName, ProductPrice, productQuantity, total);
                }
                UpdateOverallTotal();
                txtMakeSales.Clear();
            }
        }
        //overall total method
        private decimal UpdateOverallTotal()
        {
            decimal total = decimal.Parse(txtTotal.Text);
            decimal overallTotal = 0;

            // Calculate the overall total by summing up the total column of each row
            foreach (DataGridViewRow row in SalesGridView.Rows)
            {
                if (row.Cells["Price"].Value != null)
                {
                    overallTotal += decimal.Parse(row.Cells["Price"].Value.ToString());
                }
            }
            // Display the overall total in a TextBox
            txtTotal.Text = overallTotal.ToString("0.00");
            return total;
        }
        //Calculate the cash to return
        private void Calculate()
        {
            decimal total = UpdateOverallTotal();
            decimal received;

            if (decimal.TryParse(txtRecieved.Text, out received))
            {
                decimal cashReturn = received - total;

                cashReturn = Math.Max(0, cashReturn);

                txtReturn.Text = cashReturn.ToString("0.00");
            }
            else
            {
                MessageBox.Show("Please enter a valid numeric value in 'Recieved'.");
            }
        }
        // add from Product Name grid view
        private void txtAddButton_Click(object sender, EventArgs e)
        {
            if (ProductNameGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = ProductNameGridView.SelectedRows[0];

                string productId = selectedRow.Cells["Product ID"].Value.ToString();
                string productName = selectedRow.Cells["Product Name"].Value.ToString();
                decimal productPrice = Convert.ToDecimal(selectedRow.Cells["Product Price"].Value);

                // Check if the product with the same ID already exists in the SalesGridView
                bool productExists = false;
                foreach (DataGridViewRow row in SalesGridView.Rows)
                {
                    if (row.Cells["Product ID"].Value != null && row.Cells["Product ID"].Value.ToString() == productId)
                    {
                        // Product with the same ID already exists, increment quantity
                        int currentQuantity = Convert.ToInt32(row.Cells["Quantity"].Value);
                        row.Cells["Quantity"].Value = currentQuantity + 1;

                        // Update the total
                        decimal total = productPrice * (currentQuantity + 1);
                        row.Cells["Price"].Value = total;

                        productExists = true;
                        break;
                    }
                }
                if (!productExists)
                {
                    // Product with the same ID doesn't exist, add a new row
                    int productQuantity = 1;
                    decimal total = productPrice * productQuantity;
                    SalesGridView.Rows.Add(productId, productName, productPrice, productQuantity, total);
                }

                UpdateOverallTotal();
            }
            else
            {
                MessageBox.Show("Please select a row to add.", "No Row Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            DataTable dt = DALTransactionDetails.GetProfitDataFromDatabase();

            // Assuming that dgvProfit is the DataGridView to display profit information
            dgvProfit.DataSource = dt;

            decimal totalProfit = DALTransactionDetails.GetTotalProfit();

            // Update the label's text property with the total profit
            lblProfit.Text = $"{totalProfit:C}";
        }

        
    }
}
