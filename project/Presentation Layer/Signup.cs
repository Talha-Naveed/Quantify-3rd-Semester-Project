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
using project.Business_Layer;
using ComponentFactory.Krypton.Toolkit;

namespace project.Presentation_Layer
{
    public partial class Signup : MaterialForm

    {
        readonly MaterialSkinManager materialSkinManager;

        private string firstName = "First Name";
        private string lastName = "Last Name";
        private string email = "E-Mail";
        private string createPassword = "Create Password";
        private string confirmPassword = "Confirm Password";
        public Signup()
        {
            InitializeComponent();
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = false;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new MaterialSkin.ColorScheme(Primary.Teal600, Primary.Teal600, Primary.Teal50, Accent.DeepPurple100, TextShade.WHITE);

            InitializeTextBoxValue();
        }

        private void InitializeTextBoxValue()
        {
            txtFirstName.Text = firstName;
            txtLastName.Text = lastName;
            txtsignupemail.Text = email;
            txtsignuppassword.Text = createPassword;
            txtconfirmpassword.Text = confirmPassword;
        }

        
        private void linkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login login = new Login();
            this.Hide();
            login.Show();
        }
        bool textfirstnamechanged = false;
        bool textlastnamechanged = false;
        bool textsignupemailchanged = false;
        bool textsignuppasswordchanged = false;
        bool textconfirmpasswordchanged = false;

        private void txtFirstName_SelectionChanged(object sender, EventArgs e)
        {
            if (!textfirstnamechanged)
            {
                txtFirstName.Clear();
                textfirstnamechanged = true;
            }
        }

        private void txtLastName_SelectionChanged(object sender, EventArgs e)
        {
            if (!textlastnamechanged)
            {
                txtLastName.Clear();
                textlastnamechanged = true;
            }
        }

        private void txtsignupemail_SelectionChanged(object sender, EventArgs e)
        {
            if (!textsignupemailchanged)
            {
                txtsignupemail.Clear();
                textsignupemailchanged = true;
            }
        }

        private void txtsignuppassword_SelectionChanged(object sender, EventArgs e)
        {
            if (!textsignuppasswordchanged)
            {
                txtsignuppassword.Clear();
                textsignuppasswordchanged = true;
            }
        }

        private void txtconfirmpassword_SelectionChanged(object sender, EventArgs e)
        {
            if (!textconfirmpasswordchanged)
            {
                txtconfirmpassword.Clear();
                textconfirmpasswordchanged = true;
            }
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            try
            {
                string firstName = txtFirstName.Text.Trim();
                string lastName = txtLastName.Text.Trim();
                string email = txtsignupemail.Text.Trim();
                string password = txtsignuppassword.Text;
                string confirmPassword = txtconfirmpassword.Text; // Assuming you have a textbox for confirming password

                if (firstName != null && lastName != null && email != null && password != null && confirmPassword != null)
                {
                    if (password == confirmPassword)
                    {
                        User newUser = new User
                        {
                            FirstName = firstName,
                            LastName = lastName,
                            Email = email,
                            Password = password
                        };

                        bool success = DALLoginSignup.InsertSignUpDetailsInDataBase(newUser);

                        if (success)
                        {
                            MessageBox.Show("User signed up successfully!");
                            // Clear the textboxes after successful signup
                            txtFirstName.Text = "First Name";
                            txtLastName.Text = "Last Name";
                            txtsignupemail.Text = "E-Mail";
                            txtsignuppassword.Text = "Create Password";
                            txtconfirmpassword.Text = "Confirm Password";
                        }
                        else
                        {
                            MessageBox.Show("Failed to sign up user. Please try again.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Password and Confirm Password do not match.");
                    }
                }
                else
                {
                    MessageBox.Show("Please fill in all the required fields.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}
