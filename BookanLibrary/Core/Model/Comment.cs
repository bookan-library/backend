using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookanLibrary.Core.Model
{
    public class Comment : Entity
    {
        public Buyer Buyer { get; set; }
        public Book Book { get; set; }
        public string Nickname { get; set; }
        public string Content { get; set; }
        public bool Approved { get; set; }
        public Comment() { }
        public Comment(Buyer buyer, Book book, string nickname, string content, bool approved = false)
        {
            Buyer = buyer;
            Book = book;
            Nickname = nickname;
            Content = content;
            Approved = approved;
        }
    }
}
