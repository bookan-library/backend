using BookanLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookanLibrary.Extensions
{
    public static class PublisherFilterExtension
    {
        public static IQueryable<Book> FilterByPublisher(this IQueryable<Book> query, QueryParams parameters)
        {
            if (parameters.Publishers == null) return query;
            if (parameters.Publishers.Length == 0 
                || parameters.Publishers[0] == null 
                || parameters.Publishers[0].Trim().Equals("")) 
                return query;
            List<Book> filteredBooks = new List<Book>();
            IQueryable<Book> emptyQuery = Enumerable.Empty<Book>().AsQueryable();
            return query
                    .Where(b => parameters.Publishers.Contains(b.Publisher.Name))
                    .AsQueryable();
            //foreach (string pub in parameters.Publishers) {
            //    emptyQuery.Concat(query.Where(p => p.Publisher.Name.ToLower().Equals(pub.ToLower())));
            //}
        }
    }
}
