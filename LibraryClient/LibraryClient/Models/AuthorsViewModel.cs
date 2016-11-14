using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryClient.Models
{
    public class AuthorsViewModel
    {
        public IEnumerable<string> Authors { get; set; } 
        public string SelectedAuthor { get; set; }
        public IEnumerable<BookShortInfo> PublicatedBooks { get; set; } 
    }
}