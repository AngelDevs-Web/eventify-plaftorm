namespace Eventify.Platform.API.SocialEvents.Domain.Model.Commands;

public record DeleteSocialEventsCommand(IEnumerable<int> Ids);