namespace ACL.Business.Application.Interfaces.Services
{
    public interface IRefreshTokenValidator
    {
        Task<bool> ValidateAsync(string refreshToken);
    }

    public class RefreshTokenValidator : IRefreshTokenValidator
    {
        private readonly IIdentity _identity;

        public RefreshTokenValidator(IIdentity identity)
        {
            _identity = identity ?? throw new ArgumentNullException(nameof(identity));
        }

        /// <summary>
        /// Validates the refresh token by checking if it is well-formed, non-expired, and issued to a valid user.
        /// </summary>
        /// <param name="refreshToken">The refresh token to validate.</param>
        /// <returns>True if valid, otherwise false.</returns>
        public async Task<bool> ValidateAsync(string refreshToken)
        {
            if (string.IsNullOrEmpty(refreshToken))
            {
                return false;
            }

            // Use IIdentity method to check if the token is valid
            var isTokenValid = await _identity.IsTokenValid(refreshToken, validateLifeTime: false);
            if (!isTokenValid)
            {
                return false;
            }

            // Optionally, you can extract additional data from the token and perform more checks
            var userId = await _identity.GetUserIdFromToken(refreshToken);
            if (string.IsNullOrEmpty(userId))
            {
                return false;
            }

            // At this point, the token is valid and contains a valid user ID
            return true;
        }
    }
}