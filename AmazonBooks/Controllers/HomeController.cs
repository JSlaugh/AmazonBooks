using AmazonBooks.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmazonBooks.Controllers
{
    public class HomeController : Controller
    {



        // This controllers main purpose is for displaying the home page which shows all of the books
        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult Index() => View();
    }
}
