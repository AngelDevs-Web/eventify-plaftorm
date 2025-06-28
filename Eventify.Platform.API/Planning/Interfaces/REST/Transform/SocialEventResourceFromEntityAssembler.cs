using Eventify.Platform.API.Planning.Domain.Model.Aggregates;
using Eventify.Platform.API.Planning.Interfaces.REST.Resources;

namespace Eventify.Platform.API.Planning.Interfaces.REST.Transform;

public class SocialEventResourceFromEntityAssembler
{
    public static SocialEventResource ToResourceFromEntity(SocialEvent entity)
    {
        return new SocialEventResource(
            entity.Id.IdSocialEvent.ToString(),
           entity.EventTitle,
            entity.EventDate,
            entity.NameCustomer.NameCustomer,
            entity.Location,
            entity.Status
        );
    }
}