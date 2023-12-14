using BookStore.Models;
using BookStore.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository = null;
        public BookController(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<ViewResult> GetAllBooks()
        {
            var data = await _bookRepository.GetAllBooks();

            return View(data);
        }

        [Route("book-details/{id}", Name = "bookdetailsRoute")]
        public async Task<ViewResult> GetBook(int id)
        {

            var data = await _bookRepository.GetBookById(id);
            return View(data);
        }

        public List<BookModel> SearchBooks(string bookName, string authorName)
        {
            return _bookRepository.SearchBook(bookName, authorName);
        }

        public ViewResult AddNewBook(bool isSuccess = false, int bookId = 0)
        {
            var model = new BookModel()
            {
                //Language = "2"
            };

           

            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = bookId;
            return View(model);
        }

        [HttpPost]
        public IActionResult AddNewBook(BookModel bookModel)
        {
            int id = _bookRepository.AddNewBook(bookModel);
            if (id > 0)
            {
                // return RedirectToAction("AddNewBook");
                return RedirectToAction(nameof(AddNewBook), new { isSuccess = true, bookId = id });
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewBookAsync(BookModel bookModel)
        {
            if (ModelState.IsValid)
            {
                int id = await _bookRepository.AddNewBookAsync(bookModel);
                if (id > 0)
                {
                    // return RedirectToAction("AddNewBook");
                    return RedirectToAction(nameof(AddNewBook), new { isSuccess = true, bookId = id });
                }
            }
            //ViewBag.IsSuccess = false;
            //ViewBag.BookId = 0;
          

            return View();
        }

      
    }
}