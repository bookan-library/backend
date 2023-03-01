using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookanLibrary.Core.Model.Newsletter
{
    public class Newsletter : Entity
    {
        public string SubscriberEmail { get; set; }

        public Newsletter() { }
        public Newsletter(string subscriberEmail)
        {
            SubscriberEmail = subscriberEmail;
        }
    }
}
