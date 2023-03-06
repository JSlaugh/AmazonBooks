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

        private AmazonBookRepository repo;
        public HomeController (AmazonBookRepository repository)
        {
            repo = repository;
        }
        // This controllers main purpose is for displaying the home page which shows all of the books
        public IActionResult Index(int pageNum)
        {
            int returnedResultsCount = 10;

            var data = new BooksViewModel
            {
                Books = repo.Books
                .OrderBy(book => book.Author)
                .Skip(pageNum * returnedResultsCount)
                .Take(10),

                PageInfo = new PageInfo
                {
                    TotalNumBooks = repo.Books.Count(),
                    BooksPerPage = returnedResultsCount,
                    CurrentPage = pageNum
                }
            };

            return View(data);
        }

        //public IActionResult Index() => View();
    }
}
