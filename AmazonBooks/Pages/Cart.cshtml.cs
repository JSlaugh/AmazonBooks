using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmazonBooks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AmazonBooks.Pages
{
    public class CartModel : PageModel
    {

        private IAmazonBookRepository repo { get; set; }

        public CartModel (IAmazonBookRepository temp)
        {
            repo = temp;
        }

        public Basket basket { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost(int bookId)
        {
            Book b = repo.Books.FirstOrDefault(x => x.BookId == bookId);
            basket = new Basket();

            basket.AddItem(b, 1);
            return RedirectToPage();

        }
    }
}
