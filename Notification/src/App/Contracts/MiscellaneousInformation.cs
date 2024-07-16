namespace ACL.Application.Contracts;

public record MiscellaneousInformation(
    int CreatedById = 0,
    int CompanyId = 0);