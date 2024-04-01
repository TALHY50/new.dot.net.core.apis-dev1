using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class CurrenciesSetting
{
    public int Id { get; set; }

    public int CurrencyId { get; set; }

    public double MinWithdrawAmount { get; set; }

    public double? MinCashoutToBank { get; set; }

    public double MaxBalanceOfNonVerifiedUser { get; set; }

    public double AmlMaxTransactionable { get; set; }

    public double AmlMaxP2pTransactionable { get; set; }

    public double AmlMaxTotalAllowedAmount { get; set; }

    public double AmlMaxTotalAllowedRange { get; set; }

    public double AmlMaxInputValue { get; set; }

    public double? TotalMoneyTransferMaxLimit { get; set; }

    public int? TotalMoneyTransferMaxTransaction { get; set; }

    public double? TotalMoneyTransferCommission { get; set; }

    public int? AmlMaxAllowedCreditCard { get; set; }

    public double? TotalReceiveMoneyMaxLimit { get; set; }

    public int? TotalReceiveMoneyMaxTransaction { get; set; }

    public double? TotalReceiveMoneyCommission { get; set; }

    public sbyte? UserType { get; set; }

    public double? MaxDepositContractor { get; set; }

    public double? MaxDepositVerified { get; set; }

    public double? MaxDepositUnverified { get; set; }

    public double? MaxDepositUnknown { get; set; }

    public double? MaxMoneyTransferContractorWalletToWallet { get; set; }

    public double? MaxMoneyTransferVerifiedWalletToWallet { get; set; }

    public double? MaxMoneyTransferUnverifiedWalletToWallet { get; set; }

    public double? MaxMoneyTransferUnknownWalletToWallet { get; set; }

    public double? MaxMoneyTransferContractorWalletToIban { get; set; }

    public double? MaxMoneyTransferVerifiedWalletToIban { get; set; }

    public double? MaxMoneyTransferUnverifiedWalletToIban { get; set; }

    public double? MaxMoneyTransferUnknownWalletToIban { get; set; }

    public double? MaxReceiveMoneyContractor { get; set; }

    public double? MaxReceiveMoneyVerified { get; set; }

    public double? MaxReceiveMoneyUnverified { get; set; }

    public double? MaxReceiveMoneyUnknown { get; set; }

    public double? MaxWithdrawContractor { get; set; }

    public double? MaxWithdrawVerified { get; set; }

    public double? MaxWithdrawUnverified { get; set; }

    public double? MaxWithdrawUnknown { get; set; }

    public double? MaxBalanceLimitContractor { get; set; }

    public double? MaxBalanceLimitVerified { get; set; }

    public double? MaxBalanceLimitUnverified { get; set; }

    public double? MaxBalanceLimitUnknown { get; set; }

    public double? MaxAutomationCashoutLimit { get; set; }

    public double? MaxAutomationCashoutLimitMerchant { get; set; }

    public double? MaxAutomationB2cLimit { get; set; }

    /// <summary>
    /// if total  sent amount  is more than  75K, validate  tckn  for  merchant, if total  received amount  is more than  75K, validate  tckn  for  customer
    /// </summary>
    public double? MaxKycB2cLimit { get; set; }

    public double? MaxAutomationWalletgateLimit { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// max withdrawal limit for finflow during off hour or off day
    /// </summary>
    public double? MaxCashoutLimitOffTime { get; set; }

    /// <summary>
    /// max b2c to bank limit for finflow during off hour or off day
    /// </summary>
    public double? MaxB2cLimitOffTime { get; set; }
}
