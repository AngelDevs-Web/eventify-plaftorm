using Eventify.Platform.API.SocialEvents.Domain.Model.ValueObjects;

namespace Eventify.Platform.API.SocialEvents.Domain.Model.Commands;

public record UpdateSocialEventCommand(
    int Id,
    string EventTitle,
    DateTime EventDate,
    string CustomerName,
    string Location,
    EStatusType Status
    );