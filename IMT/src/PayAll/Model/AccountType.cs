
using System.Runtime.Serialization;

namespace PayAll.Model
{
    public enum AccountType
    {
        [EnumMember(Value = "Business")] Business,
        [EnumMember(Value = "Person")] Person
    }
}
