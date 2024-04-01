using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using SharedLibrary.Services;

namespace SharedLibrary.Models;

public partial class SavedCard
{
    public const int BIN_LENGTH = 6;
    
    [JsonProperty("id")]
    public int Id { get; set; }

    
    [JsonIgnore]
    public string? CardToken { get; set; }

    /// <summary>
    /// For Craft Grate Api
    /// </summary>
    
    [JsonProperty("card_user_key")]
    public string? CardUserKey { get; set; }

    [JsonProperty("card_number")]
    public string? CardNumber { get; set; }
    
    [JsonProperty("merchant_id")]
    public int? MerchantId { get; set; }

    [JsonProperty("customer_number")]
    public string? CustomerNumber { get; set; }
    [JsonProperty("card_issuer_bank")]
    public string? CardIssuerBank { get; set; }

    
    [JsonProperty("card_token")]
    public string? BrandToken { get; set; }

    [JsonProperty("customer_name")]
    public string? CustomerName { get; set; }

    [JsonProperty("customer_email")]
    public string? CustomerEmail { get; set; }

    [JsonProperty("customer_phone")]
    public string? CustomerPhone { get; set; }

    [JsonIgnore]
    public int? BankId { get; set; }

    [JsonIgnore]
    public sbyte? MigrationStatus { get; set; }

    [JsonProperty("created_at")]
    public DateTime? CreatedAt { get; set; }

    [JsonProperty("updated_at")]
    public DateTime? UpdatedAt { get; set; }
    
    [JsonIgnore]
    [NotMapped]
    public string? DecryptedCardUserKey
    {
        get
        {
            // Decrypt the value and return it
            return Cryptographer.AppDecrypt(this.CardUserKey);
        }
    }

    [JsonIgnore]
    [NotMapped]
    public string? DecryptedCardToken
    {
        get
        {
            // Decrypt the value and return it
            return Cryptographer.AppDecrypt(this.CardToken);
        }
    }
    
    [JsonIgnore]
    [NotMapped]
    public string? OriginalCustomerNumber
    {
        
        get
        {
            string? result = null;
            string? inp = CustomerNumber;
            if (inp != null)
            {
                int indexOfHyphen = inp.IndexOf("-");
                result = indexOfHyphen != -1 ? inp.Substring(0, indexOfHyphen) : inp;
            }

            return result;

        }
    }
    
    
}
