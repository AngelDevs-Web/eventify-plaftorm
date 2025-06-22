namespace Eventify.Platform.API.Operation.Interfaces.REST.Resources;

public record CreateReviewResource(string Content, int Rating, int ProfileId, int SocialEventId);