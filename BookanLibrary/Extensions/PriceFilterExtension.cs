using BookanLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookanLibrary.Extensions
{
    public static class PriceFilterExtension
    {
        public static IQueryable<Book> FilterByPrice(this IQueryable<Book> query, QueryParams parameters)
        {
            if (parameters.MaxPrice == null || parameters.MinPrice == null) return query;
            return query.Where(book => book.Price <= parameters.MaxPrice && book.Price >= parameters.MinPrice);
        }
    }
}
