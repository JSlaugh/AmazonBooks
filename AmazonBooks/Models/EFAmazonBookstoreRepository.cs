using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmazonBooks.Models
{
    public class EFAmazonBookstoreRepository : AmazonBookRepository
    {

        private BookstoreContext context { get; set; }

        public EFAmazonBookstoreRepository (BookstoreContext data)
        {
            context = data;
        }
        public IQueryable<Book> Books => context.Books;
    }
}
