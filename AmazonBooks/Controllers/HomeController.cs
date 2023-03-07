using AmazonBooks.Models;
using AmazonBooks.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmazonBooks.Controllers
{
    public class HomeController : Controller
    {

        private BookstoreContext _context { get; set; }

        private IAmazonBookRepository repo;
        public HomeController (IAmazonBookRepository repository)
        {
            repo = repository;
        }
        // This controllers main purpose is for displaying the home page which shows all of the books
        public IActionResult Index(string bookType,int pageNum)
        {
            int returnedResultsCount = 10;

            var data = new BooksViewModel
            {
                Books = repo.Books
                .Where(book => book.Category == bookType || bookType ==null)
                .OrderBy(book => book.Author)
                .Skip((pageNum-1) * returnedResultsCount)
                .Take(10),

                PageInfo = new PageInfo
                {
                    TotalNumBooks = ( bookType== null ? repo.Books.Count() : repo.Books.Where(x => x.Category ==bookType).Count()),
                    BooksPerPage = returnedResultsCount,
                    CurrentPage = pageNum
                }
            };

            return View(data);
        }

        //public IActionResult Index() => View();
    }
}
