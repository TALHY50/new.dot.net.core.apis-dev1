using Ardalis.SharedKernel;

namespace ACL.Business.Domain.Entities;

public class UserSetting : ValueObject
{
    public uint Id { get; set; }
    public string AppId { get; set; }
    public string AppSecret { get; set; }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Id;
        yield return AppId;
        yield return AppSecret;
    }
}