using Eventify.Platform.API.Profiles.Domain.Model.Commands;
using Eventify.Platform.API.Profiles.Interfaces.REST.Resources;

namespace Eventify.Platform.API.Profiles.Interfaces.REST.Transform;

public class CreateServiceCatalogCommandFromResourceAssembler
{
    public static CreateServiceCatalogCommand ToCommandFromResource(int profileId, CreateServiceCatalogResource resource)
    {
        return new CreateServiceCatalogCommand(profileId, resource.Title, resource.Description, resource.Category, resource.PriceFrom, resource.PriceTo);
    }
}