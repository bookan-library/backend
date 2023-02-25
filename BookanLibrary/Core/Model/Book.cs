using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BookanLibrary.Core.Model
{
    public class Book : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int PageNumber { get; set; }
        public int PublishingYear { get; set; }
        public Author Author { get; set; }
        public Publisher Publisher { get; set; }
        public Category Category { get; set; }
        public string PicUrl { get; set; }

        public Book(string name, string description, int pageNumber, int publishingYear,
            Author author, Publisher publisher, Category category, string picUrl) {
            Name = name;
            Description = description;
            PageNumber = pageNumber;
            Publisher = publisher;
            Category = category;
            PicUrl = picUrl;
            Author = author;
            PublishingYear= publishingYear;
        }

        public Book() { }
    }
}
