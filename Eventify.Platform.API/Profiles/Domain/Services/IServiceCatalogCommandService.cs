using Eventify.Platform.API.Profiles.Domain.Model.Aggregates;
using Eventify.Platform.API.Profiles.Domain.Model.Commands;

namespace Eventify.Platform.API.Profiles.Domain.Services;

public interface IServiceCatalogCommandService
{
    Task<ServiceCatalog?> Handle(CreateServiceCatalogCommand command);
    Task<ServiceCatalog?> Handle(UpdateServiceCatalogCommand command);
    Task<bool> Handle(DeleteServiceCatalogCommand command);
}