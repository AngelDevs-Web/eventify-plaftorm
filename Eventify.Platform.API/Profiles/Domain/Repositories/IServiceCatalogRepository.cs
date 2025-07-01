using Eventify.Platform.API.Profiles.Domain.Model.Aggregates;
using Eventify.Platform.API.Shared.Domain.Repositories;

namespace Eventify.Platform.API.Profiles.Domain.Repositories;

public interface IServiceCatalogRepository : IBaseRepository<ServiceCatalog>
{
    Task<IEnumerable<ServiceCatalog>> ListByProfileIdAsync(int profileId);
    Task<ServiceCatalog?> FindByIdAndProfileIdAsync(int serviceCatalogId, int profileId);
}