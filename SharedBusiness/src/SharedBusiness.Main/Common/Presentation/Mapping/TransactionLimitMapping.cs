using Mapster;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.IMT.Contracts.Contracts.Responses;


namespace SharedBusiness.Main.Common.Presentation.Mapping;

public class TransactionLimitMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {

        config.NewConfig<TransactionLimit, TransactionLimitDto>()
            .Map(dest => dest.id, src => src.Id)
            .Map(dest => dest.currency_id, src => src.CurrencyId)
            .Map(dest => dest.daily_total_amount, src => src.DailyTotalAmount)
            .Map(dest => dest.daily_total_number, src => src.DailyTotalNumber)
            .Map(dest => dest.monthly_total_amount, src => src.MonthlyTotalAmount)
            .Map(dest => dest.monthly_total_number, src => src.MonthlyTotalNumber)
            .Map(dest => dest.transaction_type, src => src.TransactionType)
            .Map(dest => dest.user_category, src => src.UserCategory);
    }
}