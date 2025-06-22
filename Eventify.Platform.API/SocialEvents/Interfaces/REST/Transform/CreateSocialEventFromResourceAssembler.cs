using Eventify.Platform.API.SocialEvents.Domain.Model.Commands;
using Eventify.Platform.API.SocialEvents.Domain.Model.ValueObjects;
using Eventify.Platform.API.SocialEvents.Interfaces.REST.Resources;

namespace Eventify.Platform.API.SocialEvents.Interfaces.REST.Transform;


public static class CreateSocialEventCommandFromResourceAssembler
{
    public static CreateSocialEventCommand ToCommandFromResource(CreateSocialEventResource resource)
    {
        return new CreateSocialEventCommand(
            resource.EventTitle,
            resource.EventDate,
            resource.CustomerName,
            resource.Location,
            resource.Status
        );
    }
}
