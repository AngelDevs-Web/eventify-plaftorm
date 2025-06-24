using Eventify.Platform.API.Operation.Domain.Model.ValueObjects;

namespace Eventify.Platform.API.Operation.Domain.Model.Commands;

public record CreateReviewCommand(
    string Content,
    int Rating,
    int ProfileId,
    int SocialEventId
    );