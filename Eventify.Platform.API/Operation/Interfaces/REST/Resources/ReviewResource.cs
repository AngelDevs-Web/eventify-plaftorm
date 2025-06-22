namespace Eventify.Platform.API.Operation.Interfaces.REST.Resources;

public record ReviewResource(int Id, string Content, int Rating, int ProfileId, int SocialEventId );