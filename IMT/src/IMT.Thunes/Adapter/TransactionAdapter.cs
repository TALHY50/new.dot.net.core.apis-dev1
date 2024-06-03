using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMT.Thunes.Net;
using IMT.Thunes.Request;
using IMT.Thunes.Request.Common;
using IMT.Thunes.Response;
using IMT.Thunes.Route;

namespace IMT.Thunes.Adapter
{
    public class TransactionAdapter : BaseAdapter
    {
        public TransactionAdapter(RequestOptions requestOptions) : base(requestOptions)
        {

        }

        public object CreateTransaction(CreateNewTransactionRequest request)
        {
            var result = RestClient.PostObject<CreateTransactionResponse>(RequestOptions.BaseUrl + ThunesUrl.CreateTransactionUrl,
                CreateHeaders(request, ThunesUrl.CreateTransactionUrl, RequestOptions), request);
            return result;
        }
    }
}
