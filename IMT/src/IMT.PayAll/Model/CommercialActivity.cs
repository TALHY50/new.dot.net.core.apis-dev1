
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Converters;

namespace IMT.PayAll.Model
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CommercialActivity
    {
        [EnumMember(Value = "transportation")] transportation,
        [EnumMember(Value = "warehousing")] warehousing,
        [EnumMember(Value = "insurance")] insurance,
        [EnumMember(Value = "banking_and_finance")] banking_and_finance,
        [EnumMember(Value = "acquiring")] acquiring,
        [EnumMember(Value = "selling_of_goods_and_services")] selling_of_goods_and_services
    
    }
}
