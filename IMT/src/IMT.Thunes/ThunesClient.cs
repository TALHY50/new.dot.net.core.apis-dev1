//using IMT.Thunes.Adapter;
using IMT.Thunes.Adapter.Account;
using IMT.Thunes.Adapter.CreditParties;
using IMT.Thunes.Adapter.Transfers.Quotations;
using IMT.Thunes.Adapter.Transfers.Transaction;
using IMT.Thunes.Request.Common;
using IMT.Thunes.Request.Transaction.Transfer;
using IMT.Thunes.Response;

namespace IMT.Thunes
{
    public class ThunesClient
    {
        private const string BaseUrl = "https://xyz";

        private readonly QuotationAdapter _quotationAdapter;
        private readonly InformationAdapter _information_adapter;
        private readonly TransactionAdapter _transactionAdapter;
        private readonly VerificationAdapter _verificationAdapter;
        private readonly AccountAdapter _accountAdapter;

        public ThunesClient(string apiKey, string secretKey)
            : this(apiKey, secretKey, BaseUrl, null)
        {
        }

        public ThunesClient(string apiKey, string secretKey, string baseUrl, string language = null)
        {
            var requestOptions = new RequestOptions
            {
                ApiKey = apiKey,
                SecretKey = secretKey,
                BaseUrl = baseUrl,
                Language = language
            };
            this._quotationAdapter = new QuotationAdapter(requestOptions);
            this._information_adapter = new InformationAdapter(requestOptions);
            this._transactionAdapter = new TransactionAdapter(requestOptions);
            this._verificationAdapter = new VerificationAdapter(requestOptions);
            this._accountAdapter = new AccountAdapter(requestOptions);
        }

        public QuotationAdapter QuotationAdapter()
        {
            return this._quotationAdapter;
        }

        public InformationAdapter GetInformationAdapter()
        {
            return this._information_adapter;
        }

        public object CreateTransaction(int id, CreateNewTransactionRequest request)
        {
            return _transactionAdapter.CreateTransaction(id, request);
        }

        public object CreateTransactionFromQuotationExternalId(int external_id, CreateNewTransactionRequest request)
        {
            return _transactionAdapter.CreateTransactionFromQuotationExternalId(external_id, request);
        } 
        public object CreateAttachmentToTransactionById(int id, AttachmentRequest request)
        {
            return _transactionAdapter.CreateAttachmentToTransactionById(id, request);
        }
        
        public object CreateAttachmentToTransactionByExternalId(int external_id, AttachmentRequest request)
        {
            return _transactionAdapter.CreateAttachmentToTransactionByExternalId(external_id, request);
        }

        public object ConfirmTransactionById(int id)
        {
            return _transactionAdapter.ConfirmTransactionById(id);
        }

        public object ConfirmTransactionByExternalId(int external_id)
        {
            return _transactionAdapter.ConfirmTransactionByExternalId(external_id);
        }

        public object RetrieveTransactionInformationByTransactionId(int id)
        {
            return _transactionAdapter.RetrieveTransactionInformationByTransactionId(id);
        }
        
        public object ListAttachmentsOfATransactionById(int id)
        {
            return _transactionAdapter.ListAttachmentsOfATransactionById(id);
        }
        public object RetrieveTransactionInformationByExternalId(int external_id)
        {
            return _transactionAdapter.RetrieveTransactionInformationByExternalId(external_id);
        }

        public VerificationAdapter VerificationAdapter()
        {
            return this._verificationAdapter;
        }

        public AccountAdapter GetAccountAdapter()
        {
            return this._accountAdapter;
        }


    }
}
