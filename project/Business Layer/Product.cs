using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.Business_Layer
{
    internal class Product
    {
        private string Product_ID;
        private string Product_Name;
        private string Product_Description;
        private int Product_QuantityAvailable;
        private decimal Product_BuyingPrice;
        private decimal Product_SellingPrice;
        private string Product_VendorName;
        private Vendor vendor;
        
        // relative properties
        public string ProductName
        {
            get { return Product_Name; } 
            set { Product_Name = value; }
        }
        public string ProductID
        {
            get { return Product_ID; }
            set { Product_ID = value; }
        }
        public string ProductDescription
        {
            get { return Product_Description; }
            set { Product_Description = value; }
        }
        public decimal ProductBuyingPrice
        { 
            get { return Product_BuyingPrice; } 
            set { Product_BuyingPrice = value; } 
        }
        public decimal ProductSellingPrice
        {
            get { return Product_SellingPrice; }
            set { Product_SellingPrice = value; }
        }
        public int ProductQuantityAvailable
        { 
            get { return Product_QuantityAvailable; } 
            set { Product_QuantityAvailable = value; }
        }
        public string ProductVendorName
        { 
            get { return Product_VendorName; } 
            set { Product_VendorName = value; }
        }
        public Vendor Vendor
        {
            get { return vendor; }
            set { vendor = value; }
        }

        public Product() 
        {
            
        }

        public Product(string productid, string productname, string productdescription, int productquantityavailable, decimal productBuyingPrice, decimal productSellingPrice,  string productvendorname)
        {
            ProductName = productname;
            ProductID = productid;
            ProductDescription = productdescription;
            ProductBuyingPrice = productBuyingPrice;
            ProductSellingPrice = productSellingPrice;
            ProductQuantityAvailable = productquantityavailable;
            ProductVendorName = productvendorname;
        }

        public void AddVendor(Vendor vendor)
        {
            this.vendor=vendor;
        }
    }
}
