using Credential = SharedKernel.Main.Domain.Setups.Credential;

namespace SharedKernel.Main.Application.Common.Interfaces;

public interface ISmsService
{
    public Task<ISmsSender?> GetSmsSender(Credential credential);
}