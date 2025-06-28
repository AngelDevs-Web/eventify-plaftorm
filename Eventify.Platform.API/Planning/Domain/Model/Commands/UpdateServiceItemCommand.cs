using Eventify.Platform.API.Planning.Domain.Model.ValueObjects;

namespace Eventify.Platform.API.Planning.Domain.Model.Commands;

public record UpdateServiceItemCommand(ServiceItemId ServiceItemId, string Description, int Quantity, double UnitPrice, double TotalPrice);