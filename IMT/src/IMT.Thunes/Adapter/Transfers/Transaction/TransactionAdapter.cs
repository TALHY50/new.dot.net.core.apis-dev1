using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMT.Thunes.Net;
using IMT.Thunes.Request.Common;
using IMT.Thunes.Request.Transaction.Transfer;
using IMT.Thunes.Response.Transfer.Transaction;
using IMT.Thunes.Route;
using Newtonsoft.Json;

namespace IMT.Thunes.Adapter.Transfers.Transaction
{
    public class TransactionAdapter : BaseAdapter
    {
        public TransactionAdapter(RequestOptions requestOptions) : base(requestOptions)
        {

        }

        public object CreateTransaction(int id, CreateNewTransactionRequest request)
        {
            var url = ThunesUrl.CreateTransactionUrl.Replace("{id}", id.ToString());
            return RestClient.Post<CreateTransactionResponse>(RequestOptions.BaseUrl + url, CreateHeaders(request, ThunesUrl.CreateTransactionUrl, RequestOptions), request);
        }

        public object CreateTransactionFromQuotationExternalId(int external_id, CreateNewTransactionRequest request)
        {
            var url = ThunesUrl.CreateTransactionFromQuotationExternalIdUrl.Replace("{external_id}", external_id.ToString());
            return RestClient.Post<CreateTransactionResponse>(RequestOptions.BaseUrl + url, CreateHeaders(request, ThunesUrl.CreateTransactionFromQuotationExternalIdUrl, RequestOptions), request);
        } 
        
        public object CreateAttachmentToTransactionById(int id, AttachmentRequest request)
        {
            var url = ThunesUrl.CreateAttachmentToTransactionByIdUrl.Replace("{id}", id.ToString());
            return RestClient.Post<TransactionAttachmentResponse>(RequestOptions.BaseUrl + url, CreateHeaders(request, ThunesUrl.CreateAttachmentToTransactionByIdUrl, RequestOptions), request);
        }  
        public object CreateAttachmentToTransactionByExternalId(int external_id, AttachmentRequest request)
        {
            var url = ThunesUrl.CreateAttachmentToTransactionByExternalIdUrl.Replace("{external_id}", external_id.ToString());
            return RestClient.Post<TransactionAttachmentResponse>(RequestOptions.BaseUrl + url, CreateHeaders(request, ThunesUrl.CreateAttachmentToTransactionByExternalIdUrl, RequestOptions), request);
        } 
        
        public object ConfirmTransactionById(int id)
        {
            var url = ThunesUrl.ConfirmTransactionByIdUrl.Replace("{id}", id.ToString());
           return RestClient.Post<TransactionAttachmentResponse>(RequestOptions.BaseUrl + url, CreateHeaders( ThunesUrl.ConfirmTransactionByIdUrl, RequestOptions),null);
        }
        
        public object ConfirmTransactionByExternalId(int external_id)
        {
            var url = ThunesUrl.ConfirmTransactionByExternalIdUrl.Replace("{external_id}", external_id.ToString());
           return RestClient.Post<TransactionAttachmentResponse>(RequestOptions.BaseUrl + url, CreateHeaders( ThunesUrl.ConfirmTransactionByExternalIdUrl, RequestOptions),null);
        }

        public object ListAttachmentsOfTransactionByExternalId(int external_id)
        {
            var url = ThunesUrl.ConfirmTransactionByExternalIdUrl.Replace("{external_id}", external_id.ToString());
           return RestClient.Get<List<TransactionAttachmentResponse>>(RequestOptions.BaseUrl + url, CreateHeaders( ThunesUrl.ConfirmTransactionByExternalIdUrl, RequestOptions));
        }

        public object RetrieveTransactionInformationByTransactionId(int id)
        {
            var url = ThunesUrl.RetrieveTransactionInformationByTransactionIdUrl.Replace("{id}", id.ToString());
           return RestClient.Get<TransactionAttachmentResponse>(RequestOptions.BaseUrl + url, CreateHeaders( ThunesUrl.RetrieveTransactionInformationByTransactionIdUrl, RequestOptions));
        }
        public object ListAttachmentsOfATransactionById(int id)
        {
            var url = ThunesUrl.ListAttachmentsOfATransactionByIdUrl.Replace("{id}", id.ToString());
           return RestClient.Get<List<TransactionAttachmentResponse>>(RequestOptions.BaseUrl + url, CreateHeaders( ThunesUrl.ListAttachmentsOfATransactionByIdUrl, RequestOptions));
        }

        public object RetrieveTransactionInformationByExternalId(int external_id)
        {
            var url = ThunesUrl.RetrieveTransactionInformationByExternalIdUrl.Replace("{external_id}", external_id.ToString());
           return RestClient.Get<TransactionAttachmentResponse>(RequestOptions.BaseUrl + url, CreateHeaders( ThunesUrl.RetrieveTransactionInformationByExternalIdUrl, RequestOptions));
        }
    }
}
