using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.Business_Layer
{
    internal class Person
    {
        private string Fisrtname;
        private string Lastname;

        public string FirstName
        { get; set; }

        public string LastName
        { get; set; }

        public Person()
        {

        }

        public Person(string firstname, string lastname)
        {
            FirstName = firstname;
            LastName = lastname;
        }
    }
}
