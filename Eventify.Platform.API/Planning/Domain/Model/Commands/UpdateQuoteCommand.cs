using Eventify.Platform.API.Planning.Domain.Model.ValueObjects;

namespace Eventify.Platform.API.Planning.Domain.Model.Commands;

public record UpdateQuoteCommand(QuoteId QuoteId, string Title, ESocialEventType EventType, int GuestQuantity, string Location, double TotalPrice, DateTime EventDate);