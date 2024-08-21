using Microsoft.EntityFrameworkCore;
using SharedKernel.Main.Application.Interfaces.Repositories.IMT;
using SharedKernel.Main.Domain.IMT;
using SharedKernel.Main.Infrastructure.Persistence.Configurations;

namespace SharedKernel.Main.Infrastructure.Persistence.Repositories.IMT
{
    public class CountryRepository(ApplicationDbContext _dbContext) : ICountryRepository
    {
        public async Task<Country?> FindCountryByIdAsync(int id, CancellationToken cancellationToken)
        {
            var result = await _dbContext.Country.Where(e => e.Id == id).Where(e => e.Status == 1).FirstOrDefaultAsync(cancellationToken).ConfigureAwait(false);

            return result;
        }
    }
}
