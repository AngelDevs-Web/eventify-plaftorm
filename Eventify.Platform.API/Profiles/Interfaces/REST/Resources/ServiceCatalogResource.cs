namespace Eventify.Platform.API.Profiles.Interfaces.REST.Resources;

public record ServiceCatalogResource(
    int Id,
    int ProfileId,
    string Title,
    string Description,
    string Category,
    decimal PriceFrom,
    decimal PriceTo);