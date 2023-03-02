using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookanLibrary.Core.Model.Newsletter
{
    public class NewsletterSubscriber : Entity
    {
        public string SubscriberEmail { get; set; }

        public NewsletterSubscriber() { }
        public NewsletterSubscriber(string subscriberEmail)
        {
            SubscriberEmail = subscriberEmail;
        }
    }
}
