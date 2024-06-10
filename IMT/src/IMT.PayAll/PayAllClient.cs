﻿using IMT.PayAll.Adapter;
using IMT.PayAll.Adapter.Compliance;
using IMT.PayAll.Adapter.Discovery;
using IMT.PayAll.Request.Common;
using IMT.PayAll.Response.Compliance;
using Microsoft.AspNetCore.Http;

namespace IMT.PayAll
{
    public class PayAllClient
    {
        private const string BaseUrl = "https://api.sandbox.payall.com";
        private readonly PaymentAdapter _paymentAdapter;
        private readonly PaymentInstrumentAdapter _paymentInstrumentAdapter;
        private readonly ExchangeAdapter _exchangeAdapter;
        private readonly AccountsAdapter _accountsAdapter;
        private readonly RecipientsAdapter _recipientsAdapter;
        private readonly DiscoveryAdapter _discoveryAdapter;
        private readonly ComplianceAdapter _complianceAdapter;

        public PayAllClient(string clientId, string clientSecret)
            : this(clientId, clientSecret, BaseUrl, null)
        {
        }

        public PayAllClient(string clientId, string clientSecret, string baseUrl)
            : this(clientId, clientSecret, baseUrl, null)
        {
        }

        public PayAllClient(string clientId, string clientSecret, string baseUrl, string language)
        {
            var requestOptions = new RequestOptions
            {
                ClientID = clientId,
                ClientSecret = clientSecret,
                BaseUrl = baseUrl
            };


            _paymentAdapter = new PaymentAdapter(requestOptions);
            _paymentInstrumentAdapter = new PaymentInstrumentAdapter(requestOptions);
            _exchangeAdapter = new ExchangeAdapter(requestOptions);
            _accountsAdapter = new AccountsAdapter(requestOptions);
            _recipientsAdapter = new RecipientsAdapter(requestOptions);
            _discoveryAdapter = new DiscoveryAdapter(requestOptions);
            _complianceAdapter = new ComplianceAdapter(requestOptions);
        }

        public PaymentAdapter Payment()
        {
            return _paymentAdapter;
        }
        public PaymentInstrumentAdapter PaymentInstruments()
        {
            return _paymentInstrumentAdapter;
        }
        public ExchangeAdapter Exchanges()
        {
            return _exchangeAdapter;
        }
        public AccountsAdapter Accounts()
        {
            return _accountsAdapter;
        }
        public RecipientsAdapter Recipients()
        {
            return _recipientsAdapter;
        }

        public DiscoveryAdapter Discovery()
        {
            return _discoveryAdapter;
        }

        public ComplianceResponse UploadNewComplianceDocument(IFormFile file)
        {
            return _complianceAdapter.UploadNewComplianceDocument(file);
        }
    }
}
