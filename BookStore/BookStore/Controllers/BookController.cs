using BookStore.Models;
using BookStore.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _BookRepository = null;
        public BookController()
        {
            _BookRepository = new BookRepository();
        }
        public ViewResult GetAllBooks()
        {
            var data = _BookRepository.GetAllBooks();

            return View(data);
        }

        public ViewResult GetBook(int id)
        {
            dynamic data = new System.Dynamic.ExpandoObject();
            data.book = _BookRepository.GetBookById(id);
            data.Name = "Nithish";

            return View(data);
        }

        public List<BookModel> SearchBooks(string bookName, string authorName)
        {
            return _BookRepository.SearchBook(bookName, authorName);
        }
    }
}
