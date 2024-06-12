
using System.Runtime.Serialization;


namespace IMT.PayAll.Model
{
    public enum PaymentType
    {
        [EnumMember(Value = "B2B")] B2B,

        [EnumMember(Value = "B2P")] B2P,

        [EnumMember(Value = "P2B")] P2B,

        [EnumMember(Value = "P2P")] P2P

    }
}
