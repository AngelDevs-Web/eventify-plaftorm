using Eventify.Platform.API.Planning.Domain.Model.Commands;
using Eventify.Platform.API.Planning.Domain.Model.ValueObjects;
using Eventify.Platform.API.Planning.Interfaces.REST.Resources;

namespace Eventify.Platform.API.Planning.Interfaces.REST.Transform;

public class CreateQuoteCommandFromResourceAssembler
{
    public static CreateQuoteCommand ToCommandFromResource(CreateQuoteResource resource)
    {
        return new CreateQuoteCommand(resource.Title, Enum.Parse<ESocialEventType>(resource.EventType),resource.GuestQuantity,resource.Location,resource.TotalPrice,Enum.Parse<EQuoteStatus>(resource.Status), resource.EventDate, new OrganizerId(resource.OrganizerId), new HostId(resource.HostId));
    }
}