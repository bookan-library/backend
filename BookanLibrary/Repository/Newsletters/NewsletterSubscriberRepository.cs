using BookanLibrary.Core.Model.Newsletter;
using BookanLibrary.Helpers;
using BookanLibrary.Repository.Core.Newsletters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookanLibrary.Repository.Newsletters
{
    public class NewsletterSubscriberRepository : BaseRepository<NewsletterSubscriber>, INewsletterSubscriberRepository
    {
        private readonly DataContext _context;
        public NewsletterSubscriberRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
