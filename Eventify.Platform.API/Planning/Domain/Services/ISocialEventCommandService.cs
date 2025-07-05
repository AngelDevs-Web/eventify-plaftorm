using Eventify.Platform.API.Planning.Domain.Model.Aggregates;
using Eventify.Platform.API.Planning.Domain.Model.Commands;

namespace Eventify.Platform.API.Planning.Domain.Services;

public interface ISocialEventCommandService
{
    Task<SocialEvent?> Handle(CreateSocialEventCommand command);
    Task<SocialEvent?> Handle(UpdateSocialEventCommand command);
    Task<SocialEvent?> Handle(DeleteSocialEventCommand command);
}