﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMT.Thunes.Net;
using IMT.Thunes.Request;
using IMT.Thunes.Request.Common;
using IMT.Thunes.Response;
using IMT.Thunes.Route;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace IMT.Thunes.Adapter
{
    public class TransactionAdapter : BaseAdapter
    {
        public TransactionAdapter(RequestOptions requestOptions) : base(requestOptions)
        {

        }

        public object CreateTransaction(int id, CreateNewTransactionRequest request)
        {
            var url = ThunesUrl.CreateTransactionUrl.Replace("{id}", id.ToString());
            var result = RestClient.PostObject<CreateTransactionResponse>(RequestOptions.BaseUrl + url,CreateHeaders(request, ThunesUrl.CreateTransactionUrl, RequestOptions), request);
            return result;
        }
    }
}
