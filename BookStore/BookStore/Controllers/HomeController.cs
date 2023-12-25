using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        public readonly IConfiguration _configuration;

        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public ViewResult Index()
        {
            var newBookAlert = new NewBookAlertConfig();
            _configuration.Bind("NewBookAlert", newBookAlert);

            bool isDisplay = newBookAlert.DisplayNewBookAlert;
         
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
