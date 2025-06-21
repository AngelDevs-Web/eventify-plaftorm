using Eventify.Platform.API.Planning.Domain.Model.Commands;
using Eventify.Platform.API.Planning.Domain.Model.ValueObjects;
using Eventify.Platform.API.Planning.Interfaces.REST.Resources;

namespace Eventify.Platform.API.Planning.Interfaces.REST.Transform;

public class CreateServiceItemCommandFromResourceAssembler
{
    public static CreateServiceItemCommand ToCommandFromResource(CreateServiceItemResource resource)
    {
        return new CreateServiceItemCommand(resource.Description, resource.Quantity, resource.UnitPrice,
            resource.TotalPrice, new QuoteId(Guid.Parse(resource.QuoteId)));
    }
}