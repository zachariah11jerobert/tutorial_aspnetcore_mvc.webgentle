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


            //var result = _configuration["AppName"];
            //var key1 = _configuration["infoObj:key1"];
            //var key2 = _configuration["infoObj:key2"];
            //var key3 = _configuration["infoObj:key3:key3obj1"];

            var result1 = _configuration["DisplayNewBookAlert"];
            var result2 = _configuration.GetValue<bool>("DisplayNewBookAlert");
            var result3 = _configuration.GetValue<bool>("NewBookAlert:DisplayNewBookAlert");
            var bookName = _configuration.GetValue<string>("NewBookAlert:BookName");

            // GetSection
            var newBookAlert = _configuration.GetSection("NewBookAlert");
            var displayNewBookAlert = newBookAlert.GetValue<bool>("DisplayNewBookAlert");
            var newBookName = newBookAlert.GetValue<string>("BookName");
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
