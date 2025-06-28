using Eventify.Platform.API.Planning.Domain.Model.ValueObjects;

namespace Eventify.Platform.API.Planning.Domain.Model.Commands;

public record RejectQuoteCommand(QuoteId QuoteId);