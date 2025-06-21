using Eventify.Platform.API.Planning.Domain.Model.Aggregates;
using Eventify.Platform.API.Planning.Interfaces.REST.Resources;

namespace Eventify.Platform.API.Planning.Interfaces.REST.Transform;

public class ServiceItemResourceFromEntityAssembler
{
    public static ServiceItemResource ToResourceFromEntity(ServiceItem entity)
    {
        return new ServiceItemResource(entity.Id.Identifier.ToString(), entity.Description, entity.Quantity, entity.UnitPrice, entity.TotalPrice, entity.QuoteId.Identifier.ToString());
    }
}