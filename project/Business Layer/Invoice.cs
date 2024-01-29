using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.Business_Layer
{
    internal class Invoice
    {
        private string Product_ID;
        private int Product_Quantity;
        private decimal Sub_Total;
        public string ProductID 
        {
            get { return Product_ID; } 
            set { Product_ID = value; }
        }
        public int ProductQuantity
        {
            get { return Product_Quantity; }
            set { Product_Quantity = value; }
        }
        public decimal SubTotal
        {
            get { return Sub_Total; }
            set { Sub_Total = value;}
        }
        public Invoice() 
        { }
        public Invoice(string Product_ID, int Product_Quantity,decimal Subtotal)
        {
            ProductID = Product_ID;
            ProductQuantity = Product_Quantity;
            SubTotal = Subtotal;
        }
    }
}
