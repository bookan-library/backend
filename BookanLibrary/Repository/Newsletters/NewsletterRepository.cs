using BookanLibrary.Core.Model.Newsletter;
using BookanLibrary.Helpers;
using BookanLibrary.Repository.Core;
using BookanLibrary.Repository.Core.Newsletters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookanLibrary.Repository.Newsletters
{
    public class NewsletterRepository : BaseRepository<Newsletter>, INewsletterRepository
    {
        private readonly DataContext _context;
        public NewsletterRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
