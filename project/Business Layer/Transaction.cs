using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.Business_Layer
{
    internal class Transaction
    {
        private int Transaction_ID;
        private int Customer_ID;
        private DateTime Transaction_Date;
        private decimal Grand_Total;

        public int TransactionID { get; set; }
        public int CustomerID { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal GrandTotal { get; set; }

        public Customer Customer { get; set; }

        public List<Invoice> Invoices { get; set; }

        public Transaction()
        {
            Invoices = new List<Invoice>();
        }
        public Transaction(int transaction_ID, int customer_ID, DateTime transaction_Date, decimal grand_Total)
        {
            Transaction_ID = transaction_ID;
            Customer_ID = customer_ID;
            Transaction_Date = transaction_Date;
            Grand_Total = grand_Total;
            Invoices = new List<Invoice>();
        }
    }
}
