using BookanLibrary.Core.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookanLibrary.Core.Model
{
    public class Manager : ApplicationUser
    {
        public string Expertise { get; set; }
        public Manager(string firstName, string lastName, string email, string password,
            string phoneNumber, Role role, Address address, string expertise) : base(firstName, lastName, email, password, phoneNumber, role, address)
        {
            Expertise = expertise;  
        }

        public Manager() : base() { }
    }
}
