namespace Eventify.Platform.API.Planning.Interfaces.REST.Resources;

public record UpdateServiceItemResource(string Description, int Quantity, double UnitPrice, double TotalPrice);