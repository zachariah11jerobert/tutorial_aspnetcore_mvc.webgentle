using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {

        public ViewResult Index()
        {
            ViewData["property1"] = "Nitish Kaushik";
            ViewData["book"] = new BookModel() { Author = "Nitish", Id = 1 };
            return View();
        }

        public ViewResult AboutUs()
        {
            return View();
        }

        public ViewResult ContactUs()
        {
            return View();
        }
    }
}
