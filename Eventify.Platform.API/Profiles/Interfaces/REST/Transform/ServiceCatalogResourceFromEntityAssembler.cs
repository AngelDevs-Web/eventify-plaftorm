using Eventify.Platform.API.Profiles.Domain.Model.Aggregates;
using Eventify.Platform.API.Profiles.Interfaces.REST.Resources;

namespace Eventify.Platform.API.Profiles.Interfaces.REST.Transform;

public class ServiceCatalogResourceFromEntityAssembler
{
    public static ServiceCatalogResource ToResourceFromEntity(ServiceCatalog entity)
    {
        return new ServiceCatalogResource(entity.Id, entity.ProfileId, entity.Title, entity.Description, entity.Category, entity.PriceFrom, entity.PriceTo);
    }
}