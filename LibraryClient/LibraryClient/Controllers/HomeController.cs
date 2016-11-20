using System.Linq;
using System.Web.Mvc;
using LibraryClient.Models;
using LibraryClient.Proxies;
using LibraryService.Contracts;

namespace LibraryClient.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new BookSearchViewModel());
        }

        [HttpPost]
        public ActionResult Index(BookSearchViewModel bookSearchViewModel)
        {
            ViewBag.Message = "Książki";
            var libraryClient = new LibrarySoapClient();
            var bookTitle = bookSearchViewModel.BookTitle ?? "";
            bookSearchViewModel.Books = libraryClient.GetBooks(bookTitle);
            libraryClient.Close();
            return View(bookSearchViewModel);
        }

        public ActionResult Authors(string author)
        {
            var libraryClient = new LibrarySoapClient();
            var model = new AuthorsViewModel();
            model.Authors = libraryClient.GetAuthors();
            if (!string.IsNullOrWhiteSpace(author))
            {    model.PublicatedBooks =
                    libraryClient.GetBooksByAuthor(author).Select(e => new BookShortInfo() {Id = e.Id, Title = e.Title});
                model.SelectedAuthor = author;
            }
            libraryClient.Close();

            return View(model);
        }

        public ActionResult YearsOfPublication(int yearOfPublication = 0)
        {
            var libraryClient = new LibrarySoapClient();
            var model = new YearOfPublicationsViewModel();
            model.YearsOfPublication = libraryClient.GetYearsOfPublication();
            if (yearOfPublication!= 0)
            {
                model.PublicatedBooks =
                   libraryClient.GetBooks(yearOfPublication).Select(e => new BookShortInfo() { Id = e.Id, Title = e.Title });
                model.SelectedYear = yearOfPublication;
            }
            libraryClient.Close();
            return View(model);
        }

        public ActionResult AddBook()
        {
            return View(new AddBookViewModel());
        }

        [HttpPost]
        public ActionResult AddBook(AddBookViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var libraryClient = new LibrarySoapClient();
            libraryClient.AddBook(new BookData()
            {
                Author = model.Author,
                Title = model.Title,
                YearOfPublication = model.YearOfPublication.Value
            });
            libraryClient.Close();
            return RedirectToAction("Index");
        }

        public ActionResult BookDetails(int id)
        {
            var libraryRestClient = new LibraryRestClient();
            var model = libraryRestClient.GetBookInfoWithRest(id);
            libraryRestClient.Close();
            return View(model);
        }
    }
}