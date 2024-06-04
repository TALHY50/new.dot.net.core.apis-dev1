using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMT.Thunes.Net;
using IMT.Thunes.Request.Common;
using IMT.Thunes.Request.CreditParties;
using IMT.Thunes.Response.CreditParties;

namespace IMT.Thunes.Adapter.CreditParties
{
    public class Information : BaseAdapter
    {
        public Information(RequestOptions requestOptions) : base(requestOptions)
        {
            
        }

        public InformationResponse CreditPartyInformation(InformationRequest request)
        {
            return RestClient.Post()
        }

    }
}