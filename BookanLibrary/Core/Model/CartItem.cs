using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookanLibrary.Core.Model
{
    public class CartItem : Entity
    {
        public Buyer Buyer { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }
        public CartItem() { }

        public CartItem(Buyer buyer, Book book, int quantity) {
            Buyer = buyer;
            Book = book;
            Quantity = quantity;
        }
    }
}
