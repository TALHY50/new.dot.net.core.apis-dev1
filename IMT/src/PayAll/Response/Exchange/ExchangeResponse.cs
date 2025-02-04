﻿using PayAll.Response.Common;

namespace PayAll.Response.Exchange
{
    public class ExchangeResponse
    {
        public Guid id { get; set; }
        public SourceAmount source_amount { get; set; }
        public TargetAmount target_amount { get; set; }
        public DateTime expiration_date { get; set; }
    }

}
