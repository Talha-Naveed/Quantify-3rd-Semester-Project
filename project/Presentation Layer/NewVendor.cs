using MaterialSkin;
using MaterialSkin.Controls;
using project.Business_Layer;
using project.Data_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project.Presentation_Layer
{
    public partial class NewVendor : MaterialForm
    {
        readonly MaterialSkinManager materialSkinManager;

        public NewVendor()
        {
            InitializeComponent();
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = false;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Teal600, Primary.Teal600, Primary.Teal50, Accent.DeepPurple100, TextShade.WHITE);
        }

        private void NewVendor_Load(object sender, EventArgs e)
        {

        }

        private void btnVendorDiscard_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            this.Hide();
            dashboard.Show();

        }

        private void btnVendorContinue_Click(object sender, EventArgs e)
        {
            Vendor newVendor = new Vendor(txtVendorVendorName.Text, txtVendorVendorPhone.Text);
            AddVendor.InputVendor(newVendor);
            
            Dashboard dashboard = new Dashboard();
            this.Hide();
            dashboard.Show();
        }

                
    }
}
