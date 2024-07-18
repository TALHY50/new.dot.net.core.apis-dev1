using Microsoft.AspNetCore.Http;
using PayAll.Net;
using PayAll.Request.Common;
using PayAll.Response.Compliance;
using PayAll.Route;

namespace PayAll.Adapter.Compliance
{
    public class ComplianceAdapter : BaseAdapter
    {
        public ComplianceAdapter(RequestOptions requestOptions) : base(requestOptions)
        {
        }

        public ComplianceResponse UploadNewComplianceDocument(IFormFile file)
        {
            var path = PayAllUrl.UploadNewComplianceDocumentUrl;
            return RestClient.Post<ComplianceResponse>(RequestOptions.BaseUrl + path,
                CreateHeaders(file, path, RequestOptions),
                file);


        }
    }
}
