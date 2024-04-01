using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class SaleReport
{
    public uint Id { get; set; }

    public int SaleId { get; set; }

    public int? SaleBillingCreatedBy { get; set; }

    public string? SaleBillingCreatedByName { get; set; }

    public string? UserEndUserFirstName { get; set; }

    public string? UserEndUserLastName { get; set; }

    public string? UserEndUserEmail { get; set; }

    public string? UserEndUserPhone { get; set; }

    public sbyte? UserEndUserUserCategory { get; set; }

    public string? UserEndUserTcNumber { get; set; }

    public string? UserMerchantUserFirstName { get; set; }

    public string? UserMerchantUserLastName { get; set; }

    public string? UserMerchantUserEmail { get; set; }

    public string? UserMerchantUserPhone { get; set; }

    public string? UserMerchantUserTcNumber { get; set; }

    public string? MerchantMcc { get; set; }

    public string? MerchantTckn { get; set; }

    public string? MerchantVkn { get; set; }

    public string? MerchantContactPersonEmail { get; set; }

    public string? Ipv4CountryName { get; set; }

    /// <summary>
    /// 1=Unknown, 2=Windows, 3=Linux, 4=MAC, 5=IOS, 6=Android
    /// </summary>
    public sbyte? DeviceId { get; set; }

    public string? SaleRecurringPlanCode { get; set; }

    public int? SaleRecurringPaymentNumber { get; set; }

    public int? SaleRecurringHistoryRecurringNumber { get; set; }

    public string? SaleBillingCardHolderName { get; set; }

    public string? SaleBillingExtraCardHolderName { get; set; }

    public string? SaleBillingBillEmail { get; set; }

    public string? SaleBillingBillPhone { get; set; }

    public string? SaleBillingBillName { get; set; }

    public string? SaleBillingBillSurname { get; set; }

    public string? SaleBillingBillAddress1 { get; set; }

    public string? SaleBillingBillAddress2 { get; set; }

    public string? SaleBillingBillCity { get; set; }

    public string? SaleBillingBillPostcode { get; set; }

    public string? SaleBillingBillState { get; set; }

    public string? SaleBillingBillCountry { get; set; }

    public string? SaleBillingBillTckn { get; set; }

    public string? SaleBillingBillTaxNo { get; set; }

    public string? SaleBillingBillTaxOffice { get; set; }

    public sbyte? SaleBillingCustomerType { get; set; }

    public double? MerchantSaleMerchantCommissionPercentage { get; set; }

    public double? MerchantSaleMerchantCommissionFixed { get; set; }

    public double? MerchantSaleCotPercentage { get; set; }

    public double? MerchantSaleCotFixed { get; set; }

    public double? MerchantSaleMerchantRollingPercentage { get; set; }

    public double? MerchantSaleEndUserCommissionPercentage { get; set; }

    public double? MerchantSaleEndUserCommissionFixed { get; set; }

    public sbyte? MerchantSaleCardType { get; set; }

    public DateTime? MerchantSaleEffectiveDate { get; set; }

    public DateTime? MerchantSaleReportingSettlementDate { get; set; }

    public double? MerchantSaleRefundCommission { get; set; }

    public double? MerchantSaleRefundCommissionFixed { get; set; }

    public double? MerchantSaleChargebackCommission { get; set; }

    public double? MerchantSaleChargebackCommissionFixed { get; set; }

    public double? MerchantSalePayByTokenCommission { get; set; }

    public double? MerchantSalePayByTokenFixed { get; set; }

    public double? RollingBalanceAmount { get; set; }

    public DateTime? RollingBalanceEffectiveDate { get; set; }

    public double? SaleIntegratorCommissionPercentage { get; set; }

    public double? SaleIntegratorCommissionFixed { get; set; }

    public double? SaleIntegratorCommissionAmount { get; set; }

    public double? SaleIntegratorAmount { get; set; }

    public string? IntegratorFirstName { get; set; }

    public string? IntegratorLastName { get; set; }

    public string? IntegratorIntegratorName { get; set; }

    public string? IntegratorPhone { get; set; }

    public string? IntegratorEmail { get; set; }

    public string? SalePropertyErrorCode { get; set; }

    public string? SalePropertyCardCountryCode { get; set; }

    public sbyte? SalePropertyCardType { get; set; }

    public int? SalePropertyBankInstallmentNumber { get; set; }

    /// <summary>
    /// plus installment for pos campaign
    /// </summary>
    public sbyte? SalePropertyPlusInstallment { get; set; }

    public double? SalePropertyPreAuthAmount { get; set; }

    public string? SalePropertyMerchantServerId { get; set; }

    public string? SalePropertyRefererUrl { get; set; }

    public double? FpWalletUserFee { get; set; }

    public double? SaleTaxInfoBankInsuranceTaxDividend { get; set; }

    public double? SaleTaxInfoBankInsuranceTaxMultiplier { get; set; }

    public sbyte? MigrationStatus { get; set; }

    /// <summary>
    /// Remote(Pavo, Oxivo) Transaction Operation Type Name
    /// </summary>
    public string? RemoteOperationName { get; set; }

    /// <summary>
    /// Remote(Pavo, Oxivo) Transaction Acquirer Reference
    /// </summary>
    public string? RemoteAcquirerReference { get; set; }

    /// <summary>
    /// Remote(Pavo, Oxivo) Transaction Product Price
    /// </summary>
    public double? RemoteProductPrice { get; set; }

    /// <summary>
    /// Integrator_id from sale_integrators
    /// </summary>
    public int SaleIntegratorIntegratorId { get; set; }

    public double? CashbackAmount { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public sbyte? MerchantType { get; set; }

    /// <summary>
    /// Imported Transaction Merchant Terminal Id
    /// </summary>
    public string? MerchantTerminalId { get; set; }

    public string? RemoteSaleReferenceId { get; set; }

    public string? RemoteBkmSerialNo { get; set; }

    public int? SaleCurrencyConversionFromPosId { get; set; }

    public int? SaleCurrencyConversionToPosId { get; set; }

    public double? SaleCurrencyConversionConversionRate { get; set; }

    public double? SaleCurrencyConversionConvertedAmount { get; set; }

    public double? SaleCurrencyConversionOriginalAmount { get; set; }

    public double? SaleCurrencyConversionConvertedTotalRefundedAmount { get; set; }

    public string? SaleCurrencyConversionFromCurrency { get; set; }

    public string? SaleCurrencyConversionToCurrency { get; set; }

    /// <summary>
    /// 1=normal conversion,2=dcc conversion
    /// </summary>
    public sbyte? SaleCurrencyConversionConversionType { get; set; }

    public DateTime? SaleCurrencyConversionCreatedAt { get; set; }

    /// <summary>
    /// Authenticated user id
    /// </summary>
    public int ActionById { get; set; }
}
