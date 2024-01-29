using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project.Business_Layer
{
    internal class Vendor
    {
        private string vendor_name;
        private string vendor_phone;

        public string VendorName
        {
            get { return vendor_name; }
            set { vendor_name = value; }
        }
        public string VendorPhone
        {
            get { return vendor_phone; }
            set { vendor_phone = value; }
        }

        public Vendor()
        {

        }

        public Vendor(string Vendor_Name, string Vendor_Phone)
        {
            VendorName = Vendor_Name;
            vendor_phone = Vendor_Phone;
        }
    }
}
