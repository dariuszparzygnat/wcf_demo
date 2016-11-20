using System.Collections.Generic;
using System.ServiceModel;
using LibraryService.Contracts;

namespace LibraryClient.Proxies
{
    public class LibrarySoapClient : ClientBase<ILibrary>, ILibrary
    {
        public BookData GetBookInfo(int bookId)
        {
            return Channel.GetBookInfo(bookId);
        }

        public IEnumerable<string> GetAuthors()
        {
            return Channel.GetAuthors();
        }

        public IEnumerable<BookData> GetBooks(string bookTitle)
        {
            return Channel.GetBooks(bookTitle);
        }

        public IEnumerable<int> GetYearsOfPublication()
        {
            return Channel.GetYearsOfPublication();
        }

        public IEnumerable<BookData> GetBooksByAuthor(string author)
        {
            return Channel.GetBooksByAuthor(author);
        }

        public IEnumerable<BookData> GetBooks(int yearOfPublication)
        {
            return Channel.GetBooks(yearOfPublication);
        }

        public string AddBook(BookData bookData)
        {
            return Channel.AddBook(bookData);
        }
    }
}