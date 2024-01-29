using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.Business_Layer
{
    internal class User : Person
    {
        private string password;

        private string email;


        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string Email
        {
            get { return email; }

            set { email = value; } 
        }
        
        public User()
        {

        }

        public User(string upassword, string uemail, string firstname, string lastname) :base(firstname, lastname)
        {
            Password = upassword;
            Email = uemail;

        }
    }
}
