using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibraryService.Contracts;

namespace LibraryService
{
    public class LibraryManager : ILibrary, ILibraryRest 
    {
        public BookData GetBookInfo(string bookTitle)
        {
            using (var context = new BookContext())
            {
                var book = context.Book.FirstOrDefault(e => e.Title.Contains(bookTitle));
                if (book == null)
                    return null;
                return new BookData()
                {
                    Author = book.Author,
                    Id = book.Id,
                    Title = book.Title,
                    YearOfPublication = book.YearOfPublication
                };
            }
        }

        public IEnumerable<string> GetAuthors()
        {
            using (var context = new BookContext())
            {
                var authors = context.Book.Select(e => e.Author).Distinct().ToList();
                return authors;
            }
        }

        public IEnumerable<int> GetYearsOfPublication()
        {
            using (var context = new BookContext())
            {
                var years = context.Book.Select(e => e.YearOfPublication).Distinct().ToList();
                return years;
            }
        }

        public IEnumerable<BookData> GetBooks(string author)
        {
            using (var context = new BookContext())
            {
                var books = context.Book.Where(e => e.Author.Contains(author)).Select(book => new BookData()
                {
                    Author = book.Author,
                    Id = book.Id,
                    Title = book.Title,
                    YearOfPublication = book.YearOfPublication
                }).ToList();
                return books;
            }
        }

        public IEnumerable<BookData> GetBooks(int yearOfPublication)
        {
            using (var context = new BookContext())
            {
                var books = context.Book.Where(e => e.YearOfPublication == yearOfPublication).Select(book => new BookData()
                {
                    Author = book.Author,
                    Id = book.Id,
                    Title = book.Title,
                    YearOfPublication = book.YearOfPublication
                }).ToList();
                return books;
            }
        }

        public string AddBook(BookData bookData)
        {
            using (var context = new BookContext())
            {
                var addedBook = context.Book.Add(new Book()
                {
                    Author = bookData.Author,
                    YearOfPublication = bookData.YearOfPublication,
                    Title = bookData.Title

                });
                context.SaveChanges();
                return addedBook.Id.ToString();
            }
        }

        public IEnumerable<BookRestData> GetBooksWithRest()
        {
            using (var context = new BookContext())
            {
                var books = context.Book.Select(book => new BookRestData()
                {
                    Author = book.Author,
                    Id = book.Id,
                    Title = book.Title,
                    YearOfPublication = book.YearOfPublication
                }).ToList();
                return books;
            }
        }

        public BookRestData GetBookInfoWithRest(string title)
        {
            using (var context = new BookContext())
            {
                var book = context.Book.FirstOrDefault(e => e.Title.Contains(title));
                if (book == null)
                    return null;
                return new BookRestData()
                {
                    Author = book.Author,
                    Id = book.Id,
                    Title = book.Title,
                    YearOfPublication = book.YearOfPublication
                };
            }
        }

        public string AddBookWithRest(string title, string author, string yearOfPublication)
        {
            using (var context = new BookContext())
            {
                var addedBook = context.Book.Add(new Book()
                {
                    Author = author,
                    YearOfPublication = Int32.Parse(yearOfPublication),
                    Title = title

                });
                context.SaveChanges();
                return addedBook.Id.ToString();
            }
        }
    }
}