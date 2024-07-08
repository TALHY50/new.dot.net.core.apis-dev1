using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IMT.Application.Contracts.Requests.SendMoiney
{
    public class SendMoneyRequest
    {
        // Create quoatation request start
        [Required]
        [MaxLength(50)]
        public string OrderId { get; set; }

        [Required]
        [MaxLength(50)]
        public string PayerId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Mode { get; set; }

        [Required]
        [MaxLength(10)]
        public string TransactionType { get; set; }

        public decimal? SourceAmount { get; set; }

        public int? ImtSourceCurrencyId { get; set; }

        public int? ImtProviderId { get; set; }

        public int? ImtProviderServiceId { get; set; }

        public int? ImtSourceCountryId { get; set; }

        public decimal? DestinationAmount { get; set; }

        public int? ImtDestinationCurrencyId { get; set; }

        // Create quoatation request End

        // create money transfer request start
        public int Id { get; set; }

        public string? PaymentId { get; set; }

        public int? TransactionStateId { get; set; }

        public int? ReasonId { get; set; }

        public int? PaymentMethodId { get; set; }

        /// <summary>
        /// 1=instant, 2=regular, 3=same_day etc.
        /// </summary>
        public sbyte? TransferType { get; set; }

        public string? ReasonCode { get; set; }

        /// <summary>
        /// type 1 = b2b, 2 = c2c, 3=c2b, 4=b2c etc
        /// </summary>
        public sbyte? Type { get; set; }

        public string? SenderName { get; set; }

        public string? ReceiverName { get; set; }

        public int? SenderCurrencyId { get; set; }

        public int? ReceiverCurrencyId { get; set; }

        public decimal? ExchangeRate { get; set; }

        public decimal? SendAmount { get; set; }

        public decimal? ReceiveAmount { get; set; }

        public decimal? ExchangedAmount { get; set; }

        public decimal? Fee { get; set; }

        public decimal? Vat { get; set; }

        public string? CommissionPaidBy { get; set; }

        public int? SenderCustomerId { get; set; }

        public int? ReceiverCustomerId { get; set; }

        public string? Source { get; set; }

        public string? RemoteOrderId { get; set; }

        public string? InvoiceId { get; set; }
        // create money transfer request end

    }
}