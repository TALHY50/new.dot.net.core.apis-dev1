using Microsoft.EntityFrameworkCore;
using SharedKernel.Main.Application.Interfaces.Repositories.IMT;
using SharedKernel.Main.Domain.IMT;
using SharedKernel.Main.Infrastructure.Persistence.Configurations;

namespace SharedKernel.Main.Infrastructure.Persistence.Repositories.IMT
{
    internal class RegionsRepository(ApplicationDbContext _dbContext) : IRegionsRepository
    {
        public async Task<Regions?> FindActiveRecordByIdAsync(int id, CancellationToken cancellationToken)
        {
            var result = await _dbContext.Regions.Where(e => e.Id == id).Where(e => e.Status == 0).FirstOrDefaultAsync(cancellationToken).ConfigureAwait(false);

            return result;
        }
    }
}
