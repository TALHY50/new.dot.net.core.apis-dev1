using Ardalis.SharedKernel;

namespace ACL.Business.Domain.Entities;

public class UserSetting : EntityBase<ulong>, IAggregateRoot
{
    public string AppId { get; set; }
    public string AppSecret { get; set; }
}