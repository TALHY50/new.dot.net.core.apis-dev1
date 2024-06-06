﻿using IMT.PayAll.Adapter;
using IMT.PayAll.Request.Common;

namespace IMT.PayAll
{
    public class PayAllClient
    {
        private const string BaseUrl = "https://api.sandbox.payall.com";
        private readonly PaymentAdapter _paymentAdapter;
        private readonly PaymentInstrumentAdapter _paymentInstrumentAdapter;
        private readonly ExchangeAdapter _exchangeAdapter;

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

    
    }
}