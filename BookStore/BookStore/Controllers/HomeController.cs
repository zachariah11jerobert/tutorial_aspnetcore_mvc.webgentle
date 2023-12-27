using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        public readonly NewBookAlertConfig _newBookAlertConfiguration;

        public HomeController(IOptionsSnapshot<NewBookAlertConfig> newBookAlertConfiguration)
        {
            _newBookAlertConfiguration = newBookAlertConfiguration.Value;
        }

        public ViewResult Index()
        {

            bool isDisplay = _newBookAlertConfiguration.DisplayNewBookAlert;
         
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
