using Eventify.Platform.API.SocialEvents.Domain.Model.ValueObjects;

namespace Eventify.Platform.API.SocialEvents.Interfaces.REST.Resources;

public record SocialEventResource(
    int Id,
    string EventTitle,
    DateTime EventDate,
    string CustomerName,
    string Location,
    EStatusType Status
    );
    
