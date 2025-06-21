using Eventify.Platform.API.SocialEvents.Domain.Model.Aggregates;
using Eventify.Platform.API.SocialEvents.Domain.Model.Commands;

namespace Eventify.Platform.API.SocialEvents.Domain.Services;

public interface ISocialEventCommandService
{
    Task<SocialEvent?> Handle(CreateSocialEventCommand command);
    Task<SocialEvent?> Handle(UpdateSocialEventCommand command);
    Task<SocialEvent?> Handle(DeleteSocialEventCommand command);
}