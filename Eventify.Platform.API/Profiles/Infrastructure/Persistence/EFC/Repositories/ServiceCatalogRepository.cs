using Eventify.Platform.API.Profiles.Domain.Model.Aggregates;
using Eventify.Platform.API.Profiles.Domain.Repositories;
using Eventify.Platform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using Eventify.Platform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Eventify.Platform.API.Profiles.Infrastructure.Persistence.EFC.Repositories;

public class ServiceCatalogRepository(AppDbContext context) : BaseRepository<ServiceCatalog>(context), IServiceCatalogRepository
{
    public async Task<IEnumerable<ServiceCatalog>> ListByProfileIdAsync(int profileId)
    {
        return await Context.Set<ServiceCatalog>()
            .Where(s => s.ProfileId == profileId)
            .ToListAsync();
    }

    public async Task<ServiceCatalog?> FindByIdAndProfileIdAsync(int serviceCatalogId, int profileId)
    {
        return await Context.Set<ServiceCatalog>()
            .FirstOrDefaultAsync(s => s.Id == serviceCatalogId && s.ProfileId == profileId);
    }
}