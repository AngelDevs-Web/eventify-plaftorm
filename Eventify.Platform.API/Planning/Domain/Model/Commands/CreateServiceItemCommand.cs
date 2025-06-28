using Eventify.Platform.API.Planning.Domain.Model.ValueObjects;

namespace Eventify.Platform.API.Planning.Domain.Model.Commands;

public record CreateServiceItemCommand(string Description, int Quantity, double UnitPrice, double TotalPrice, QuoteId QuoteId);