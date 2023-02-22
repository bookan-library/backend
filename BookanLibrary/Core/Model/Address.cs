using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookanLibrary.Core.Model
{
    public class Address : Entity
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string StreetNumber { get; set; }

        public Address(string country, string city, string street, string postalCode, string streetNumber)
        {
            Country = country;
            City = city;
            Street = street;
            PostalCode = postalCode;
            StreetNumber = streetNumber;
        }

        public Address() { }
    }
}
