namespace SharedLibrary.Models;
using Newtonsoft.Json;

public partial class Currency
{
    [JsonProperty("id")]
    public uint Id { get; set; }

    [JsonProperty("name")]
    public string? Name { get; set; }

    [JsonProperty("symbol")]
    public string? Symbol { get; set; }

    /// <summary>
    /// for default wallet user currency
    /// </summary>
    [JsonProperty("is_wallet_user_default_currency")]
    public bool IsWalletUserDefaultCurrency { get; set; }

    /// <summary>
    /// for merchant default currency 
    /// </summary>
    [JsonProperty("is_merchant_default_currency")]
    public bool IsMerchantDefaultCurrency { get; set; }

    [JsonProperty("created_at")]
    public DateTime? CreatedAt { get; set; }

    [JsonProperty("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    [JsonProperty("code")]
    public string? Code { get; set; }

    [JsonProperty("iso_code")]
    public int? IsoCode { get; set; }

    [JsonProperty("max_transactionable")]
    public double? MaxTransactionable { get; set; }

    [JsonProperty("max_p2p_transactionable")]
    public double? MaxP2pTransactionable { get; set; }

    [JsonProperty("max_total_allowed_amount")]
    public double? MaxTotalAllowedAmount { get; set; }

    [JsonProperty("max_total_allowed_range")]
    public double? MaxTotalAllowedRange { get; set; }

    [JsonProperty("max_input_value")]
    public double? MaxInputValue { get; set; }

    public const int TRY = 1;
    public const int USD = 2;
    public const int EUR = 3;
    public const int RUB = 4;
    public const int GBP = 5;
    public const int AZN = 6;

    public static readonly List<int> CURRENCY_IDS = new List<int> {
        TRY,
        USD,
        EUR,
        RUB,
        GBP,
        AZN,

    };

    public const int TRY_ISO_CODE = 949;
    public const int USD_ISO_CODE = 840;
    public const int EUR_ISO_CODE = 978;
    public const int RUB_ISO_CODE = 643;
    public const int GBP_ISO_CODE = 826;
    public const int AZN_ISO_CODE = 944;
    public const string TRY_CODE = "TRY";
    public const string USD_CODE = "USD";
    public const string EUR_CODE = "EUR";
    public const string RUB_CODE = "RUB";
    public const string GBP_CODE = "GBP";
    public const string AZN_CODE = "AZN";

    public static readonly Dictionary<string, int> CURRENCY_CODES = new Dictionary<string, int> {
        { TRY_CODE, TRY },
        { USD_CODE, USD },
        { EUR_CODE, EUR },
        { RUB_CODE, RUB },
        { GBP_CODE, GBP},
        { AZN_CODE, AZN}
    };

    public const string TRY_SM_CODE = "TL";
    public const string USD_SM_CODE = "US";
    public const string EUR_SM_CODE = "EU";
    public const string RUB_SM_CODE = "RUB";
    public const string GBP_SM_CODE = "GBP";
    public const string AZN_SM_CODE = "AZN";
    public const string TRY_SYMBOL = "₺";
    public const string USD_SYMBOL = "$";
    public const string EUR_SYMBOL = "€";
    public const string RUB_SYMBOL = "₽";
    public const string GBP_SYMBOL = "£";
    public const string AZN_SYMBOL = "₼";
    public const string TRY_NAME = "Turkish Lira";
    public const string USD_NAME = "Us Dollar";
    public const string EUR_NAME = "Euro";
    public const string RUB_NAME = "Ruble";
    public const string GBP_NAME = "Pound";
    public const string AZN_NAME = "Azerbaijani manat";

    public static readonly Dictionary<int, DTOs.Currency> ALL_CURRENCY_LIST = new Dictionary<int, DTOs.Currency> {
        { TRY,new DTOs.Currency{ CODE= TRY_CODE, ISO_CODE= TRY_ISO_CODE, NAME= TRY_NAME, SYMBOL= TRY_SYMBOL} },
        { USD,new DTOs.Currency{ CODE= USD_CODE, ISO_CODE= USD_ISO_CODE, NAME= USD_NAME, SYMBOL= USD_SYMBOL} },
        { EUR,new DTOs.Currency{ CODE= EUR_CODE, ISO_CODE= EUR_ISO_CODE, NAME= EUR_NAME, SYMBOL= EUR_SYMBOL} },
        { RUB,new DTOs.Currency{ CODE= RUB_CODE, ISO_CODE= RUB_ISO_CODE, NAME= RUB_NAME, SYMBOL= RUB_SYMBOL} },
        { GBP,new DTOs.Currency{ CODE= GBP_CODE, ISO_CODE= GBP_ISO_CODE, NAME= GBP_NAME, SYMBOL= GBP_SYMBOL} },
        { AZN,new DTOs.Currency{ CODE= AZN_CODE, ISO_CODE= AZN_ISO_CODE, NAME= AZN_NAME, SYMBOL= AZN_SYMBOL} }
    };

    public static string GetSmallCodeByIso(int? isoCode)
    {
        var currencyCodeArray = new Dictionary<int?, string>
            {
                                { Currency.TRY_ISO_CODE, Currency.TRY_SM_CODE },
                                { Currency.USD_ISO_CODE, Currency.USD_SM_CODE },
                                { Currency.EUR_ISO_CODE, Currency.EUR_SM_CODE },
                                { Currency.RUB_ISO_CODE, Currency.RUB_SM_CODE },
                                { Currency.GBP_ISO_CODE, Currency.GBP_SM_CODE },
                                { Currency.AZN_ISO_CODE, Currency.AZN_SM_CODE },
            };

        if (currencyCodeArray[isoCode] != null)
        {
            return currencyCodeArray[isoCode];
        }
        return null!;
    }

    public static string GetSmallCodeByCode(string code)
    {
        var currencyCodeArray = new Dictionary<string, string>
            {
                                { Currency.TRY_CODE, Currency.TRY_SM_CODE },
                                { Currency.USD_CODE, Currency.USD_SM_CODE },
                                { Currency.EUR_CODE, Currency.EUR_SM_CODE },
                                { Currency.RUB_CODE, Currency.RUB_SM_CODE },
                                { Currency.GBP_CODE, Currency.GBP_SM_CODE },
                                { Currency.AZN_CODE, Currency.AZN_SM_CODE },
            };

        if (currencyCodeArray[code] != null)
        {
            return currencyCodeArray[code];
        }
        return null!;
    }

    public static string GetSmallCodeById(int? id)
    {
        var currencyCodeArray = new Dictionary<int?, string>
            {
                                { Currency.TRY, Currency.TRY_SM_CODE },
                                { Currency.USD, Currency.USD_SM_CODE },
                                { Currency.EUR, Currency.EUR_SM_CODE },
                                { Currency.RUB, Currency.RUB_SM_CODE },
                                { Currency.GBP, Currency.GBP_SM_CODE },
                                { Currency.AZN, Currency.AZN_SM_CODE },
            };

        if (currencyCodeArray[id] != null)
        {
            return currencyCodeArray[id];
        }
        return null!;
    }
}
