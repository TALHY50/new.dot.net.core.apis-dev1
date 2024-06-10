using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMT.PayAll.Net;
using IMT.PayAll.Request.Common;
using IMT.PayAll.Response.Compliance;
using IMT.PayAll.Route;
using Microsoft.AspNetCore.Http;

namespace IMT.PayAll.Adapter.Compliance
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
