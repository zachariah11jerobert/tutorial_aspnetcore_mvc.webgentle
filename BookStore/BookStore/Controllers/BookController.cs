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
        public List<BookModel> GetAllBooks()
        {
            return _BookRepository.GetAllBooks();
        }

        public BookModel GetBook(int id)
        {
            return _BookRepository.GetBookById(id);
        }

        public List<BookModel> SearchBooks(string bookName,string authorName)
        {
            return _BookRepository.SearchBook(bookName, authorName);
        }
    }
}
