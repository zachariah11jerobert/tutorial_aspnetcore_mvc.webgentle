using BookStore.Data;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Repository
{
    public class BookRepository
    {
        private readonly BookStoreDbContext _bookStoreDbContext = null;
        public BookRepository(BookStoreDbContext bookStoreDbContext)
        {
            _bookStoreDbContext = bookStoreDbContext;
        }

        public object AddNew { get; internal set; }

        public int AddNewBook(BookModel model)
        {
            var newBook = new Book()
            {
                Author = model.Author,
                CreatedOn = DateTime.UtcNow,
                Description = model.Description,
                Title = model.Title,
                TotalPages = model.TotalPages,
                UpdatedOn = DateTime.UtcNow
            };


            _bookStoreDbContext.Books.Add(newBook);
            _bookStoreDbContext.SaveChanges();

            return newBook.Id;
        }

        public async Task<int> AddNewBookAsync(BookModel model)
        {
            var newBook = new Book()
            {
                Author = model.Author,
                CreatedOn = DateTime.UtcNow,
                Description = model.Description,
                Title = model.Title,
                TotalPages = model.TotalPages,
                UpdatedOn = DateTime.UtcNow
            };


            await _bookStoreDbContext.Books.AddAsync(newBook);
            await _bookStoreDbContext.SaveChangesAsync();

            return newBook.Id;
        }

        public async Task<List<BookModel>> GetAllBooks()
        {
            var books = new List<BookModel>();
            var allBooks = await _bookStoreDbContext.Books.ToListAsync();
            if (allBooks?.Any() == true)
            {
                foreach (var book in allBooks)
                {
                    books.Add(new BookModel()
                    {
                        Author = book.Author,
                        Category = book.Category,
                        Description = book.Description,
                        Id = book.Id,
                        Language = book.Language,
                        Title = book.Title,
                        TotalPages = book.TotalPages
                    });
                }
            }
            return books;
        }

        public async Task<BookModel> GetBookById(int id)
        {
            var book = await _bookStoreDbContext.Books.FindAsync(id);
            if (book != null)
            {

                var bookDetails = new BookModel()
                {
                    Author = book.Author,
                    Category = book.Category,
                    Description = book.Description,
                    Id = book.Id,
                    Language = book.Language,
                    Title = book.Title,
                    TotalPages = book.TotalPages
                };
                return bookDetails;
            }
            return null;
        }

        public List<BookModel> SearchBook(string title, string authorName)
        {
            return DataSource().Where(x => x.Title.Contains(title) || x.Author.Contains(authorName)).ToList();
        }

        private List<BookModel> DataSource()
        {
            return new List<BookModel>()
            {
                new BookModel(){Id = 1, Title = "MVC", Author = "Nitish", Description="This is the Description for MVC book",Category="Programming",Language="English", TotalPages=134},
                new BookModel(){Id = 2, Title = "Dot Net Core", Author = "Nitish", Description="This is the Description for Dot Net Core book",Category="Framework",Language="Chinese", TotalPages=567},
                new BookModel(){Id = 3, Title = "C#", Author = "Monika", Description="This is the Description for C# book",Category="Developer",Language="Hindi", TotalPages=897},
                new BookModel(){Id = 4, Title = "Java", Author = "Webgentle", Description="This is the Description for Java book",Category="Concept",Language="English", TotalPages=564},
                new BookModel(){Id = 5, Title = "PhP", Author = "Webgentle", Description="This is the Description for Php book",Category="DevOps",Language="English", TotalPages=870},
            };
        }
    }
}
