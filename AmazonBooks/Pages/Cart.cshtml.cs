using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmazonBooks.Infrastructure;
using AmazonBooks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AmazonBooks.Pages
{
    public class CartModel : PageModel
    {
        public string ReturnUrl { get; set; }
        private IAmazonBookRepository repo { get; set; }

        public CartModel (IAmazonBookRepository temp)
        {
            repo = temp;
        }

        public Basket basket { get; set; }
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            basket = HttpContext.Session.GetJson<Basket>("basket") ?? new Basket();
        }

        public IActionResult OnPost(int bookId, string returnUrl)
        {
            Book b = repo.Books.FirstOrDefault(x => x.BookId == bookId);
            basket = HttpContext.Session.GetJson<Basket>("basket") ?? new Basket();

            basket.AddItem(b, 1);

            HttpContext.Session.SetJson("basket", basket);
            return RedirectToPage(new { ReturnUrl = returnUrl });

        }
    }
}
