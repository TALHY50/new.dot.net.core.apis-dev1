
using System.Runtime.Serialization;


namespace IMT.PayAll.Model
{
    public enum AccountType
    {
        [EnumMember(Value = "Business")] Business,
        [EnumMember(Value = "Person")] Person
    }
}
