using Eventify.Platform.API.Operation.Domain.Model.ValueObjects;

namespace Eventify.Platform.API.Operation.Domain.Model.Commands;

public record CreateReviewCommand(
    String Content,
    int Rating,
    ProfileId ProfileId,
    SocialEventId SocialEventId
    );