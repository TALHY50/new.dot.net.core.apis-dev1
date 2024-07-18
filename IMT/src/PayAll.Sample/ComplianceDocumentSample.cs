using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using NUnit.Framework;
using PayAll.Common;

namespace PayAll.Sample
{
    public class ComplianceDocumentSample
    {
        private readonly PayAllClient _payAllClient;
        public ComplianceDocumentSample()
        {
            var requirement = BaseRequirement.GetBaseRequirement(BaseSample.ServerEnvironment);
            _payAllClient = new PayAllClient(requirement.ClientID, requirement.ClientSecret, requirement.BaseUrl);
        }

        [Test]
        public void GetPaymentAccountsList()
        {
            var content = Encoding.UTF8.GetBytes("This is a fake PDF content.");
            var file = CreateFakeFormFile("Test.pdf", "application/pdf", content);
            var result = _payAllClient.UploadNewComplianceDocument(file);
            Assert.NotNull(result);
        }

        public static IFormFile CreateFakeFormFile(string fileName, string contentType, byte[] content)
        {
            var stream = new MemoryStream(content);
            return new FormFile(stream, 0, content.Length, "name", fileName)
            {
                Headers = new HeaderDictionary(),
                ContentType = contentType
            };
        }
    }
}
