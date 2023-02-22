using BookanLibrary.Core.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookanLibrary.Core.Model
{
    public class Seller : User
    {
        public int SoldBooksNumber { get; set; }
        public Seller(string firstName, string lastName, string email, string password,
            string phoneNumber, Role role, Address address, int soldBooksNumber) : base(firstName, lastName, email, password, phoneNumber, role, address)
        {
            SoldBooksNumber = soldBooksNumber;
        }

        public Seller() { }
    }
}
