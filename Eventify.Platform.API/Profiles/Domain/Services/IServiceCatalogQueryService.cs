using Eventify.Platform.API.Profiles.Domain.Model.Aggregates;
using Eventify.Platform.API.Profiles.Domain.Model.Queries;

namespace Eventify.Platform.API.Profiles.Domain.Services;

public interface IServiceCatalogQueryService
{
    Task<IEnumerable<ServiceCatalog>> Handle(GetAllServiceCatalogsQuery query);
    Task<ServiceCatalog?> Handle(GetServiceCatalogByIdQuery query);
    Task<IEnumerable<ServiceCatalog>> Handle(GetServiceCatalogsByProfileIdQuery query);
    Task<ServiceCatalog?> Handle(GetServiceCatalogByIdForProfileQuery query);
}