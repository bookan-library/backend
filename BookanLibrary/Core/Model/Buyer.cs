using BookanLibrary.Core.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookanLibrary.Core.Model
{
    public class Buyer : ApplicationUser
    {
        public int BoughtBooksNum { get; set; }
        public Buyer(string firstName, string lastName, string email, string password,
            string phoneNumber, Role role, Address address, int boughtBooksNum) : base(firstName, lastName, email, password, phoneNumber, role, address) {
            BoughtBooksNum = boughtBooksNum;
        }

        public Buyer() : base() { }
    
    }


}
