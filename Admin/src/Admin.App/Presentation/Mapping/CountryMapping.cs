using Mapster;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.IMT.Contracts.Contracts.Responses;
using Thunes.Response.Discovery;

namespace Admin.App.Presentation.Mapping;

public class CountryMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {

        config.NewConfig<Country, CountryDto>()
            .Map(dest => dest.id, src => src.Id)
            .Map(dest => dest.iso_code_short, src => src.IsoCodeShort)
            .Map(dest => dest.iso_code, src => src.IsoCode)
            .Map(dest => dest.iso_code_num, src => src.IsoCodeNum)
            .Map(dest => dest.name, src => src.Name)
            .Map(dest => dest.official_state_name, src => src.OfficialStateName);
    }
}