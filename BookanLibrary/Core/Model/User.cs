using BookanLibrary.Core.Model.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookanLibrary.Core.Model
{
    public class User : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public Role Role { get; set; }
        public Address Address { get; set; }

        public User(string firstName, string lastName, string email, string password,
            string phoneNumber, Role role, Address address) {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password= password;
            PhoneNumber = phoneNumber;
            Role = role;
            Address = address;
        }

        public User() { }
    }
}
