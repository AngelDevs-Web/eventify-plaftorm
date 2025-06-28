namespace Eventify.Platform.API.Planning.Domain.Model.Commands;

public record DeleteSocialEventsCommand(IEnumerable<int> Ids);