﻿using System.Collections.Generic;
using System.ServiceModel;
using LibraryService.Contracts;

namespace LibraryClient.Proxies
{
    public class LibraryRestClient : ClientBase<ILibraryRest>, ILibraryRest
    {
        public IEnumerable<BookRestData> GetBooksWithRest()
        {
            return Channel.GetBooksWithRest();
        }

        public BookRestData GetBookInfoWithRest(int bookId)
        {
            return Channel.GetBookInfoWithRest(bookId);
        }

        public string AddBookWithRest(string title, string author, string yearOfPublication)
        {
            return Channel.AddBookWithRest(title, author, yearOfPublication);
        }
    }
}