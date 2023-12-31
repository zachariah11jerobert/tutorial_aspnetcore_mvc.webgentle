using BookStore.Models;
using BookStore.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        public readonly NewBookAlertConfig _newBookAlertConfiguration;
        public readonly NewBookAlertConfig _thirdPartyBookConfiguration;
        private readonly IMessageRepository _messageRepository;

        public HomeController(IOptionsSnapshot<NewBookAlertConfig> newBookAlertConfiguration,IMessageRepository messageRepository)
        {
            _newBookAlertConfiguration = newBookAlertConfiguration.Get("InternalBook");
            _thirdPartyBookConfiguration = newBookAlertConfiguration.Get("ThirdPartyBook");
            _messageRepository = messageRepository;
        }

        public ViewResult Index()
        {

            bool isDisplay = _newBookAlertConfiguration.DisplayNewBookAlert;
            bool isDisplayq = _thirdPartyBookConfiguration.DisplayNewBookAlert;
            var value = _messageRepository.GetName();
         
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
