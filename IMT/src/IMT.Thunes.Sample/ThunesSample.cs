using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetEnv;
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
        public void CreateTransactionFromQuotationId()
        {
            CreateNewTransactionRequest request = new CreateNewTransactionRequest
            {
                credit_party_identifier = new CreditPartyIdentifier(),
                sender = new Sender(),
                beneficiary = new Beneficiary(),
                sending_business = new SendingBussiness(),
                receiving_business = new RecievingBussiness(),
                external_id = "1",
                purpose_of_remittance = "test"
            };
            int id = 1;
            var response = _thunesClient.CreateTransaction(id,request);
            Assert.NotNull(response);
        }
    }
}