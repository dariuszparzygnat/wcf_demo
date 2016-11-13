using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Contracts
{
    [ServiceContract]
    public interface ILibraryRest
    {
        [OperationContract]
        [WebGet(UriTemplate ="/GetBooksWithRest", ResponseFormat = WebMessageFormat.Json,
 BodyStyle = WebMessageBodyStyle.Wrapped)]
        IEnumerable<BookRestData> GetBooksWithRest();
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json,
BodyStyle = WebMessageBodyStyle.Wrapped)]
        BookRestData GetBookInfoWithRest(string title);

        [OperationContract]
        [WebInvoke(UriTemplate = "/AddBookWithRest?title={title}&author={author}&yearOfPublication={yearOfPublication}", Method = "POST")]
        string AddBookWithRest(string title, string author, string yearOfPublication);


    }
}
