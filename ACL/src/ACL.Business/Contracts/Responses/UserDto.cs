namespace ACL.Business.Contracts.Responses;

public record UserDto(
uint id,
string? first_name,
string? last_name,
string? email,
string? avatar,
string? language,
string? password,
DateTime? dob,
sbyte? gender,
string? address,
string? city,
uint? country,
string? phone,
string? user_name,
string? img_path,
byte status,
string? salt);
