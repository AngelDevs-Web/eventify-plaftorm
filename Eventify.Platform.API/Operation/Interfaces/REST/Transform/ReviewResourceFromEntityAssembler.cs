using Eventify.Platform.API.Operation.Domain.Model.Aggregates;
using Eventify.Platform.API.Operation.Interfaces.REST.Resources;

namespace Eventify.Platform.API.Operation.Interfaces.REST.Transform;

public static class ReviewResourceFromEntityAssembler
{
    public static ReviewResource ToResourceFromEntity(Review entity)
    {
        return new ReviewResource(
            entity.Id,
            entity.Content,
            entity.Rating,
            entity.ProfileId.Id,
            entity.SocialEventId.Id);
    }
}