using Eventify.Platform.API.Planning.Domain.Model.Commands;
using Eventify.Platform.API.Planning.Interfaces.REST.Resources;

namespace Eventify.Platform.API.Planning.Interfaces.REST.Transform;

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