﻿using BookStore.Data;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreDbContext _bookStoreDbContext = null;
        private readonly IConfiguration _configuration;

        public BookRepository(BookStoreDbContext bookStoreDbContext,IConfiguration configuration)
        {
            _bookStoreDbContext = bookStoreDbContext;
            _configuration = configuration;
        }

        public int AddNewBook(BookModel model)
        {
            var newBook = new Book()
            {
                Author = model.Author,
                CreatedOn = DateTime.UtcNow,
                Description = model.Description,
                Title = model.Title,
                TotalPages = model.TotalPages.HasValue ? model.TotalPages.Value : 0,
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
                LanguageId = model.LanguageId,
                TotalPages = model.TotalPages.HasValue ? model.TotalPages.Value : 0,
                UpdatedOn = DateTime.UtcNow,
                CoverImageUrl = model.CoverImageUrl,
                BookPdfurl = model.BookPdfUrl
            };

            newBook.bookGallery = new List<BookGallery>();
            foreach (var file in model.Gallery)
            {
                newBook.bookGallery.Add(new BookGallery()
                {
                    Name = file.Name,
                    URL = file.URL
                });
            }


            await _bookStoreDbContext.Books.AddAsync(newBook);
            await _bookStoreDbContext.SaveChangesAsync();

            return newBook.Id;
        }

        public async Task<List<BookModel>> GetAllBooks()
        {
            return await _bookStoreDbContext.Books
                     .Select(book => new BookModel()
                     {
                         Author = book.Author,
                         Category = book.Category,
                         Description = book.Description,
                         Id = book.Id,
                         LanguageId = book.LanguageId,
                         Language = book.Language.Name,
                         Title = book.Title,
                         TotalPages = book.TotalPages,
                         CoverImageUrl = book.CoverImageUrl
                     }).ToListAsync();
        }

        public async Task<List<BookModel>> GetTopBooksAsync(int count)
        {
            return await _bookStoreDbContext.Books
                    .Select(book => new BookModel()
                    {
                        Author = book.Author,
                        Category = book.Category,
                        Description = book.Description,
                        Id = book.Id,
                        LanguageId = book.LanguageId,
                        Language = book.Language.Name,
                        Title = book.Title,
                        TotalPages = book.TotalPages,
                        CoverImageUrl = book.CoverImageUrl
                    }).Take(count).ToListAsync();
        }

        public async Task<BookModel> GetBookById(int id)
        {
            return await _bookStoreDbContext.Books.Where(x => x.Id == id).Select
            (book => new BookModel()
            {
                Author = book.Author,
                Category = book.Category,
                Description = book.Description,
                Id = book.Id,
                Language = book.Language.Name,
                Title = book.Title,
                TotalPages = book.TotalPages,
                CoverImageUrl = book.CoverImageUrl,
                Gallery = book.bookGallery.Select(g => new GalleryModel()
                {
                    Id = g.Id,
                    Name = g.Name,
                    URL = g.URL
                }).ToList()
            }).FirstOrDefaultAsync();

        }

        public List<BookModel> SearchBook(string title, string authorName)
        {
            return null;
        }

        public string GetAppName()
        {
            return _configuration["AppName"];
        }
    }
}
