using Eventify.Platform.API.SocialEvents.Domain.Model.Aggregates;
using Eventify.Platform.API.SocialEvents.Interfaces.REST.Resources;

namespace Eventify.Platform.API.SocialEvents.Interfaces.REST.Transform;

public static class SocialEventResourceFromEntityAssembler
{
    public static SocialEventResource ToResourceFromEntity(SocialEvent entity)
    {
        return new SocialEventResource(
            entity.Id,
            entity.EventTitle,
            entity.EventDate,
            entity.NameCustomer.NameCustomer,
            entity.Location,
            entity.Status
        );
    }
}