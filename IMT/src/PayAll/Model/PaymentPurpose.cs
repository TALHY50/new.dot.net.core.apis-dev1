using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Converters;

namespace PayAll.Model
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PaymentPurpose
    {
        [EnumMember(Value = "family_maintenance")] family_maintenance,
        [EnumMember(Value = "household_maintenance")] household_maintenance,
        [EnumMember(Value = "donation_or_gifts")] donation_or_gifts,
        [EnumMember(Value = "payment_of_loan")] payment_of_loan,
        [EnumMember(Value = "purchase_of_property")] purchase_of_property,
        [EnumMember(Value = "funeral_expenses")] funeral_expenses,
        [EnumMember(Value = "medical_expenses")] medical_expenses,
        [EnumMember(Value = "wedding_expenses")] wedding_expenses,
        [EnumMember(Value = "payment_of_bills")] payment_of_bills,
        [EnumMember(Value = "education_savings")] education_savings,
        [EnumMember(Value = "employee_colleague")] employee_colleague,
        [EnumMember(Value = "business_investment")] business_investment,
        [EnumMember(Value = "salary")] salary,
        [EnumMember(Value = "payment_of_goods_and_services")] payment_of_goods_and_services
    }
}
