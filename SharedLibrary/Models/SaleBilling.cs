namespace SharedLibrary.Models;
using Newtonsoft.Json;

public partial class SaleBilling
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("merchant_id")]
    public int MerchantId { get; set; }

    [JsonProperty("sale_id")]
    public int SaleId { get; set; }

    [JsonProperty("card_holder_name")]
    public string? CardHolderName { get; set; }

    [JsonProperty("extra_card_holder_name")]
    public string? ExtraCardHolderName { get; set; }

    [JsonProperty("card_number")]
    public string? CardNumber { get; set; }

    [JsonProperty("expiry_month")]
    public string? ExpiryMonth { get; set; }

    [JsonProperty("expiry_year")]
    public string? ExpiryYear { get; set; }

    [JsonProperty("cvv")]
    public string? Cvv { get; set; }

    [JsonProperty("bill_name")]
    public string? BillName { get; set; }

    [JsonProperty("bill_surname")]
    public string? BillSurname { get; set; }

    [JsonProperty("bill_address1")]
    public string? BillAddress1 { get; set; }

    [JsonProperty("bill_address2")]
    public string? BillAddress2 { get; set; }

    [JsonProperty("bill_city")]
    public string? BillCity { get; set; }

    [JsonProperty("bill_postcode")]
    public string? BillPostcode { get; set; }

    [JsonProperty("bill_state")]
    public string? BillState { get; set; }

    [JsonProperty("bill_country")]
    public string? BillCountry { get; set; }

    [JsonProperty("bill_email")]
    public string? BillEmail { get; set; }

    [JsonProperty("bill_phone")]
    public string? BillPhone { get; set; }

    /// <summary>
    /// created by merchant user id
    /// </summary>
    [JsonProperty("created_by")]
    public int? CreatedBy { get; set; }

    /// <summary>
    /// created by merchant user name
    /// </summary>
    [JsonProperty("created_by_name")]
    public string? CreatedByName { get; set; }

    [JsonProperty("created_at")]
    public DateTime? CreatedAt { get; set; }

    [JsonProperty("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    [JsonProperty("bill_tckn")]
    public string? BillTckn { get; set; }

    [JsonProperty("bill_tax_no")]
    public string? BillTaxNo { get; set; }

    [JsonProperty("bill_tax_office")]
    public string? BillTaxOffice { get; set; }

    [JsonProperty("customer_type")]
    public sbyte? CustomerType { get; set; }

    [JsonProperty("migration_status")]
    public sbyte? MigrationStatus { get; set; }
}
