using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BookanLibrary.Core.Model
{
    public class ApplicationRole : IdentityRole<int>
    {
        public ApplicationRole(string name)
        {
            Name = name;
        }
    }
}
