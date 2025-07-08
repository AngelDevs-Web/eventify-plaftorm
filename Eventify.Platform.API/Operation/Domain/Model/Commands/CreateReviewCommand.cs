using Eventify.Platform.API.Operation.Domain.Model.ValueObjects;

namespace Eventify.Platform.API.Operation.Domain.Model.Commands;

public record CreateReviewCommand(
    String Reviewer,
    String EventName,
    DateTime EventDate,
    String Content,
    int Rating,
    DateTime ReviewDate
);