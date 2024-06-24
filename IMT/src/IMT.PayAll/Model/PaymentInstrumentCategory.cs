﻿
using System.Runtime.Serialization;


namespace IMT.PayAll.Model
{
    public enum PaymentInstrumentCategory
    {
        [EnumMember(Value = "MobileWallet")] MobileWallet,

        [EnumMember(Value = "BankAccount")] BankAccount,

        [EnumMember(Value = "CashPickup")] CashPickup,

        [EnumMember(Value = "Card")] Card

    }
}