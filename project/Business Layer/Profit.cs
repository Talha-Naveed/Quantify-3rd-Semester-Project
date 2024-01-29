using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.Business_Layer
{
    internal class Profit
    {
        private string productID;
        private int quantitySold;
        private decimal sellingPrice;
        private decimal buyingPrice;
        private decimal totalProfit;

        public string ProductID 
        {
            get { return productID; } 
            set { productID = value; }
        }
        public int QuantitySold 
        { 
            get { return quantitySold; }
            set { quantitySold = value; }
        }
        public decimal SellingPrice 
        { 
            get { return sellingPrice; }
            set { sellingPrice = value; }
        }
        public decimal BuyingPrice 
        {
            get { return buyingPrice; }
            set { buyingPrice = value; }
        }
        public decimal TotalProfit 
        {
            get { return totalProfit; }
            set { totalProfit = value; }
        }
        public Profit()
        {

        }
        public Profit(string productId, int quantitysold, decimal sellingprice, decimal buyingprice, decimal totalprofit)
        {
            ProductID = productId;
            QuantitySold = quantitysold;
            SellingPrice = sellingprice;
            BuyingPrice = buyingprice;
            TotalProfit = totalprofit;
        }
    }
}
