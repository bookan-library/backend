using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookanLibrary.Core.Model
{
    public class Author : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public DateTime BirthDate { get; set; }
        public Author() { }
        public Author(string firstName, string lastName, string description, DateTime birthDate) {
            FirstName= firstName;
            LastName= lastName;
            Description= description;
            BirthDate= birthDate;
        }

    }
}
