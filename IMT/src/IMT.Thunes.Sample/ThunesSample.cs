using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetEnv;
using IMT.Thunes.Request.Common;
using IMT.Thunes.Request.CreditParties;
using IMT.Thunes.Request.Transaction.Quoatation;
using IMT.Thunes.Request.Transaction.Transfer;
using NUnit.Framework;

namespace IMT.Thunes.Sample
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
            CreateQuatationRequest request = new CreateQuatationRequest();
            var response = _thunesClient.QuotationAdapter().CreateQuatatioin(request);
            Assert.NotNull(response);
        }

        [Test]
        public void CreateQGetQuotationByIduatatioin()
        {
            int id = 1;
            var response = _thunesClient.QuotationAdapter().GetQuotationById(id);
            Assert.NotNull(response);
        }

        [Test]
        public void GetRetrieveQuotationByExternalId()
        {
            ulong id = 1234;
            var response = _thunesClient.QuotationAdapter().GetRetrieveQuotationByExternalId(id);
            Assert.NotNull(response);
        }

        [Test]
        public void CreditPartyInformation()
        {
            InformationRequest request = new InformationRequest();
            ulong id = 1;
            string transaction_type = "C2C";
            var response = _thunesClient.GetInformationAdapter().CreditPartyInformation(request, id, transaction_type);
            Assert.NotNull(response);
        }

        [Test]
        public void CreditPartyVerification()
        {
            InformationRequest request = new InformationRequest();
            ulong id = 1;
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
            ulong id = 1;
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
            ulong id = 1;
            var response = _thunesClient.GetAccountAdapter().GetReportDetail(id);
            Assert.NotNull(response);
        }

        [Test]
        public void ListReportsAvailableById()
        {
            ulong id = 1;
            var response = _thunesClient.GetAccountAdapter().ListReportsAvailable(id);
            Assert.NotNull(response);
        }

        [Test]
        public void GetReportFileDetails()
        {
            ulong id = 1;
            ulong report_id = 1;
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
            ulong id = 1;
            var response = _thunesClient.GetDiscoveryAdapter().PayerResponseDetails(id);
            Assert.NotNull(response);
        }

        [Test]
        public void PayerRateResponse()
        {
            ulong id = 1;
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
        
        [Test]
        public void CreateAttachmentToTransactionByExternalId()
        {
            AttachmentRequest request = new AttachmentRequest();
            int id = 1;
            var response = _thunesClient.CreateAttachmentToTransactionByExternalId(id, request);
            Assert.NotNull(response);
        } 

        [Test]
        public void ConfirmTransactionById()
        {
            int id = 1;
            var response = _thunesClient.ConfirmTransactionById(id);
            Assert.NotNull(response);
        }

        [Test]
        public void ConfirmTransactionByExternalId()
        {
            int id = 1;
            var response = _thunesClient.ConfirmTransactionByExternalId(id);
            Assert.NotNull(response);
        }
    }
}