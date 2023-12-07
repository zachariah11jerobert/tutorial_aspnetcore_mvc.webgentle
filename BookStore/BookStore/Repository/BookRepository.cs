using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Repository
{
    public class BookRepository
    {
        public List<BookModel> GetAllBooks()
        {
            return DataSource();
        }

        public BookModel GetBookById(int id)
        {
            return DataSource().Where(x => x.Id == id).FirstOrDefault();
        }

        public List<BookModel> SearchBook(string title, string authorName)
        {
            return DataSource().Where(x => x.Title.Contains(title) || x.Author.Contains (authorName)).ToList();
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
