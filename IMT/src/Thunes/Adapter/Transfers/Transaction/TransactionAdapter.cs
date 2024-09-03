using Thunes.Net;
using Thunes.Request.Common;
using Thunes.Request.Transaction.Transfer.CommonTransaction;
using Thunes.Response.Transfer.Transaction;
using Thunes.Route;

namespace Thunes.Adapter.Transfers.Transaction
{
    public class TransactionAdapter : BaseAdapter
    {
        public TransactionAdapter(RequestOptions requestOptions) : base(requestOptions)
        {

        }

        public object CreateTransaction(uint id, MoneyTransferDTO request)
        {
            var url = ThunesUrl.CreateTransactionUrl.Replace("{id}", id.ToString());
            return RestClient.Post<CreateTransactionResponse>(RequestOptions.BaseUrl + url, CreateHeaders(request, ThunesUrl.CreateTransactionUrl, RequestOptions), request);
        }

        public object CreateTransactionFromQuotationExternalId(string invoice_id, MoneyTransferDTO request)
        {
            var url = ThunesUrl.CreateTransactionFromQuotationExternalIdUrl.Replace("{invoice_id}", invoice_id.ToString());
            return RestClient.Post<CreateTransactionResponse>(RequestOptions.BaseUrl + url, CreateHeaders(request, ThunesUrl.CreateTransactionFromQuotationExternalIdUrl, RequestOptions), request);
        } 
        
        public object CreateAttachmentToTransactionById(int id, AttachmentRequest request)
        {
            var url = ThunesUrl.CreateAttachmentToTransactionByIdUrl.Replace("{id}", id.ToString());
            return RestClient.Post<TransactionAttachmentResponse>(RequestOptions.BaseUrl + url, CreateHeaders(request, ThunesUrl.CreateAttachmentToTransactionByIdUrl, RequestOptions), request);
        }  
        public object CreateAttachmentToTransactionByExternalId(string invoice_id, AttachmentRequest request)
        {
            var url = ThunesUrl.CreateAttachmentToTransactionByExternalIdUrl.Replace("{invoice_id}", invoice_id.ToString());
            return RestClient.Post<TransactionAttachmentResponse>(RequestOptions.BaseUrl + url, CreateHeaders(request, ThunesUrl.CreateAttachmentToTransactionByExternalIdUrl, RequestOptions), request);
        } 
        
        public ConfirmTransactionResponse ConfirmTransactionById(int id)
        {
            var url = ThunesUrl.ConfirmTransactionByIdUrl.Replace("{id}", id.ToString());
           return RestClient.Post<ConfirmTransactionResponse>(RequestOptions.BaseUrl + url, CreateHeaders( ThunesUrl.ConfirmTransactionByIdUrl, RequestOptions),null);
        }
        
        public object ConfirmTransactionByExternalId(string invoice_id)
        {
            var url = ThunesUrl.ConfirmTransactionByExternalIdUrl.Replace("{invoice_id}", invoice_id.ToString());
           return RestClient.Post<ConfirmTransactionResponse>(RequestOptions.BaseUrl + url, CreateHeaders( ThunesUrl.ConfirmTransactionByExternalIdUrl, RequestOptions),null);
        }
        
        public object CancelTransactionByExternalId(string invoice_id)
        {
            var url = ThunesUrl.CancelTransactionByExternalIdUrl.Replace("{invoice_id}", invoice_id.ToString());
           return RestClient.Post<CreateTransactionResponse>(RequestOptions.BaseUrl + url, CreateHeaders( ThunesUrl.CancelTransactionByExternalIdUrl, RequestOptions),null);
        }
 
        public object CancelTransactionById(int id)
        {
            var url = ThunesUrl.CancelTransactionByIdUrl.Replace("{id}", id.ToString());
           return RestClient.Post<CreateTransactionResponse>(RequestOptions.BaseUrl + url, CreateHeaders( ThunesUrl.CancelTransactionByIdUrl, RequestOptions),null);
        }

        public object ListAttachmentsOfTransactionByExternalId(string invoice_id)
        {
            var url = ThunesUrl.ListAttachmentsOfTransactionByExternalIdUrl.Replace("{invoice_id}", invoice_id.ToString());
           return RestClient.Get<List<TransactionAttachmentResponse>>(RequestOptions.BaseUrl + url, CreateHeaders( ThunesUrl.ListAttachmentsOfTransactionByExternalIdUrl, RequestOptions));
        }

        public object RetrieveTransactionInformationByTransactionId(int id)
        {
            var url = ThunesUrl.RetrieveTransactionInformationByTransactionIdUrl.Replace("{id}", id.ToString());
           return RestClient.Get<CreateTransactionResponse>(RequestOptions.BaseUrl + url, CreateHeaders( ThunesUrl.RetrieveTransactionInformationByTransactionIdUrl, RequestOptions));
        }
        public object ListAttachmentsOfATransactionById(int id)
        {
            var url = ThunesUrl.ListAttachmentsOfATransactionByIdUrl.Replace("{id}", id.ToString());
           return RestClient.Get<List<TransactionAttachmentResponse>>(RequestOptions.BaseUrl + url, CreateHeaders( ThunesUrl.ListAttachmentsOfATransactionByIdUrl, RequestOptions));
        }

        public object RetrieveTransactionInformationByExternalId(string invoice_id)
        {
            var url = ThunesUrl.RetrieveTransactionInformationByExternalIdUrl.Replace("{invoice_id}", invoice_id.ToString());
           return RestClient.Get<CreateTransactionResponse>(RequestOptions.BaseUrl + url, CreateHeaders( ThunesUrl.RetrieveTransactionInformationByExternalIdUrl, RequestOptions));
        }
    }
}
