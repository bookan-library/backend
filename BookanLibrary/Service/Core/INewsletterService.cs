using BookanLibrary.Core.Model.Newsletter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookanLibrary.Service.Core
{
    public interface INewsletterService
    {
        Task Subscribe(NewsletterSubscriber subscriber);
        Task SendNewsletter(Newsletter newsletter);
    }
}
