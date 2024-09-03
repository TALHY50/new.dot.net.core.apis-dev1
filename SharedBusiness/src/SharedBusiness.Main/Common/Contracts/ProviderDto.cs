using SharedKernel.Main.Application.Enums;

namespace SharedBusiness.Main.Common.Contracts
{
    public record ProviderDto(
        uint id,
        string? code,
        string? name,
        string? baseUrl,
        string? apiKey,
        string? apiSecret,
        ProviderStatusValues? status
        );
}
