namespace Eventify.Platform.API.Profiles.Interfaces.REST.Resources;

public record CreateServiceCatalogResource(
    string Title,
    string Description,
    string Category,
    decimal PriceFrom,
    decimal PriceTo);