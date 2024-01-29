using MaterialSkin;
using MaterialSkin.Controls;
using project.Business_Layer;
using project.Data_Layer;
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

namespace project.Presentation_Layer
{
    public partial class Login : MaterialForm
    {
        readonly MaterialSkinManager materialSkinManager;
        
       
        public Login()
        {
            InitializeComponent();
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = false;
            //materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Teal600, Primary.Teal600, Primary.Teal50, Accent.DeepPurple100, TextShade.WHITE); 
        }
        private void Logan_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtloginemail.Text.Trim();
            string password = txtloginpassword.Text;

            if (!string.IsNullOrWhiteSpace(email) && !string.IsNullOrWhiteSpace(password))
            {
                User loginUser = new User
                {
                    Email = email,
                    Password = password
                };

                if (DALLoginSignup.ValidateLogin(loginUser))
                {
                    // Login successful, navigate to the Dashboard
                    
                    Dashboard dashboard = new Dashboard();
                    dashboard.Show();
                    this.Hide();
                    MessageBox.Show("Login successful!");
                }
                else
                {
                    MessageBox.Show("Invalid email or password. Please try again.");
                }
            }
            else
            {
                MessageBox.Show("Please enter both email and password.");
            }
        }

        private void linkSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Signup sgn = new Signup();
            this.Hide();
            sgn.Show();
        }

        bool textloginpasswordchanged = false;
        bool textloginemailchanged = false;
        private void txtloginemail_SelectionChanged(object sender, EventArgs e)
        {
            if (!textloginemailchanged)
            {
                txtloginemail.Clear();
                textloginemailchanged = true;
            }
        }

        private void txtloginpassword_SelectionChanged(object sender, EventArgs e)
        {
            if (!textloginpasswordchanged)
            {
                txtloginpassword.Clear();
                textloginpasswordchanged = true;
            }
        }

        private void txtloginpassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                e.SuppressKeyPress = true;
        }

        private void txtloginemail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                e.SuppressKeyPress = true;
        }
    }
}
