namespace SharedBusiness.Main.Common.Contracts;

public record CountryDto(
    uint id,
    string? iso_code,
    string? iso_code_short,
    string? iso_code_num,
    string? name,
    string? official_state_name
    );