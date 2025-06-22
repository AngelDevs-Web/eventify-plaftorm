using Eventify.Platform.API.SocialEvents.Domain.Model.Commands;
using Eventify.Platform.API.SocialEvents.Domain.Model.ValueObjects;
using Eventify.Platform.API.SocialEvents.Interfaces.REST.Resources;

namespace Eventify.Platform.API.SocialEvents.Interfaces.REST.Transform;

public static class UpdateSocialEventCommandFromResourceAssembler
{
    public static UpdateSocialEventCommand ToCommandFromResource(int socialEventId, UpdateSocialEventResource resource)
    {
        return new UpdateSocialEventCommand(
            socialEventId,
            resource.EventTitle,
            resource.EventDate,
            resource.CustomerName,
            resource.Location,
            resource.Status
            
        );
    }
}