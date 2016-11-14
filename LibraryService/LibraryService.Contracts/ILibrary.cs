using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Contracts
{
    [ServiceContract]
    public interface ILibrary
    {
        [OperationContract]
        BookData GetBookInfo(int bookId);

        [OperationContract]
        IEnumerable<string> GetAuthors();

        [OperationContract]
        IEnumerable<BookData> GetBooks(string bookTitle);

        [OperationContract]
        IEnumerable<int> GetYearsOfPublication();

        [OperationContract]
        IEnumerable<BookData> GetBooksByAuthor(string author);

        [OperationContract(Name = "GetBooksByYear")]
        IEnumerable<BookData> GetBooks(int yearOfPublication);

        [OperationContract]
        string AddBook(BookData bookData);
    }
}
