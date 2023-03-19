using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookanLibrary.Core.Model.Newsletter
{
    public class Newsletter : Entity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public Manager Creator { get; set; }
        public string PicUrl { get; set; }

        public Newsletter() { }
        public Newsletter(string title, string content, Manager creator, string picUrl)
        {
            Title = title;
            Content = content;
            Creator = creator;
            PicUrl = picUrl;
        }
    }
}
