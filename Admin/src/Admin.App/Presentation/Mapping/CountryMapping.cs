using Mapster;
using SharedBusiness.Main.Common.Domain.Entities;
using Thunes.Response.Discovery;
using CountryResponse = SharedBusiness.Main.IMT.Contracts.Contracts.Responses.CountryResponse;

namespace Admin.App.Presentation.Mapping;

public class CountryMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {

        config.NewConfig<Country, CountryResponse>()
            .Map(dest => dest.id, src => src.Id);
    }
}