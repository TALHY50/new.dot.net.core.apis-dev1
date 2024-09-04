namespace SharedBusiness.Main.Common.Contracts;

public record TransactionLimitDto(

    uint id,

    sbyte? transaction_type,

    sbyte? user_category,

    int? daily_total_number,

    decimal? daily_total_amount,

    int? monthly_total_number,

    decimal? monthly_total_amount,

    uint? currency_id
    );