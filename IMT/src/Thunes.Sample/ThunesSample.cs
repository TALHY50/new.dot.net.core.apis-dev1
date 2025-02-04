using DotNetEnv;
using NUnit.Framework;
using Thunes.Request.Common;
using Thunes.Request.CreditParties;
using Thunes.Request.Transaction.Quoatation;
using Thunes.Request.Transaction.Transfer.CommonTransaction;

namespace Thunes.Sample
{
    public class ThunesSample
    {

        private readonly ThunesClient _thunesClient;
        public ThunesSample()
        {
            Env.NoClobber().TraversePath().Load();
            string apiSecret = Env.GetString("API_SECRET");
            string apiKey = Env.GetString("API_KEY");
            string baseUrl = Env.GetString("BASE_URL");
            _thunesClient = new ThunesClient(apiSecret, apiKey, baseUrl);
        }

        [Test]
        public void CreateQuatatioin()
        {
            CreateQuotationRequest request = new CreateQuotationRequest();
            var response = _thunesClient.QuotationAdapter().CreateQuotation(request);
            Assert.NotNull(response);
        }

        [Test]
        public void CreateQGetQuotationByIduatatioin()
        {
            uint id = 1;
            var response = _thunesClient.QuotationAdapter().GetQuotationById(id);
            Assert.NotNull(response);
        }

        [Test]
        public void GetRetrieveQuotationByExternalId()
        {
            uint id = 1234;
            var response = _thunesClient.QuotationAdapter().GetQuotationByExternalId(id.ToString());
            Assert.NotNull(response);
        }

        [Test]
        public void CreditPartyInformation()
        {
            InformationRequest request = new InformationRequest();
            uint id = 1;
            string transaction_type = "C2C";
            var response = _thunesClient.GetInformationAdapter().CreditPartyInformation(request, id, transaction_type);
            Assert.NotNull(response);
        }

        [Test]
        public void CreditPartyVerification()
        {
            InformationRequest request = new InformationRequest();
            uint id = 1;
            string transaction_type = "C2C";
            _thunesClient.GetInformationAdapter().CreditPartyInformation(request, id, transaction_type);
            var response = _thunesClient.VerificationAdapter().CreditPartyVerification(id, transaction_type, request);
            Assert.NotNull(response);
        }

        [Test]
        public void GetBalanceResponse()
        {
            var response = _thunesClient.GetAccountAdapter().GetBalanceResponse();
            Assert.NotNull(response);
        }

        [Test]
        public void GetBalanceMovement()
        {
            uint id = 1;
            DateTime from_date = DateTime.UtcNow;
            DateTime to_date = DateTime.UtcNow;
            var response = _thunesClient.GetAccountAdapter().GetBalanceMovement(id, from_date, to_date);
            Assert.NotNull(response);
        }

        [Test]
        public void ListReportsAvailable()
        {
            string queryParams = null;
            var response = _thunesClient.GetAccountAdapter().ListReportsAvailable(queryParams);
            Assert.NotNull(response);
        }

        [Test]
        public void GetReportDetail()
        {
            uint id = 1;
            var response = _thunesClient.GetAccountAdapter().GetReportDetail(id);
            Assert.NotNull(response);
        }

        [Test]
        public void ListReportsAvailableById()
        {
            uint id = 1;
            var response = _thunesClient.GetAccountAdapter().ListReportsAvailable(id);
            Assert.NotNull(response);
        }

        [Test]
        public void GetReportFileDetails()
        {
            uint id = 1;
            uint report_id = 1;
            var response = _thunesClient.GetAccountAdapter().GetReportFileDetails(report_id, id);
            Assert.NotNull(response);
        }

        [Test]
        public void ServiceResponse()
        {
            var response = _thunesClient.GetDiscoveryAdapter().ServiceResponse();
            Assert.NotNull(response);
        }

        [Test]
        public void PayerResponse()
        {
            var response = _thunesClient.GetDiscoveryAdapter().PayerResponse();
            Assert.NotNull(response);
        }

        [Test]
        public void PayerResponseDetails()
        {
            uint id = 1;
            var response = _thunesClient.GetDiscoveryAdapter().PayerResponseDetails(id);
            Assert.NotNull(response);
        }

        [Test]
        public void PayerRateResponse()
        {
            uint id = 1;
            var response = _thunesClient.GetDiscoveryAdapter().PayerRateResponse(id);
            Assert.NotNull(response);
        }

        [Test]
        public void CountryResponse()
        {
            var response = _thunesClient.GetDiscoveryAdapter().CountryResponse();
            Assert.NotNull(response);
        }

        [Test]
        public void LookupResponse()
        {
            string swift_bic_code = "C2C";
            var response = _thunesClient.GetDiscoveryAdapter().LookupResponse(swift_bic_code);
            Assert.NotNull(response);
        }

        #region Transaction Transfer
       
        [Test]
        public void CreateTransaction()
        {
            MoneyTransferDTO request = new MoneyTransferDTO
            {
                credit_party_identifier = new CreditPartyIdentifier(),
                sending_business = new SendingBusiness(),
                receiving_business = new ReceivingBusinesss(),
                invoice_id = "1",
                purpose_of_remittance = "test"
            };
            uint id = 1;
            var response = _thunesClient.GetTransactionAdapter().CreateTransaction(id, request);
            Assert.NotNull(response);
        } 
        
        [Test]
        public void CreateTransactionFromQuotationExternalId()
        {
            MoneyTransferDTO request = new MoneyTransferDTO
            {
                credit_party_identifier = new CreditPartyIdentifier(),
                sender = new Sender(),
                beneficiary = new Beneficiary(),
                sending_business = new SendingBusiness(),
                receiving_business = new ReceivingBusinesss(),
                invoice_id = "1",
                purpose_of_remittance = "test"
            };
            int id = 1;
            var response = _thunesClient.GetTransactionAdapter().CreateTransactionFromQuotationExternalId(id.ToString(), request);
            Assert.NotNull(response);
        } 
        
        [Test]
        public void CreateAttachmentToTransactionById()
        {
            AttachmentRequest request = new AttachmentRequest();
            int id = 1;
            var response = _thunesClient.GetTransactionAdapter().CreateAttachmentToTransactionById(id, request);
            Assert.NotNull(response);
        } 

        [Test]
        public void CreateAttachmentToTransactionByExternalId()
        {
            AttachmentRequest request = new AttachmentRequest();
            int id = 1;
            var response = _thunesClient.GetTransactionAdapter().CreateAttachmentToTransactionByExternalId(id.ToString(), request);
            Assert.NotNull(response);
        } 

        [Test]
        public void ConfirmTransactionById()
        {
            int id = 1;
            var response = _thunesClient.GetTransactionAdapter().ConfirmTransactionById(id);
            Assert.NotNull(response);
        }

        [Test]
        public void ConfirmTransactionByExternalId()
        {
            int id = 1;
            var response = _thunesClient.GetTransactionAdapter().ConfirmTransactionByExternalId(id.ToString());
            Assert.NotNull(response);
        }

        [Test]
        public void RetrieveTransactionInformationByTransactionId()
        {
            int id = 1;
            var response = _thunesClient.GetTransactionAdapter().RetrieveTransactionInformationByTransactionId(id);
            Assert.NotNull(response);
        }

        [Test]
        public void RetrieveTransactionInformationByExternalId()
        {
            int id = 1;
            var response = _thunesClient.GetTransactionAdapter().RetrieveTransactionInformationByExternalId(id.ToString());
            Assert.NotNull(response);
        }

        [Test]
        public void ListAttachmentsOfATransactionById()
        {
            int id = 1;
            var response = _thunesClient.GetTransactionAdapter().ListAttachmentsOfATransactionById(id);
            Assert.NotNull(response);
        }

        [Test]
        public void ListAttachmentsOfTransactionByExternalId()
        {
            int id = 1;
            var response = _thunesClient.GetTransactionAdapter().ListAttachmentsOfTransactionByExternalId(id.ToString());
            Assert.NotNull(response);
        }

        [Test]
        public void CancelTransactionById()
        {
            int id = 1;
            var response = _thunesClient.GetTransactionAdapter().CancelTransactionById(id);
            Assert.NotNull(response);
        }

        [Test]
        public void CancelTransactionByExternalId()
        {
            int id = 1;
            var response = _thunesClient.GetTransactionAdapter().CancelTransactionByExternalId(id.ToString());
            Assert.NotNull(response);
        }
        #endregion

        [Test]
        public void Ping()
        {
            var response = _thunesClient.GetConnectivityAdapter().Ping();
            Assert.NotNull(response);
        }
    }
}