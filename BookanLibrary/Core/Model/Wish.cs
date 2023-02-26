using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookanLibrary.Core.Model
{
    public class Wish : Entity
    {
        public Buyer Buyer { get; set; }
        public Book Book { get; set; }

        public Wish() { }
        public Wish(Buyer buyer, Book book)
        {
            this.Buyer = buyer;
            this.Book = book;
        }
    }
}
