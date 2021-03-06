﻿using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace LibraryService.Contracts
{
    [ServiceContract]
    public interface ILibraryRest
    {
        [OperationContract]
        [WebGet(UriTemplate ="/GetBooksWithRest", ResponseFormat = WebMessageFormat.Json,
 BodyStyle = WebMessageBodyStyle.Bare)]
        IEnumerable<BookRestData> GetBooksWithRest();
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json,
BodyStyle = WebMessageBodyStyle.Wrapped)]
        BookRestData GetBookInfoWithRest(int bookId);

        [OperationContract]
        [WebInvoke(UriTemplate = "/AddBookWithRest?title={title}&author={author}&yearOfPublication={yearOfPublication}", Method = "POST")]
        string AddBookWithRest(string title, string author, string yearOfPublication);
    }
}
