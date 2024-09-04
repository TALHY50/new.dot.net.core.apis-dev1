using ACL.Business.Contracts.Responses;
using Mapster;
using Microsoft.AspNetCore.Identity;

namespace ACL.Web.Presentation.Mappings;

public class LoginResultMapping
{
    public void Register(TypeAdapterConfig config)
    {

        /*config.NewConfig<SignInResult, LoginResultDto>()
            .Map(dest => dest.token_type, src => src.)
            .Map(dest => dest.iso_code_short, src => src.IsoCodeShort)
            .Map(dest => dest.iso_code, src => src.IsoCode)
            .Map(dest => dest.iso_code_num, src => src.IsoCodeNum)
            .Map(dest => dest.name, src => src.Name)
            .Map(dest => dest.official_state_name, src => src.OfficialStateName);*/
    }
}