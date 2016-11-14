using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryClient.Models
{
    public class YearOfPublicationsViewModel
    {
        public IEnumerable<int> YearsOfPublication { get; set; }
        public int SelectedYear { get; set; }
        public IEnumerable<BookShortInfo> PublicatedBooks { get; set; }
    }
}