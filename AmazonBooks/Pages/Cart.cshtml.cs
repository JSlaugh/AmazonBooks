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

        public CartModel (IAmazonBookRepository temp,Basket b)
        {
            repo = temp;
            basket = b;
        }

        public Basket basket { get; set; }
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }

        public IActionResult OnPost(int bookId, string returnUrl)
        {
            Book b = repo.Books.FirstOrDefault(x => x.BookId == bookId);

            basket.AddItem(b, 1);

            return RedirectToPage(new { ReturnUrl = returnUrl });

        }

        public IActionResult OnPostRemove(int bookId,string returnUrl)
        {
            basket.RemoveItem(basket.Items.First(x=>x.Book.BookId == bookId).Book);
            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}
