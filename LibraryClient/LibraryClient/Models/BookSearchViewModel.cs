using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibraryService.Contracts;

namespace LibraryClient.Models
{
    public class BookSearchViewModel
    {
        public IEnumerable<BookData> Books { get; set; }
        public string BookTitle { get; set; } 
    }
}