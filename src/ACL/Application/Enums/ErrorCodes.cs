namespace ACL.Application.Enums
{
    enum ErrorCodes
    {
        AnUnexpectedErrorOccurred = 99,
        CredentialsAreNotValid = 101,
        AccessTokenIsNotValid = 102,
        RefreshTokenIsNotActive = 103,
        RefreshTokenHasExpired = 104,
        RefreshTokenIsNotCorrect = 105,
        UserDoesNotExist = 106,
        UserWithEmailAlreadyExist = 107
    }
}
