using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookanLibrary.Core.Model
{
    public class Publisher : Entity
    {
        public string Name { get; set; }
        public Address Address { get; set; }

        public Publisher() { }
        public Publisher(string name, Address address)
        {
            Name = name;
            Address = address;
        }
    }
}
