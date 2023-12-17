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
            return View();
        }

        [Route("about-us/{name:alpha:minlength(5)}")]
        public ViewResult AboutUs(string name)
        {
            return View();
        }

        public ViewResult ContactUs()
        {
            return View();
        }


        [Route("test/a{a}")]
        public string Test1(string a)
        {
            return a;
        }

        [Route("test/b{a}")]
        public string Test2(string a)
        {
            return a;
        }

        [Route("test/c{a}")]
        public string Test3(string a)
        {
            return a;
        }
    }
}
