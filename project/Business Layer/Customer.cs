using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.Business_Layer
{
    internal class Customer 
    {
        private string Customer_Name;
        private int Customer_ID;
        private string Customer_Email;
        private string Customer_Address;


        public string CustomerName
        {
            get { return Customer_Name; }
            set { Customer_Name = value; }
        }
        public int CustomerID
        { 
            get { return Customer_ID; } 
            set { Customer_ID = value; } 
        }

        public string CustomerEmail
        { get { return Customer_Email; }
            set { Customer_Email = value; }
        }
        public string CustomerAddress
        { 
            get { return Customer_Address; } 
            set { Customer_Address = value; } 
        }

        public Customer()
        {
            
        }

        public Customer(string customername ,int customerid, string customeremail, string customeradderss) 
        {
            CustomerName = customername;
            CustomerID = customerid;
            CustomerEmail = customeremail;
            CustomerAddress = customeradderss;
        }
    }
}
