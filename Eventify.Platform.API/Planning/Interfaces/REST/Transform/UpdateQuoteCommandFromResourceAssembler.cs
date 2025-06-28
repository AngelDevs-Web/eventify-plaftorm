using Eventify.Platform.API.Planning.Domain.Model.Commands;
using Eventify.Platform.API.Planning.Domain.Model.ValueObjects;
using Eventify.Platform.API.Planning.Interfaces.REST.Resources;

namespace Eventify.Platform.API.Planning.Interfaces.REST.Transform;

public class UpdateQuoteCommandFromResourceAssembler
{
    public static UpdateQuoteCommand ToCommandFromResource(string quoteId, UpdateQuoteResource resource)
    {
        return new UpdateQuoteCommand(new QuoteId(Guid.Parse(quoteId)), resource.Title,
            Enum.Parse<ESocialEventType>(resource.EventType), resource.GuestQuantity, resource.Location,
            resource.TotalPrice, resource.EventDate);
    }
}