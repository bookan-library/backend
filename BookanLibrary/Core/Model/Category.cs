using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookanLibrary.Core.Model
{
    public class Category : Entity
    {
        public string Name { get; set; }
        public int? CategoryParentId { get; set; }

        public Category() { }
        public Category(string name, int categoryParentId)
        {
            Name = name;
            CategoryParentId = categoryParentId;
        }
    }
}
