using Eventify.Platform.API.Profiles.Domain.Model.Aggregates;
using Eventify.Platform.API.Profiles.Domain.Model.Queries;
using Eventify.Platform.API.Profiles.Domain.Repositories;
using Eventify.Platform.API.Profiles.Domain.Services;

namespace Eventify.Platform.API.Profiles.Application.Internal.QueryServices;

public class ServiceCatalogQueryService(
    IServiceCatalogRepository serviceCatalogRepository
) : IServiceCatalogQueryService
{
    public async Task<IEnumerable<ServiceCatalog>> Handle(GetAllServiceCatalogsQuery query)
    {
        return await serviceCatalogRepository.ListAsync();
    }

    public async Task<ServiceCatalog?> Handle(GetServiceCatalogByIdQuery query)
    {
        return await serviceCatalogRepository.FindByIdAsync(query.ServiceCatalogId);
    }

    public async Task<IEnumerable<ServiceCatalog>> Handle(GetServiceCatalogsByProfileIdQuery query)
    {
        return await serviceCatalogRepository.ListByProfileIdAsync(query.ProfileId);
    }

    public async Task<ServiceCatalog?> Handle(GetServiceCatalogByIdForProfileQuery query)
    {
        return await serviceCatalogRepository.FindByIdAndProfileIdAsync(query.ServiceCatalogId, query.ProfileId);
    }
}